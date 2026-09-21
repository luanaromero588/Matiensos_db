using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class VentaData : Conexion
    {
        public string ObtenerNuevoCodigoComprobante(char tipoComprobante)
        {
            using (var conn = ObtenerConexion())
            {
                using (var cmd = new SqlCommand("dbo.sp_GenerarNumeroComprobante", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VoucherType", tipoComprobante);

                    var paramSalida = new SqlParameter("@NuevoCodigo", SqlDbType.VarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(paramSalida);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return paramSalida.Value?.ToString() ?? string.Empty;
                }
            }
        }

        /// <summary>
        /// Registra una venta junto con sus detalles y actualiza el stock de los productos vendidos.
        /// </summary>
        /// <param name="venta"></param>
        /// <param name="mensajeResultado"></param>
        /// <returns></returns>
        public bool RegistrarVenta(Venta venta, out string mensajeResultado)
        {
            mensajeResultado = string.Empty;

            using (var conn = ObtenerConexion())
            {
                conn.Open();
                using (var transaccion = conn.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        //Insertar Cabecera de Venta
                        const string queryVenta = @"
                            INSERT INTO dbo.sale 
                                (code, total_amount, status, voucher_type, created_at, is_active, user_id, customer_id, payment_method_id)
                            VALUES 
                                (@code, @total, @status, @voucher_type, GETDATE(), 1, @user_id, @customer_id, @payment_method_id);
                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int nuevaVentaId;
                        using (var cmdVenta = new SqlCommand(queryVenta, conn, transaccion))
                        {
                            cmdVenta.Parameters.Add("@code", SqlDbType.VarChar, 50).Value = venta.Codigo;
                            cmdVenta.Parameters.Add("@total", SqlDbType.Decimal).Value = venta.Total;
                            cmdVenta.Parameters.Add("@status", SqlDbType.VarChar, 20).Value = venta.Estado;
                            cmdVenta.Parameters.Add("@voucher_type", SqlDbType.Char, 1).Value = venta.TipoComprobante;
                            cmdVenta.Parameters.Add("@user_id", SqlDbType.Int).Value = venta.UsuarioId;
                            cmdVenta.Parameters.Add("@customer_id", SqlDbType.Int).Value = venta.ClienteId;
                            cmdVenta.Parameters.Add("@payment_method_id", SqlDbType.Int).Value = venta.MetodoPagoId;

                            nuevaVentaId = (int)cmdVenta.ExecuteScalar();
                        }

                        //Prepara comandos para Detalle y Stock
                        const string queryDetalle = @"
                            INSERT INTO dbo.sale_detail (quantity, unit_price, product_id, sale_id)
                            VALUES (@quantity, @unit_price, @product_id, @sale_id);";

                        //El UPDATE exige stock >= @cantidad para evitar inconsistencias de concurrencia
                        const string queryStock = @"
                            UPDATE dbo.product 
                            SET stock = stock - @cantidad 
                            WHERE id = @product_id AND stock >= @cantidad;";

                        using (var cmdDetalle = new SqlCommand(queryDetalle, conn, transaccion))
                        using (var cmdStock = new SqlCommand(queryStock, conn, transaccion))
                        {
                            //Parámetros tipados explícitamente para Detalle
                            cmdDetalle.Parameters.Add("@quantity", SqlDbType.Int);
                            cmdDetalle.Parameters.Add("@unit_price", SqlDbType.Decimal);
                            cmdDetalle.Parameters.Add("@product_id", SqlDbType.Int);
                            cmdDetalle.Parameters.Add("@sale_id", SqlDbType.Int).Value = nuevaVentaId;

                            //Parámetros tipados explícitamente para Stock
                            cmdStock.Parameters.Add("@cantidad", SqlDbType.Int);
                            cmdStock.Parameters.Add("@product_id", SqlDbType.Int);

                            foreach (var item in venta.Detalles)
                            {
                                //Descontar Stock y validar si alcanzó
                                cmdStock.Parameters["@cantidad"].Value = item.Cantidad;
                                cmdStock.Parameters["@product_id"].Value = item.ProductoId;

                                int filasAfectadas = cmdStock.ExecuteNonQuery();
                                if (filasAfectadas == 0)
                                {
                                    // Falló: o el producto no existe o el stock disponible es menor al pedido
                                    throw new InvalidOperationException($"Stock insuficiente o producto no disponible: ID {item.ProductoId}. Operación abortada.");
                                }

                                //Insertar Detalle
                                cmdDetalle.Parameters["@quantity"].Value = item.Cantidad;
                                cmdDetalle.Parameters["@unit_price"].Value = item.PrecioUnitario;
                                cmdDetalle.Parameters["@product_id"].Value = item.ProductoId;

                                cmdDetalle.ExecuteNonQuery();
                            }
                        }

                        transaccion.Commit();
                        mensajeResultado = "Venta registrada exitosamente.";
                        return true;
                    }
                    catch (InvalidOperationException exNegocio)
                    {
                        transaccion.Rollback();
                        mensajeResultado = exNegocio.Message;
                        return false;
                    }
                    catch (SqlException exSql)
                    {
                        transaccion.Rollback();
                        mensajeResultado = $"Error de persistencia en base de datos: Código {exSql.Number}.";
                        return false;
                    }
                    catch (Exception exGeneral)
                    {
                        transaccion.Rollback();
                        mensajeResultado = $"Error imprevisto al procesar la venta: {exGeneral.Message}";
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Lista ventas activas filtradas por rango de fechas y, opcionalmente, método de pago.
        /// </summary>
        public List<VentaResumen> ObtenerHistorialPaginado(DateTime desde, DateTime hasta, int? metodoPagoId, int pagina, int filasPorPagina, out int totalPaginas)
        {
            var lista = new List<VentaResumen>();

            //hasta se toma hasta el final del día
            DateTime hastaInclusive = hasta.Date.AddDays(1).AddTicks(-1);

            string filtroMetodoPago = metodoPagoId.HasValue ? "AND s.payment_method_id = @payment_method_id" : "";

            string queryConteo = $@"
                SELECT COUNT(*)
                FROM dbo.sale s
                WHERE s.is_active = 1
                  AND s.created_at BETWEEN @desde AND @hasta
                  {filtroMetodoPago};";

            string queryDatos = $@"
                SELECT 
                    s.id, s.code, s.created_at, s.total_amount,
                    p.first_name, p.last_name,
                    pm.name AS metodo_pago
                FROM dbo.sale s
                INNER JOIN dbo.customer c ON s.customer_id = c.customer_id
                INNER JOIN dbo.person p ON c.customer_id = p.id
                INNER JOIN dbo.payment_method pm ON s.payment_method_id = pm.id
                WHERE s.is_active = 1
                  AND s.created_at BETWEEN @desde AND @hasta
                  {filtroMetodoPago}
                ORDER BY s.created_at DESC
                OFFSET @offset ROWS FETCH NEXT @filas ROWS ONLY;";

            using (var conn = ObtenerConexion())
            {
                conn.Open();

                int totalRegistros;
                using (var cmdConteo = new SqlCommand(queryConteo, conn))
                {
                    cmdConteo.Parameters.Add("@desde", SqlDbType.DateTime2).Value = desde.Date;
                    cmdConteo.Parameters.Add("@hasta", SqlDbType.DateTime2).Value = hastaInclusive;
                    if (metodoPagoId.HasValue)
                    {
                        cmdConteo.Parameters.Add("@payment_method_id", SqlDbType.Int).Value = metodoPagoId.Value;
                    }
                    totalRegistros = (int)cmdConteo.ExecuteScalar();
                }

                totalPaginas = totalRegistros == 0 ? 1 : (int)Math.Ceiling(totalRegistros / (double)filasPorPagina);

                using (var cmdDatos = new SqlCommand(queryDatos, conn))
                {
                    cmdDatos.Parameters.Add("@desde", SqlDbType.DateTime2).Value = desde.Date;
                    cmdDatos.Parameters.Add("@hasta", SqlDbType.DateTime2).Value = hastaInclusive;
                    if (metodoPagoId.HasValue)
                    {
                        cmdDatos.Parameters.Add("@payment_method_id", SqlDbType.Int).Value = metodoPagoId.Value;
                    }
                    cmdDatos.Parameters.Add("@offset", SqlDbType.Int).Value = (pagina - 1) * filasPorPagina;
                    cmdDatos.Parameters.Add("@filas", SqlDbType.Int).Value = filasPorPagina;

                    using (var dr = cmdDatos.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new VentaResumen
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Codigo = dr["code"].ToString(),
                                Fecha = Convert.ToDateTime(dr["created_at"]),
                                NombreCliente = $"{dr["first_name"]} {dr["last_name"]}".Trim(),
                                NombreMetodoPago = dr["metodo_pago"].ToString(),
                                Total = Convert.ToDecimal(dr["total_amount"])
                            });
                        }
                    }
                }
            }

            return lista;
        }

        /// <summary>
        /// Cantidad de ventas activas registradas hoy.
        /// </summary>
        public int ContarVentasHoy()
        {
            DateTime inicioHoy = DateTime.Today;
            DateTime finHoy = inicioHoy.AddDays(1).AddTicks(-1);

            const string query = @"
        SELECT COUNT(*)
        FROM dbo.sale
        WHERE is_active = 1 AND created_at BETWEEN @desde AND @hasta;";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@desde", SqlDbType.DateTime2).Value = inicioHoy;
                cmd.Parameters.Add("@hasta", SqlDbType.DateTime2).Value = finHoy;

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Suma total recaudada hoy en ventas activas.
        /// </summary>
        public decimal ObtenerTotalRecaudadoHoy()
        {
            DateTime inicioHoy = DateTime.Today;
            DateTime finHoy = inicioHoy.AddDays(1).AddTicks(-1);

            const string query = @"
                SELECT ISNULL(SUM(total_amount), 0)
                FROM dbo.sale
                WHERE is_active = 1 AND created_at BETWEEN @desde AND @hasta;";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@desde", SqlDbType.DateTime2).Value = inicioHoy;
                cmd.Parameters.Add("@hasta", SqlDbType.DateTime2).Value = finHoy;

                conn.Open();
                return (decimal)cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Nombre de la categoría que más recaudó hoy. Devuelve "-" si todavía no hubo ventas hoy.
        /// </summary>
        public string ObtenerCategoriaTopHoy()
        {
            DateTime inicioHoy = DateTime.Today;
            DateTime finHoy = inicioHoy.AddDays(1).AddTicks(-1);

            const string query = @"
                SELECT TOP 1 cat.name
                FROM dbo.sale_detail sd
                INNER JOIN dbo.sale s ON sd.sale_id = s.id
                INNER JOIN dbo.product pr ON sd.product_id = pr.id
                INNER JOIN dbo.category cat ON pr.category_id = cat.id
                WHERE s.is_active = 1 AND s.created_at BETWEEN @desde AND @hasta
                GROUP BY cat.name
                ORDER BY SUM(sd.quantity * sd.unit_price) DESC;";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@desde", SqlDbType.DateTime2).Value = inicioHoy;
                cmd.Parameters.Add("@hasta", SqlDbType.DateTime2).Value = finHoy;

                conn.Open();
                var resultado = cmd.ExecuteScalar();
                return resultado?.ToString() ?? "-";
            }
        }

        /// <summary>
        /// Reconstruye el ticket completo de una venta ya registrada, para el botón "Ver" del historial. 
        /// </summary>
        public TicketVenta ObtenerTicketPorVentaId(int ventaId)
        {
            const string queryCabecera = @"
                SELECT 
                    s.code, s.voucher_type, s.created_at, s.total_amount,
                    pCliente.first_name AS cliente_nombre, pCliente.last_name AS cliente_apellido, pCliente.dni AS cliente_dni,
                    pVendedor.first_name AS vendedor_nombre, pVendedor.last_name AS vendedor_apellido,
                    pm.name AS metodo_pago
                FROM dbo.sale s
                INNER JOIN dbo.customer c ON s.customer_id = c.customer_id
                INNER JOIN dbo.person pCliente ON c.customer_id = pCliente.id
                INNER JOIN dbo.[user] u ON s.user_id = u.user_id
                INNER JOIN dbo.person pVendedor ON u.user_id = pVendedor.id
                INNER JOIN dbo.payment_method pm ON s.payment_method_id = pm.id
                WHERE s.id = @sale_id;";

            const string queryDetalle = @"
                SELECT sd.quantity, sd.unit_price, pr.code, pr.name
                FROM dbo.sale_detail sd
                INNER JOIN dbo.product pr ON sd.product_id = pr.id
                WHERE sd.sale_id = @sale_id;";

            TicketVenta ticket = null;

            using (var conn = ObtenerConexion())
            {
                conn.Open();

                using (var cmdCabecera = new SqlCommand(queryCabecera, conn))
                {
                    cmdCabecera.Parameters.Add("@sale_id", SqlDbType.Int).Value = ventaId;

                    using (var dr = cmdCabecera.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ticket = new TicketVenta
                            {
                                Codigo = dr["code"].ToString(),
                                TipoComprobante = Convert.ToChar(dr["voucher_type"]),
                                Fecha = Convert.ToDateTime(dr["created_at"]),
                                Total = Convert.ToDecimal(dr["total_amount"]),
                                NombreCliente = $"{dr["cliente_nombre"]} {dr["cliente_apellido"]}".Trim(),
                                DniCliente = dr["cliente_dni"].ToString(),
                                NombreVendedor = $"{dr["vendedor_nombre"]} {dr["vendedor_apellido"]}".Trim(),
                                NombreMetodoPago = dr["metodo_pago"].ToString()
                            };
                        }
                    }
                }

                if (ticket == null)
                {
                    return null; //venta inexistente o eliminada
                }

                using (var cmdDetalle = new SqlCommand(queryDetalle, conn))
                {
                    cmdDetalle.Parameters.Add("@sale_id", SqlDbType.Int).Value = ventaId;

                    using (var dr = cmdDetalle.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ticket.Detalles.Add(new DetalleVenta
                            {
                                Cantidad = Convert.ToInt32(dr["quantity"]),
                                PrecioUnitario = Convert.ToDecimal(dr["unit_price"]),
                                CodigoProducto = dr["code"].ToString(),
                                NombreProducto = dr["name"].ToString()
                            });
                        }
                    }
                }
            }

            return ticket;
        }

    }
}
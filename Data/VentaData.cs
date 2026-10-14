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

            var dtDetalles = new DataTable();
            dtDetalles.Columns.Add("product_id", typeof(int));
            dtDetalles.Columns.Add("quantity", typeof(int));
            dtDetalles.Columns.Add("unit_price", typeof(decimal));

            foreach (var item in venta.Detalles)
            {
                dtDetalles.Rows.Add(item.ProductoId, item.Cantidad, item.PrecioUnitario);
            }

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand("dbo.sp_Venta_Registrar", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = venta.Total;
                cmd.Parameters.Add("@status", SqlDbType.VarChar, 20).Value = venta.Estado;
                cmd.Parameters.Add("@voucher_type", SqlDbType.Char, 1).Value = venta.TipoComprobante;
                cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = venta.UsuarioId;
                cmd.Parameters.Add("@customer_id", SqlDbType.Int).Value = venta.ClienteId;
                cmd.Parameters.Add("@payment_method_id", SqlDbType.Int).Value = venta.MetodoPagoId;
                
                var paramDetalles = cmd.Parameters.AddWithValue("@detalles", dtDetalles);
                paramDetalles.SqlDbType = SqlDbType.Structured;
                paramDetalles.TypeName = "dbo.Type_DetalleVenta";

                try
                {
                    conn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            int idNuevaVenta = Convert.ToInt32(dr["NuevaVentaId"]);
                            string codigoGenerado = dr["CodigoGenerado"].ToString();

                            if (idNuevaVenta > 0)
                            {
                                venta.Id = idNuevaVenta;
                                venta.Codigo = codigoGenerado; // Asignamos el código generado por SQL
                                
                                mensajeResultado = "Venta registrada exitosamente.";
                                return true;
                            }
                        }
                    }
                    
                    mensajeResultado = "No se pudo registrar la venta.";
                    return false;
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("Stock insuficiente"))
                    {
                        mensajeResultado = "Stock insuficiente para uno o más productos. Operación abortada.";
                    }
                    else
                    {
                        mensajeResultado = $"Error de base de datos: {ex.Message}";
                    }
                    return false;
                }
                catch (Exception exGeneral)
                {
                    mensajeResultado = $"Error imprevisto al procesar la venta: {exGeneral.Message}";
                    return false;
                }
            }
        }

        /// <summary>
        /// Lista ventas activas filtradas por rango de fechas y, opcionalmente, método de pago.
        /// </summary>
        public List<VentaResumen> ObtenerHistorialPaginado(DateTime desde, DateTime hasta, int? metodoPagoId, int pagina, int filasPorPagina, out int totalPaginas, int? vendedorId = null)
        {
            var lista = new List<VentaResumen>();
            DateTime hastaInclusive = hasta.Date.AddDays(1).AddTicks(-1);
            int totalRegistros = 0;

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand("dbo.sp_Ventas_ObtenerHistorial", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("@desde", SqlDbType.DateTime2).Value = desde.Date;
                cmd.Parameters.Add("@hasta", SqlDbType.DateTime2).Value = hastaInclusive;
                cmd.Parameters.Add("@payment_method_id", SqlDbType.Int).Value = (object)metodoPagoId ?? DBNull.Value;
                cmd.Parameters.Add("@pagina", SqlDbType.Int).Value = pagina;
                cmd.Parameters.Add("@filasPorPagina", SqlDbType.Int).Value = filasPorPagina;

                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    // Total de Registros
                    if (dr.Read())
                    {
                        totalRegistros = Convert.ToInt32(dr["TotalRegistros"]);
                    }

                    // Datos Paginados
                    if (dr.NextResult())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new VentaResumen
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Codigo = dr["code"].ToString(),
                                Fecha = Convert.ToDateTime(dr["created_at"]),
                                NombreCliente = $"{dr["cliente_nombre"]} {dr["cliente_apellido"]}".Trim(),
                                NombreVendedor = $"{dr["vendedor_nombre"]} {dr["vendedor_apellido"]}".Trim(),
                                NombreMetodoPago = dr["metodo_pago"].ToString(),
                                Total = Convert.ToDecimal(dr["total_amount"])
                            });
                        }
                    }
                }
            }

            totalPaginas = totalRegistros == 0 ? 1 : (int)Math.Ceiling(totalRegistros / (double)filasPorPagina);
            return lista;
        }

        /// <summary>
        /// Obtiene todas las métricas del dashboard en un solo viaje a la base de datos.
        /// </summary>
        public ResumenDashboardVendedor ObtenerMetricasDashboard(DateTime desde, DateTime hasta, int? metodoPagoId)
        {
            var resumen = new ResumenDashboardVendedor();
            DateTime hastaInclusive = hasta.Date.AddDays(1).AddTicks(-1);

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand("dbo.sp_ObtenerMetricasDashboard", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@desde", SqlDbType.DateTime2).Value = desde.Date;
                cmd.Parameters.Add("@hasta", SqlDbType.DateTime2).Value = hastaInclusive;
                cmd.Parameters.Add("@payment_method_id", SqlDbType.Int).Value = (object)metodoPagoId ?? DBNull.Value;

                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    // Cantidad y Total
                    if (dr.Read())
                    {
                        resumen.CantidadVentas = Convert.ToInt32(dr["Cantidad"]);
                        resumen.TotalRecaudado = Convert.ToDecimal(dr["Total"]);
                    }

                    // Categoría Top
                    if (dr.NextResult() && dr.Read())
                    {
                        resumen.CategoriaTop = dr["CategoriaTop"].ToString();
                    }

                    // Agrupación por Método Pago
                    if (dr.NextResult())
                    {
                        while (dr.Read())
                        {
                            resumen.VentasPorMetodoPago.Add(dr["MetodoPago"].ToString(), Convert.ToDecimal(dr["TotalMetodo"]));
                        }
                    }
                }
            }
            return resumen;
        }

        /// <summary>
        /// Reconstruye el ticket completo de una venta ya registrada, para el botón "Ver" del historial. 
        /// </summary>
        public TicketVenta ObtenerTicketPorVentaId(int ventaId)
        {
            TicketVenta ticket = null;

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand("dbo.sp_Venta_ObtenerTicket", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sale_id", SqlDbType.Int).Value = ventaId;

                conn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    // Cabecera del Ticket
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

                    // Si no existe la venta, abortamos temprano
                    if (ticket == null) return null;

                    // Detalles de Productos
                    if (dr.NextResult())
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
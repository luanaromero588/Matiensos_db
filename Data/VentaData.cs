using Entities;
using System;
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

    }
}
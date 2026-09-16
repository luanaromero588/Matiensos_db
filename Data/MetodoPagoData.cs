using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Data
{
    public class MetodoPagoData : Conexion
    {
        /// <summary>
        /// Lista los métodos de pago activos, para uso de lectura.
        /// </summary>
        public List<MetodoPago> ListarActivos()
        {
            var lista = new List<MetodoPago>();
            const string query = @"
                SELECT id, name, description, is_active
                FROM dbo.payment_method
                WHERE is_active = 1
                ORDER BY name;";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new MetodoPago
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Nombre = dr["name"].ToString(),
                            Descripcion = dr["description"] != DBNull.Value ? dr["description"].ToString() : string.Empty,
                            Activo = Convert.ToBoolean(dr["is_active"])
                        });
                    }
                }
            }
            return lista;
        }
    }
}
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
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

            // Insertar nuevo método de pago
            public bool Insertar(string nombre, string descripcion)
            {
                const string query = @"
            INSERT INTO [dbo].[payment_method] (name, description, is_active, created_by, created_at)
            VALUES (@name, @description, 1, @created_by, GETDATE());";

                using (var conn = ObtenerConexion())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", nombre.Trim());
                    cmd.Parameters.AddWithValue("@description", string.IsNullOrWhiteSpace(descripcion) ? (object)DBNull.Value : descripcion.Trim());

                    int usuarioId = Sesion.UsuarioId > 0 ? Sesion.UsuarioId : 1;
                    cmd.Parameters.AddWithValue("@created_by", usuarioId);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }

            // Modificar existente
            public bool Modificar(int id, string nombre, string descripcion)
            {
                const string query = @"
            UPDATE [dbo].[payment_method]
            SET name = @name,
                description = @description,
                updated_by = @updated_by,
                updated_at = GETDATE()
            WHERE payment_method_id = @id;";

                using (var conn = ObtenerConexion())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", nombre.Trim());
                    cmd.Parameters.AddWithValue("@description", string.IsNullOrWhiteSpace(descripcion) ? (object)DBNull.Value : descripcion.Trim());

                    int usuarioId = Sesion.UsuarioId > 0 ? Sesion.UsuarioId : 1;
                    cmd.Parameters.AddWithValue("@updated_by", usuarioId);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }

            // Baja / Reactivación lógica
            public bool CambiarEstado(int id, bool nuevoEstado)
            {
                const string query = @"
            UPDATE [dbo].[payment_method]
            SET is_active = @estado,
                updated_by = @updated_by,
                updated_at = GETDATE()
            WHERE payment_method_id = @id;";

                using (var conn = ObtenerConexion())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@estado", nuevoEstado);

                    int usuarioId = Sesion.UsuarioId > 0 ? Sesion.UsuarioId : 1;
                    cmd.Parameters.AddWithValue("@updated_by", usuarioId);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
       
    }
}
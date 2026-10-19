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
        public List<MetodoPago> ListarTodos()
        {
            var lista = new List<MetodoPago>();
            const string query = @"
                SELECT id, name, description, is_active
                FROM dbo.payment_method
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

        public MetodoPago ObtenerPorId(int id)
        {
            const string query = @"
                SELECT id, name, description, is_active
                FROM dbo.payment_method
                WHERE id = @id;";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new MetodoPago
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Nombre = dr["name"].ToString(),
                            Descripcion = dr["description"] != DBNull.Value ? dr["description"].ToString() : string.Empty,
                            Activo = Convert.ToBoolean(dr["is_active"])
                        };
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Insertar nuevo método de pago
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Modificar existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        public bool Modificar(int id, string nombre, string descripcion)
            {
                const string query = @"
            UPDATE [dbo].[payment_method]
            SET name = @name,
                description = @description,
                updated_by = @updated_by,
                updated_at = GETDATE()
            WHERE id = @id;";

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

        /// <summary>
        /// Baja / Reactivación lógica
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nuevoEstado"></param>
        /// <returns></returns>
        public bool CambiarEstado(int id, bool nuevoEstado)
            {
                const string query = @"
            UPDATE [dbo].[payment_method]
            SET is_active = @estado,
                updated_by = @updated_by,
                updated_at = GETDATE()
            WHERE id = @id;";

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

        /// <summary>
        /// Verifica si ya existe un método de pago con el nombre especificado (insensible a mayúsculas/minúsculas).
        /// Permite excluir un ID para escenarios de modificación.
        /// </summary>
        public bool ExisteNombre(string nombre, int idExcluir = 0)
            {
                const string query = @"
                SELECT COUNT(1) 
                FROM [dbo].[payment_method] 
                WHERE LOWER(LTRIM(RTRIM(name))) = LOWER(LTRIM(RTRIM(@name)))
                  AND (@idExcluir = 0 OR id != @idExcluir);";

                using (var conn = ObtenerConexion())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = nombre.Trim();
                    cmd.Parameters.Add("@idExcluir", SqlDbType.Int).Value = idExcluir;

                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }

        /// <summary>
        /// Obtiene el total de métodos de pago activos en el sistema.
        /// </summary>
        public int ContarTotalActivos()
            {
                const string query = "SELECT COUNT(1) FROM [dbo].[payment_method] WHERE is_active = 1;";

                using (var conn = ObtenerConexion())
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

        /// <summary>
        /// Obtiene el nombre del método de pago con mayor recaudación histórica acumulada.
        /// </summary>
        public string ObtenerMetodoMasIngresos()
            {
                string nombre = "-";
                const string query = @"
                SELECT TOP 1 pm.name
                FROM [dbo].[sale] s
                INNER JOIN [dbo].[payment_method] pm ON s.payment_method_id = pm.id
                WHERE s.is_active = 1 AND pm.is_active = 1
                GROUP BY pm.id, pm.name
                ORDER BY SUM(s.total_amount) DESC;";

                using (var conn = ObtenerConexion())
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    object resultado = cmd.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        nombre = resultado.ToString();
                    }
                }
                return nombre;
            }

        /// <summary>
        /// Obtiene el nombre del método de pago con menor recaudación histórica acumulada.
        /// </summary>
        public string ObtenerMetodoMenosIngresos()
            {
                string nombre = "-";
                const string query = @"
                SELECT TOP 1 pm.name
                FROM [dbo].[sale] s
                INNER JOIN [dbo].[payment_method] pm ON s.payment_method_id = pm.id
                WHERE s.is_active = 1 AND pm.is_active = 1
                GROUP BY pm.id, pm.name
                ORDER BY SUM(s.total_amount) ASC;";

                using (var conn = ObtenerConexion())
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    object resultado = cmd.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        nombre = resultado.ToString();
                    }
                }
                return nombre;
            }
    }
}
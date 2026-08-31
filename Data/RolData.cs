using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entities;

namespace Data
{
    public class RolData : Conexion
    {
        // Método que devuelve la lista de roles desde la base de datos
        public List<Rol> ListarRoles()
        {
            List<Rol> lista = new List<Rol>();
            string query = "SELECT id, nombre, descripcion, esta_activo FROM rol WHERE esta_activo = 1";

            // 1. Obtener la conexión usando el método de Conexion.cs
            using (SqlConnection conexion = ObtenerConexion())
            {
                // 2. Preparar el comando SQL
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    conexion.Open(); // Abrir el canal hacia Docker

                    // 3. Ejecutar la lectura de filas
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // 4. Recorrer fila por fila lo que devolvió la base
                        while (reader.Read())
                        {
                            Rol rol = new Rol
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nombre = reader["nombre"].ToString(),
                                Descripcion = reader["descripcion"] != DBNull.Value ? reader["descripcion"].ToString() : string.Empty,
                                EstaActivo = Convert.ToBoolean(reader["esta_activo"])
                            };

                            lista.Add(rol);
                        }
                    }
                }
            }

            return lista;
        }
    }
}
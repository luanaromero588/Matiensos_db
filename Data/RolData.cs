using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entities;

namespace Data
{
    // Hereda de Conexion para centralizar la cadena de conexion
    public class RolData : Conexion
    {
        // Metodo que devuelve la lista de roles desde la base de datos
        public List<Rol> ListarRoles()
        {
            List<Rol> lista = new List<Rol>();
            string query = @"SELECT id, name, description, is_active 
                             FROM [role] 
                             WHERE is_active = 1 AND name != 'SuperAdmin'
                             ORDER BY name ASC";

            // 1. Obtener la conexion usando el metodo de Conexion.cs
            using (SqlConnection conexion = ObtenerConexion())
            {
                // 2. Preparar el comando SQL
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    conexion.Open(); // Abrir el canal hacia Docker

                    // 3. Ejecutar la lectura de filas
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // 4. Recorrer fila por fila lo que devolvio la base
                        while (reader.Read())
                        {
                            Rol rol = new Rol
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nombre = reader["name"].ToString(),
                                Descripcion = reader["description"] != DBNull.Value ? reader["description"].ToString() : string.Empty,
                                EstaActivo = Convert.ToBoolean(reader["is_active"])
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
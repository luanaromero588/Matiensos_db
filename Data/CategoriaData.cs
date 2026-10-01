using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Data
{
    public class CategoriaData : Conexion
    {
        /// <summary>
        /// Lista las categorías activas.
        /// </summary>
        public List<Categoria> ListarActivas()
        {
            var lista = new List<Categoria>();
            const string query = "SELECT id, code, name, description FROM dbo.category WHERE is_active = 1 ORDER BY name;";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Categoria
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Codigo = dr["code"].ToString(),
                            Nombre = dr["name"].ToString(),
                            Descripcion = dr["description"] != DBNull.Value ? dr["description"].ToString() : string.Empty
                        });
                    }
                }
            }
            return lista;
        }
    }
}
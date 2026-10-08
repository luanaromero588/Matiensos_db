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

        /// <summary>
        /// Obtiene las categorías junto con el conteo de productos y stock total acumulado para la grilla.
        /// </summary>
        public List<CategoriaListadoDto> ListarParaGrilla()
        {
            var lista = new List<CategoriaListadoDto>();

            const string query = @"
        SELECT 
            c.id,
            c.code,
            c.name,
            c.description,
            COUNT(p.id) AS cantidad_productos,
            ISNULL(SUM(p.stock), 0) AS stock_total,
            CASE WHEN c.is_active = 1 THEN 'Activo' ELSE 'Inactivo' END AS estado
        FROM [dbo].[category] c
        LEFT JOIN [dbo].[product] p 
               ON c.id = p.category_id AND p.is_active = 1
        WHERE c.is_active = 1
        GROUP BY c.id, c.code, c.name, c.description, c.is_active
        ORDER BY c.name;";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new CategoriaListadoDto
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Codigo = dr["code"].ToString(),
                            Nombre = dr["name"].ToString(),
                            Descripcion = dr["description"] != DBNull.Value ? dr["description"].ToString() : string.Empty,
                            CantidadProductos = Convert.ToInt32(dr["cantidad_productos"]),
                            StockTotal = Convert.ToInt32(dr["stock_total"]),
                            Estado = dr["estado"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
    }
}
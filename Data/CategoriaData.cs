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

        /// Cambia el estado de la categoría (Activar o Desactivar)
        public bool CambiarEstado(int id, bool activar)
        {
            const string query = @"
        UPDATE [dbo].[category] 
        SET is_active = @is_active,
            updated_at = GETDATE(),
            deleted_at = CASE WHEN @is_active = 0 THEN GETDATE() ELSE NULL END
        WHERE id = @id;";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@is_active", activar ? 1 : 0);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool DarBajaLogica(int id)
        {
            const string query = @"
        UPDATE [dbo].[category]
        SET is_active = 0,
            deleted_at = GETDATE()
        WHERE id = @id;";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //boton editar de la grilla, actualiza el nombre y la descripción de la categoría
        public bool Actualizar(int id, string nombre, string descripcion)
        {
            const string query = @"
        UPDATE [dbo].[category]
        SET name = @name,
            description = @description,
            updated_at = GETDATE()
        WHERE id = @id;";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", nombre.Trim());
                cmd.Parameters.AddWithValue("@description", string.IsNullOrWhiteSpace(descripcion) ? (object)DBNull.Value : descripcion.Trim());

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}
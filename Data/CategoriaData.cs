using Entities;
using System;
using System.Collections.Generic;
using System.Data;
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

        // Botón agregar categoría modal
        public bool Insertar(string codigo, string nombre, string descripcion)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();

                string codigoFinal = codigo?.Trim().ToUpper();

                // Si no se proporcionó código, generar uno automáticamente a partir del nombre
                if (string.IsNullOrWhiteSpace(codigoFinal))
                {
                    string limpio = System.Text.RegularExpressions.Regex.Replace(nombre.Trim(), @"[^a-zA-Z0-9]", "").ToUpper();
                    if (string.IsNullOrEmpty(limpio)) limpio = "CATG";
                    string base4 = limpio.Length >= 4 ? limpio.Substring(0, 4) : limpio.PadRight(4, 'X');
                    codigoFinal = base4;
                    int secuencia = 1;

                    while (ExisteCodigo(codigoFinal, conn))
                    {
                        if (secuencia < 10)
                        {
                            codigoFinal = $"{base4.Substring(0, 3)}{secuencia}";
                        }
                        else
                        {
                            codigoFinal = $"{base4.Substring(0, 2)}{secuencia}";
                        }
                        secuencia++;
                    }
                }

                // Insertar respetando CHAR(4)
                const string query = @"
                    INSERT INTO [dbo].[category] (code, name, description, is_active, created_by, created_at)
                    VALUES (@code, @name, @description, 1, @created_by, GETDATE());";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@code", SqlDbType.Char, 4).Value = codigoFinal;
                    cmd.Parameters.AddWithValue("@name", nombre.Trim());
                    cmd.Parameters.AddWithValue("@description", string.IsNullOrWhiteSpace(descripcion) ? (object)DBNull.Value : descripcion.Trim());

                    int idUsuario = Sesion.UsuarioId > 0 ? Sesion.UsuarioId : 1;
                    cmd.Parameters.AddWithValue("@created_by", idUsuario);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Insertar(string nombre, string descripcion)
        {
            return Insertar(null, nombre, descripcion);
        }

        public bool ExisteCodigo(string codigo)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                return ExisteCodigo(codigo, conn);
            }
        }

        private bool ExisteCodigo(string codigo, SqlConnection conn)
        {
            const string query = "SELECT COUNT(1) FROM [dbo].[category] WHERE code = @code;";
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@code", SqlDbType.Char, 4).Value = codigo;
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public int ContarTotalCategorias()
        {
            int total = 0;
            string query = "SELECT COUNT(1) FROM category WHERE is_active = 1;";

            using (var conn = ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    total = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return total;
        }

        public string ObtenerCategoriaMasVendida()
        {
            string nombreCategoria = "-";

            // Consulta que suma las cantidades vendidas por categoría y se queda con la primera
            string query = @"
                SELECT TOP 1 c.name
                FROM sale_detail sd
                INNER JOIN product p ON sd.product_id = p.id
                INNER JOIN category c ON p.category_id = c.id
                WHERE c.is_Active = 1
                GROUP BY c.id, c.name
                ORDER BY SUM(sd.quantity) DESC;";

            using (var conn = ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    object resultado = cmd.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        nombreCategoria = resultado.ToString();
                    }
                }
            }

            return nombreCategoria;
        }

        public string ObtenerCategoriaMenosVendida()
        {
            string nombreCategoria = "-";
            string query = @"
                SELECT TOP 1 c.name
                FROM sale_detail sd
                INNER JOIN product p ON sd.product_id = p.id
                INNER JOIN category c ON p.category_id = c.id
                WHERE c.is_active = 1
                GROUP BY c.id, c.name
                ORDER BY SUM(sd.quantity) ASC;";

            using (var conn = ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    object resultado = cmd.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        nombreCategoria = resultado.ToString();
                    }
                }
            }

            return nombreCategoria;
        }

        /// <summary>
        /// Obtiene solo el nombre de la categoría (escalar), ideal para auditorías de alto rendimiento.
        /// </summary>
        public string ObtenerNombrePorId(int id)
        {
            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand("SELECT name FROM dbo.category WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                var result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : $"ID {id}";
            }
        }

        public Categoria ObtenerCategoriaPorId(int id)
        {
            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand("SELECT id, code, name, description FROM dbo.category WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new Categoria
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Codigo = dr["code"].ToString(),
                            Nombre = dr["name"].ToString(),
                            Descripcion = dr["description"] != DBNull.Value ? dr["description"].ToString() : string.Empty
                        };
                    }
                }
            }
            return null;
        }
    }
}
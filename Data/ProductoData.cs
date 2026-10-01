using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class ProductoData : Conexion
    {
        /// <summary>
        /// Lista todos los productos activos que tienen stock disponible.
        /// </summary>
        /// <returns></returns>
        public List<Producto> ListarActivosConStock()
        {
            var lista = new List<Producto>();
            const string query = @"SELECT p.id, p.code, p.name, p.description, p.price, p.stock, 
                                    p.minimum_stock, p.category_id, c.name AS category_name, p.is_active 
                                FROM dbo.product p
                                INNER JOIN dbo.category c ON p.category_id = c.id
                                WHERE p.is_active = 1";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Producto
                        {
                            Id = reader.GetInt32(0),
                            Codigo = reader.GetString(1),
                            Nombre = reader.GetString(2),
                            CategoriaNombre = reader.GetString(8),
                            Precio = reader.GetDecimal(4),
                            Stock = reader.GetInt32(5)
                            
                        });
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// Obtiene una página de productos activos, filtrando opcionalmente por nombre o código.
        /// </summary>
        public List<Producto> ObtenerProductosPaginados(string busqueda, int pagina, int filasPorPagina, out int totalPaginas)
        {
            var lista = new List<Producto>();
            string filtroBusqueda = string.IsNullOrWhiteSpace(busqueda) ? "" : "AND (p.name LIKE @busqueda OR p.code LIKE @busqueda)";

            string queryConteo = $@"
                SELECT COUNT(*)
                FROM dbo.product p
                WHERE p.is_active = 1 {filtroBusqueda};";

            string queryDatos = $@"
                SELECT p.id, p.code, p.name, p.description, p.price, p.stock, 
                       p.minimum_stock, p.category_id, c.name AS category_name, p.is_active 
                FROM dbo.product p
                INNER JOIN dbo.category c ON p.category_id = c.id
                WHERE p.is_active = 1 {filtroBusqueda}
                ORDER BY p.name ASC
                OFFSET @offset ROWS FETCH NEXT @filas ROWS ONLY;";

            using (var conn = ObtenerConexion())
            {
                conn.Open();

                // 1. Conteo total para calcular las páginas
                int totalRegistros;
                using (var cmdConteo = new SqlCommand(queryConteo, conn))
                {
                    if (!string.IsNullOrWhiteSpace(busqueda))
                        cmdConteo.Parameters.Add("@busqueda", SqlDbType.VarChar).Value = $"%{busqueda}%";

                    totalRegistros = (int)cmdConteo.ExecuteScalar();
                }

                totalPaginas = totalRegistros == 0 ? 1 : (int)Math.Ceiling(totalRegistros / (double)filasPorPagina);

                // 2. Extracción de los datos paginados
                using (var cmdDatos = new SqlCommand(queryDatos, conn))
                {
                    if (!string.IsNullOrWhiteSpace(busqueda))
                        cmdDatos.Parameters.Add("@busqueda", SqlDbType.VarChar).Value = $"%{busqueda}%";

                    cmdDatos.Parameters.Add("@offset", SqlDbType.Int).Value = (pagina - 1) * filasPorPagina;
                    cmdDatos.Parameters.Add("@filas", SqlDbType.Int).Value = filasPorPagina;

                    using (var reader = cmdDatos.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Producto
                            {
                                Id = reader.GetInt32(0),
                                Codigo = reader.GetString(1),
                                Nombre = reader.GetString(2),
                                Descripcion = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                Precio = reader.GetDecimal(4),
                                Stock = reader.GetInt32(5),
                                StockMinimo = reader.GetInt32(6),
                                CategoriaId = reader.GetInt32(7),
                                CategoriaNombre = reader.GetString(8),
                                Activo = reader.GetBoolean(9)
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
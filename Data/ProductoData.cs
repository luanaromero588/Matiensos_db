using Entities;
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
    }
}
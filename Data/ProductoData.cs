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
            const string query = @"
                SELECT id, code, name, price, stock 
                FROM dbo.product 
                WHERE is_active = 1 AND stock > 0
                ORDER BY name ASC;";

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
                            Precio = reader.GetDecimal(3),
                            Stock = reader.GetInt32(4)
                        });
                    }
                }
            }
            return lista;
        }
    }
}
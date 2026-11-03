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

        /// <summary>
        /// Obtiene una página de productos para gestión administrativa: incluye tanto
        /// activos como inactivos.
        /// </summary>
        public List<Producto> ObtenerProductosPaginadosAdmin(string busqueda, int? categoriaId, bool? soloActivos, string filtroStock, int pagina, int filasPorPagina, out int totalPaginas)
        {
            var lista = new List<Producto>();

            string filtroBusqueda = string.IsNullOrWhiteSpace(busqueda) ? "" : "AND (p.name LIKE @busqueda OR p.code LIKE @busqueda)";
            string filtroCategoria = categoriaId.HasValue ? "AND p.category_id = @category_id" : "";
            string filtroEstado = soloActivos.HasValue ? "AND p.is_active = @is_active" : "";

            string filtroStockSql;
            switch (filtroStock)
            {
                case "SinStock":
                    filtroStockSql = "AND p.stock = 0";
                    break;
                case "Critico":
                    filtroStockSql = "AND p.stock > 0 AND p.stock <= p.minimum_stock";
                    break;
                default:
                    filtroStockSql = "";
                    break;
            }

            string queryConteo = $@"
                SELECT COUNT(*)
                FROM dbo.product p
                WHERE 1 = 1 {filtroBusqueda} {filtroCategoria} {filtroEstado} {filtroStockSql};";

            string queryDatos = $@"
                SELECT p.id, p.code, p.name, p.description, p.price, p.stock, 
                       p.minimum_stock, p.category_id, c.name AS category_name, p.is_active 
                FROM dbo.product p
                INNER JOIN dbo.category c ON p.category_id = c.id
                WHERE 1 = 1 {filtroBusqueda} {filtroCategoria} {filtroEstado} {filtroStockSql}
                ORDER BY p.name ASC
                OFFSET @offset ROWS FETCH NEXT @filas ROWS ONLY;";

            using (var conn = ObtenerConexion())
            {
                conn.Open();

                int totalRegistros;
                using (var cmdConteo = new SqlCommand(queryConteo, conn))
                {
                    AgregarParametrosFiltro(cmdConteo, busqueda, categoriaId, soloActivos);
                    totalRegistros = (int)cmdConteo.ExecuteScalar();
                }

                totalPaginas = totalRegistros == 0 ? 1 : (int)Math.Ceiling(totalRegistros / (double)filasPorPagina);

                using (var cmdDatos = new SqlCommand(queryDatos, conn))
                {
                    AgregarParametrosFiltro(cmdDatos, busqueda, categoriaId, soloActivos);
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

        /// <summary>
        /// Obtiene un producto específico por su ID. Retorna null si no lo encuentra.
        /// </summary>
        public Producto ObtenerProductoPorId(int id)
        {
            const string query = @"
                SELECT p.id, p.code, p.name, p.description, p.price, p.stock, 
                       p.minimum_stock, p.category_id, c.name AS category_name, p.is_active 
                FROM dbo.product p
                INNER JOIN dbo.category c ON p.category_id = c.id
                WHERE p.id = @id;";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Producto
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
                        };
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Actualiza nombre, precio, stock y categoría de un producto existente.
        /// Si el stock queda en 0, el producto pasa a inactivo automáticamente.
        /// </summary>
        public bool ActualizarProducto(Producto producto, int usuarioOperadorId, out string mensajeResultado)
        {
            mensajeResultado = string.Empty;

            bool quedaSinStock = producto.Stock <= 0;

            const string query = @"
                UPDATE dbo.product
                SET name = @name,
                    price = @price,
                    stock = @stock,
                    minimum_stock = @minimum_stock,
                    category_id = @category_id,
                    is_active = CASE WHEN @stock <= 0 THEN 0 ELSE is_active END,
                    updated_at = GETDATE(),
                    updated_by = @updated_by
                WHERE id = @id;";

            try
            {
                using (var conn = ObtenerConexion())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = producto.Nombre;
                    cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = producto.Precio;
                    cmd.Parameters.Add("@stock", SqlDbType.Int).Value = producto.Stock;
                    cmd.Parameters.Add("@minimum_stock", SqlDbType.Int).Value = producto.StockMinimo;
                    cmd.Parameters.Add("@category_id", SqlDbType.Int).Value = producto.CategoriaId;
                    cmd.Parameters.Add("@updated_by", SqlDbType.Int).Value = usuarioOperadorId;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = producto.Id;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                mensajeResultado = quedaSinStock
                    ? "Producto actualizado. Se desactivó automáticamente por quedar sin stock."
                    : "Producto actualizado correctamente.";
                return true;
            }
            catch (SqlException exSql)
            {
                mensajeResultado = $"Error de base de datos al actualizar: Código {exSql.Number}.";
                return false;
            }
        }

        /// <summary>
        /// Da de baja lógica un producto (botón Eliminar).
        /// </summary>
        public bool DesactivarProducto(int productoId, int usuarioOperadorId, out string mensajeResultado)
        {
            mensajeResultado = string.Empty;
            const string query = @"
                UPDATE dbo.product
                SET is_active = 0, deleted_at = GETDATE(), deleted_by = @deleted_by
                WHERE id = @id;";

            try
            {
                using (var conn = ObtenerConexion())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@deleted_by", SqlDbType.Int).Value = usuarioOperadorId;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = productoId;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                mensajeResultado = "Producto desactivado correctamente.";
                return true;
            }
            catch (SqlException exSql)
            {
                mensajeResultado = $"Error de base de datos al desactivar: Código {exSql.Number}.";
                return false;
            }
        }

        /// <summary>
        /// Reactiva un producto, solo si tiene stock disponible.
        /// </summary>
        public bool ReactivarProducto(int productoId, int usuarioOperadorId, out string mensajeResultado)
        {
            mensajeResultado = string.Empty;

            const string queryStock = "SELECT stock FROM dbo.product WHERE id = @id;";
            const string queryActivar = @"
                UPDATE dbo.product
                SET is_active = 1, deleted_at = NULL, deleted_by = NULL, updated_at = GETDATE(), updated_by = @updated_by
                WHERE id = @id;";

            using (var conn = ObtenerConexion())
            {
                conn.Open();

                int stockActual;
                using (var cmdStock = new SqlCommand(queryStock, conn))
                {
                    cmdStock.Parameters.Add("@id", SqlDbType.Int).Value = productoId;
                    var resultado = cmdStock.ExecuteScalar();
                    if (resultado == null)
                    {
                        mensajeResultado = "El producto no existe.";
                        return false;
                    }
                    stockActual = Convert.ToInt32(resultado);
                }

                if (stockActual <= 0)
                {
                    mensajeResultado = "No se puede activar un producto sin stock. Cargue stock primero.";
                    return false;
                }

                using (var cmdActivar = new SqlCommand(queryActivar, conn))
                {
                    cmdActivar.Parameters.Add("@updated_by", SqlDbType.Int).Value = usuarioOperadorId;
                    cmdActivar.Parameters.Add("@id", SqlDbType.Int).Value = productoId;
                    cmdActivar.ExecuteNonQuery();
                }
            }

            mensajeResultado = "Producto reactivado correctamente.";
            return true;
        }

        /// <summary>
        /// Cantidad de productos, respetando los filtros activos (categoría, estado, texto).
        /// </summary>
        public int ContarProductosActivos(string busqueda, int? categoriaId, bool? soloActivos)
        {
            string filtroBusqueda = string.IsNullOrWhiteSpace(busqueda) ? "" : "AND (p.name LIKE @busqueda OR p.code LIKE @busqueda)";
            string filtroCategoria = categoriaId.HasValue ? "AND p.category_id = @category_id" : "";
            string filtroEstado = soloActivos.HasValue ? "AND p.is_active = @is_active" : "AND p.is_active = 1";

            string query = $@"SELECT COUNT(*) FROM dbo.product p WHERE 1 = 1 {filtroBusqueda} {filtroCategoria} {filtroEstado};";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                AgregarParametrosFiltro(cmd, busqueda, categoriaId, soloActivos);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }


        /// <summary>
        /// Cantidad de productos sin stock, respetando los filtros activos.
        /// </summary>
        public int ContarProductosSinStock(string busqueda, int? categoriaId, bool? soloActivos)
        {
            string filtroBusqueda = string.IsNullOrWhiteSpace(busqueda) ? "" : "AND (p.name LIKE @busqueda OR p.code LIKE @busqueda)";
            string filtroCategoria = categoriaId.HasValue ? "AND p.category_id = @category_id" : "";
            string filtroEstado = soloActivos.HasValue ? "AND p.is_active = @is_active" : "";

            string query = $@"SELECT COUNT(*) FROM dbo.product p WHERE p.stock = 0 {filtroBusqueda} {filtroCategoria} {filtroEstado};";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                AgregarParametrosFiltro(cmd, busqueda, categoriaId, soloActivos);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Cantidad de productos en stock crítico, respetando los filtros activos.
        /// </summary>
        public int ContarProductosStockCritico(string busqueda, int? categoriaId, bool? soloActivos)
        {
            string filtroBusqueda = string.IsNullOrWhiteSpace(busqueda) ? "" : "AND (p.name LIKE @busqueda OR p.code LIKE @busqueda)";
            string filtroCategoria = categoriaId.HasValue ? "AND p.category_id = @category_id" : "";
            string filtroEstado = soloActivos.HasValue ? "AND p.is_active = @is_active" : "AND p.is_active = 1";

            string query = $@"SELECT COUNT(*) FROM dbo.product p WHERE p.stock > 0 AND p.stock <= p.minimum_stock {filtroBusqueda} {filtroCategoria} {filtroEstado};";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                AgregarParametrosFiltro(cmd, busqueda, categoriaId, soloActivos);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Valor total del inventario, respetando los filtros activos.
        /// </summary>
        public decimal ObtenerValorInventario(string busqueda, int? categoriaId, bool? soloActivos)
        {
            string filtroBusqueda = string.IsNullOrWhiteSpace(busqueda) ? "" : "AND (p.name LIKE @busqueda OR p.code LIKE @busqueda)";
            string filtroCategoria = categoriaId.HasValue ? "AND p.category_id = @category_id" : "";
            string filtroEstado = soloActivos.HasValue ? "AND p.is_active = @is_active" : "AND p.is_active = 1";

            string query = $@"SELECT ISNULL(SUM(p.stock * p.price), 0) FROM dbo.product p WHERE 1 = 1 {filtroBusqueda} {filtroCategoria} {filtroEstado};";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                AgregarParametrosFiltro(cmd, busqueda, categoriaId, soloActivos);
                conn.Open();
                return (decimal)cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Inserta un nuevo producto en la base de datos.
        /// </summary>
        public bool RegistrarProducto(Producto producto, int usuarioOperadorId, out string mensajeResultado)
        {
            mensajeResultado = string.Empty;

            const string query = @"
        INSERT INTO dbo.product (code, name, description, price, stock, minimum_stock, category_id, is_active, created_at, created_by)
        VALUES (@code, @name, @description, @price, @stock, @minimum_stock, @category_id, 1, GETDATE(), @created_by);";

            try
            {
                using (var conn = ObtenerConexion())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@code", SqlDbType.VarChar, 50).Value = producto.Codigo;
                    cmd.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = producto.Nombre;
                    cmd.Parameters.Add("@description", SqlDbType.VarChar, 255).Value = string.IsNullOrWhiteSpace(producto.Descripcion)
                        ? (object)DBNull.Value
                        : producto.Descripcion;
                    cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = producto.Precio;
                    cmd.Parameters.Add("@stock", SqlDbType.Int).Value = producto.Stock;
                    cmd.Parameters.Add("@minimum_stock", SqlDbType.Int).Value = producto.StockMinimo;
                    cmd.Parameters.Add("@category_id", SqlDbType.Int).Value = producto.CategoriaId;
                    cmd.Parameters.Add("@created_by", SqlDbType.Int).Value = usuarioOperadorId;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                mensajeResultado = "Producto registrado correctamente.";
                return true;
            }
            catch (SqlException exSql)
            {
                // 2627 o 2601 corresponden a violación de Unique Key (código repetido)
                if (exSql.Number == 2627 || exSql.Number == 2601)
                {
                    mensajeResultado = "Ya existe un producto con ese código.";
                }
                else
                {
                    mensajeResultado = $"Error de base de datos al registrar: Código {exSql.Number}.";
                }
                return false;
            }
            catch (Exception ex)
            {
                mensajeResultado = $"Error inesperado: {ex.Message}";
                return false;
            }
        }
        /// <summary>
        /// Agrega los parámetros compartidos entre la query de conteo y la de datos, evitando repetir el bloque en los dos lugares.
        /// </summary>
        private void AgregarParametrosFiltro(SqlCommand cmd, string busqueda, int? categoriaId, bool? soloActivos)
        {
            if (!string.IsNullOrWhiteSpace(busqueda))
                cmd.Parameters.Add("@busqueda", SqlDbType.VarChar).Value = $"%{busqueda}%";

            if (categoriaId.HasValue)
                cmd.Parameters.Add("@category_id", SqlDbType.Int).Value = categoriaId.Value;

            if (soloActivos.HasValue)
                cmd.Parameters.Add("@is_active", SqlDbType.Bit).Value = soloActivos.Value;
        }

        /// <summary>
        /// Verifica si ya existe un producto con el código especificado.
        /// </summary>
        public bool ExisteCodigo(string codigo)
        {
            const string query = "SELECT COUNT(1) FROM dbo.product WHERE code = @code;";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@code", SqlDbType.VarChar, 50).Value = codigo;
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }
}
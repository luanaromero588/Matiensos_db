using Data;
using Entities;
using System;
using System.Collections.Generic;

namespace Business
{
    public class ProductoBusiness
    {
        private readonly ProductoData productoData = new ProductoData();
        private const int FILAS_POR_PAGINA_PRODUCTOS = 15;

        /// <summary>
        /// Obtiene una lista de productos activos con stock disponible.
        /// </summary>
        /// <returns></returns>
        public List<Producto> ObtenerProductosConStock()
        {
            return productoData.ListarActivosConStock();
        }

        /// <summary>
        /// Obtiene el listado de productos paginado y filtrado.
        /// </summary>
        public List<Producto> ObtenerProductosPaginados(string busqueda, int pagina, out int totalPaginas, out string mensajeError)
        {
            mensajeError = string.Empty;
            int paginaValida = pagina < 1 ? 1 : pagina;

            try
            {
                return productoData.ObtenerProductosPaginados(busqueda, paginaValida, FILAS_POR_PAGINA_PRODUCTOS, out totalPaginas);
            }
            catch (Exception ex)
            {
                totalPaginas = 1;
                mensajeError = $"Error al obtener el catálogo de productos: {ex.Message}";
                return new List<Producto>();
            }
        }

        /// <summary>
        /// Obtiene el listado de productos paginado y filtrado para administración.
        /// </summary>
        /// <param name="busqueda"></param>
        /// <param name="pagina"></param>
        /// <param name="totalPaginas"></param>
        /// <param name="mensajeError"></param>
        /// <returns></returns>
        public List<Producto> ObtenerProductosPaginadosAdmin(string busqueda, int? categoriaId, bool? soloActivos, string filtroStock, int pagina, out int totalPaginas, out string mensajeError)
        {
            mensajeError = string.Empty;
            int paginaValida = pagina < 1 ? 1 : pagina;
            return productoData.ObtenerProductosPaginadosAdmin(busqueda, categoriaId, soloActivos, filtroStock, paginaValida, FILAS_POR_PAGINA_PRODUCTOS, out totalPaginas);
        }

        /// <summary>
        /// Verifica si ya existe un producto con el código especificado.
        /// </summary>
        public bool ExisteCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return false;
            return productoData.ExisteCodigo(codigo.Trim());
        }

        /// <summary>
        /// Registra un nuevo producto en el sistema.
        /// Audita la acción si se realiza con éxito.
        /// </summary>
        public bool RegistrarProducto(Producto producto, out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(producto.Codigo))
            {
                mensaje = "El código del producto es obligatorio.";
                return false;
            }

            if (ExisteCodigo(producto.Codigo))
            {
                mensaje = "El código ya está registrado.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                mensaje = "El nombre del producto no puede estar vacío.";
                return false;
            }

            if (producto.CategoriaId <= 0)
            {
                mensaje = "Debe seleccionar una categoría válida.";
                return false;
            }

            if (producto.Precio < 0)
            {
                mensaje = "El precio no puede ser negativo.";
                return false;
            }

            if (producto.Stock < 0)
            {
                mensaje = "El stock no puede ser negativo.";
                return false;
            }

            if (producto.StockMinimo < 0)
            {
                mensaje = "El stock mínimo no puede ser negativo.";
                return false;
            }

            bool exito = productoData.RegistrarProducto(producto, Sesion.UsuarioId, out mensaje);

            if (exito)
            {
                AuditoriaBusiness.RegistrarEvento(
                    "Producto",
                    "Alta",
                    $"CÓDIGO: [{producto.Codigo}], " +
                    $"NOMBRE: '{producto.Nombre}', " +
                    $"DESCRIPCION: {producto.Descripcion}, " +
                    $"PRECIO: {producto.Precio}, " +
                    $"STOCK: {producto.Stock}, STOCK MIN: {producto.StockMinimo}"
                );
            }

            return exito;
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public bool ActualizarProducto(Producto producto, out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                mensaje = "El nombre del producto no puede estar vacío.";
                return false;
            }

            if (producto.Precio < 0)
            {
                mensaje = "El precio no puede ser negativo.";
                return false;
            }

            if (producto.Stock < 0)
            {
                mensaje = "El stock no puede ser negativo.";
                return false;
            }

            if (producto.StockMinimo < 0)
            {
                mensaje = "El stock mínimo no puede ser negativo.";
                return false;
            }

            if (producto.CategoriaId <= 0)
            {
                mensaje = "Debe seleccionar una categoría válida.";
                return false;
            }

            // Estado anterior del producto para auditoría
            Producto productoViejo = productoData.ObtenerProductoPorId(producto.Id);

            bool exito = productoData.ActualizarProducto(producto, Sesion.UsuarioId, out mensaje);
            mensaje = exito ? "Producto actualizado con éxito." : "No se pudo actualizar el producto.";

            // Audita los cambios al .txt
            if (exito && productoViejo != null)
            {
                List<string> cambios = new List<string>();

                if (productoViejo.Nombre != producto.Nombre)
                    cambios.Add($"NOMBRE: '{productoViejo.Nombre}' → '{producto.Nombre}'");
                if (productoViejo.Precio != producto.Precio)
                    cambios.Add($"PRECIO: ${productoViejo.Precio} → ${producto.Precio}");
                if (productoViejo.Stock != producto.Stock)
                    cambios.Add($"STOCK: {productoViejo.Stock} → {producto.Stock}");
                if (productoViejo.CategoriaId != producto.CategoriaId)
                {
                    if (string.IsNullOrWhiteSpace(producto.CategoriaNombre))
                        producto.CategoriaNombre = new Data.CategoriaData().ObtenerNombrePorId(producto.CategoriaId);
                        
                    cambios.Add($"CATEGORÍA: {productoViejo.CategoriaNombre} → {producto.CategoriaNombre}");
                }

                if (cambios.Count > 0)
                {
                    string textoCambios = string.Join(", ", cambios);
                    AuditoriaBusiness.RegistrarEvento(
                        "Producto", 
                        "Modificación", 
                        $"CÓDIGO: [{productoViejo.Codigo}], {textoCambios}"
                    );
                }
            }

            return exito;
        }

        /// <summary>
        /// Desactiva un producto.
        /// Audita la acción si se realiza con éxito.
        /// </summary>
        /// <param name="productoId"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public bool DesactivarProducto(int productoId, out string mensaje)
        {
            Producto prodViejo = productoData.ObtenerProductoPorId(productoId);
            bool exito = productoData.DesactivarProducto(productoId, Sesion.UsuarioId, out mensaje);
            
            if (exito && prodViejo != null)
            {
                AuditoriaBusiness.RegistrarEvento(
                    "Producto", 
                    "Baja Lógica", 
                    $"CÓDIGO: [{prodViejo.Codigo}], NOMBRE: {prodViejo.Nombre}"
                );
            }

            return exito;
        }

        /// <summary>
        /// Reactivar un producto, solo si tiene stock disponible.
        /// Audita la acción si se realiza con éxito.
        /// </summary>
        public bool ReactivarProducto(int productoId, out string mensaje)
        {
            Producto prodViejo = productoData.ObtenerProductoPorId(productoId);
            bool exito = productoData.ReactivarProducto(productoId, Sesion.UsuarioId, out mensaje);
            
            if (exito && prodViejo != null)
            {
                AuditoriaBusiness.RegistrarEvento(
                    "Producto", 
                    "Reactivación", 
                    $"CÓDIGO: [{prodViejo.Codigo}], NOMBRE: {prodViejo.Nombre}"
                );
            }

            return exito;
        }

        /// <summary>
        /// Cantidad de productos activos (tarjeta "Total Productos").
        /// </summary>
        public int ContarProductosActivos(string busqueda, int? categoriaId, bool? soloActivos)
        {
            return productoData.ContarProductosActivos(busqueda, categoriaId, soloActivos);
        }

        /// <summary>
        /// Cantidad de productos activos sin stock (tarjeta "Sin Stock").
        /// </summary>
        public int ContarProductosSinStock(string busqueda, int? categoriaId, bool? soloActivos)
        {
            return productoData.ContarProductosSinStock(busqueda, categoriaId, soloActivos);
        }

        /// <summary>
        /// Cantidad de productos activos en stock crítico (tarjeta "Stock Crítico").
        /// 
        public int ContarProductosStockCritico(string busqueda, int? categoriaId, bool? soloActivos)
        {
            return productoData.ContarProductosStockCritico(busqueda, categoriaId, soloActivos);
        }

        /// <summary>
        /// Valor total del inventario activo (tarjeta "Valor del Inventario").
        /// </summary>
        public decimal ObtenerValorInventario(string busqueda, int? categoriaId, bool? soloActivos)
        {
            return productoData.ObtenerValorInventario(busqueda, categoriaId, soloActivos);
        }
    }
}
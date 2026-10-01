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

        public List<Producto> ObtenerProductosPaginadosAdmin(string busqueda, int pagina, out int totalPaginas, out string mensajeError)
        {
            mensajeError = string.Empty;
            int paginaValida = pagina < 1 ? 1 : pagina;
            return productoData.ObtenerProductosPaginadosAdmin(busqueda, paginaValida, FILAS_POR_PAGINA_PRODUCTOS, out totalPaginas);
        }

        /// <summary>
        /// Actualiza un producto existente en la base de datos.
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

            if (producto.CategoriaId <= 0)
            {
                mensaje = "Debe seleccionar una categoría válida.";
                return false;
            }

            return productoData.ActualizarProducto(producto, Sesion.UsuarioId, out mensaje);
        }

        /// <summary>
        /// Desactiva un producto, marcándolo como inactivo en la base de datos.
        /// </summary>
        /// <param name="productoId"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public bool DesactivarProducto(int productoId, out string mensaje)
        {
            return productoData.DesactivarProducto(productoId, Sesion.UsuarioId, out mensaje);
        }

        /// <summary>
        /// Reactivar un producto, marcándolo como activo en la base de datos, solo si tiene stock disponible.
        /// </summary>
        /// <param name="productoId"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public bool ReactivarProducto(int productoId, out string mensaje)
        {
            return productoData.ReactivarProducto(productoId, Sesion.UsuarioId, out mensaje);
        }
    }
}
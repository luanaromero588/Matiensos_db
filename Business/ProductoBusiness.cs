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
    }
}
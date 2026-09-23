using System.Collections.Generic;
using Data;
using Entities;

namespace Business
{
    public class ProductoBusiness
    {
        private readonly ProductoData productoData = new ProductoData();

        /// <summary>
        /// Obtiene una lista de productos activos con stock disponible.
        /// </summary>
        /// <returns></returns>
        public List<Producto> ObtenerProductosConStock()
        {
            return productoData.ListarActivosConStock();
        }
    }
}
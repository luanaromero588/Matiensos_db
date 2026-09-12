using System.Collections.Generic;
using Data;
using Entities;

namespace Business
{
    public class ProductoBusiness
    {
        private readonly ProductoData productoData = new ProductoData();

        public List<Producto> ObtenerProductosConStock()
        {
            return productoData.ListarActivosConStock();
        }
    }
}
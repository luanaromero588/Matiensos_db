using Data;
using Entities;
using System.Collections.Generic;

namespace Business
{
    public class MetodoPagoBusiness
    {
        private readonly MetodoPagoData metodoPagoData = new MetodoPagoData();

        /// <summary>
        /// Obtiene los métodos de pago activos disponibles para asociar a una venta.
        /// </summary>
        public List<MetodoPago> ObtenerMetodosPagoActivos()
        {
            return metodoPagoData.ListarActivos();
        }
    }
}
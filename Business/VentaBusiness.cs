using Data;
using Entities;
using System;
using System.Collections.Generic;

namespace Business
{
    public class VentaBusiness
    {
        private readonly VentaData ventaData = new VentaData();
        private const int FILAS_POR_PAGINA_HISTORIAL = 10;

        /// <summary>
        /// Genera un nuevo número de comprobante basado en el tipo de comprobante proporcionado.
        /// </summary>
        public string GenerarNumeroComprobante(char tipoComprobante)
        {
            return ventaData.ObtenerNuevoCodigoComprobante(tipoComprobante);
        }

        /// <summary>
        /// Procesa la venta validando los datos y registrándola en la base de datos.
        /// </summary>
        public bool ProcesarVenta(Venta venta, out string mensaje)
        {
            if (venta.Detalles == null || venta.Detalles.Count == 0)
            {
                mensaje = "El carrito no contiene productos.";
                return false;
            }

            if (venta.Total <= 0)
            {
                mensaje = "El importe total no puede ser cero o negativo.";
                return false;
            }

            if (venta.ClienteId <= 0)
            {
                mensaje = "Debe asignar un cliente válido o Consumidor Final.";
                return false;
            }

            return ventaData.RegistrarVenta(venta, out mensaje);
        }


        #region Historial de Ventas


        /// <summary>
        /// Obtiene una página del historial de ventas filtrado por rango de fechas y,
        /// opcionalmente, método de pago.
        /// </summary>
        public List<VentaResumen> ObtenerHistorial(DateTime desde, DateTime hasta, int? metodoPagoId, int pagina, out int totalPaginas, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (desde.Date > hasta.Date)
            {
                mensajeError = "La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.";
                totalPaginas = 1;
                return new List<VentaResumen>();
            }

            int paginaValida = pagina < 1 ? 1 : pagina;

            return ventaData.ObtenerHistorialPaginado(desde, hasta, metodoPagoId, paginaValida, FILAS_POR_PAGINA_HISTORIAL, out totalPaginas);
        }

        /// <summary>
        /// Cantidad de ventas registradas hoy.
        /// </summary>
        public int ContarVentasHoy()
        {
            return ventaData.ContarVentasHoy();
        }

        /// <summary>
        /// Total recaudado hoy.
        /// </summary>
        public decimal ObtenerTotalRecaudadoHoy()
        {
            return ventaData.ObtenerTotalRecaudadoHoy();
        }

        /// <summary>
        /// Nombre de la categoría que más recaudó hoy.
        /// </summary>
        public string ObtenerCategoriaTopHoy()
        {
            return ventaData.ObtenerCategoriaTopHoy();
        }

        /// <summary>
        /// Reconstruye el ticket completo de una venta ya registrada.
        /// </summary>
        public TicketVenta ObtenerTicketPorVentaId(int ventaId)
        {
            return ventaData.ObtenerTicketPorVentaId(ventaId);
        }

        #endregion
    }

}
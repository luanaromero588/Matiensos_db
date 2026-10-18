using Data;
using Entities;
using System;
using System.Collections.Generic;

namespace Business
{
    public class VentaBusiness
    {
        private readonly VentaData ventaData = new VentaData();
        private const int FILAS_POR_PAGINA_HISTORIAL = 20;

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
        /// Obtiene una página del historial de ventas filtrado por rango de fechas, método de pago
        /// y vendedor (si es Vendedor, se limita a sus ventas de forma automática).
        /// </summary>
        public List<VentaResumen> ObtenerHistorial(DateTime desde, DateTime hasta, int? metodoPagoId, int pagina, out int totalPaginas, out string mensajeError, int? usuarioId = null)
        {
            mensajeError = string.Empty;

            if (desde.Date > hasta.Date)
            {
                mensajeError = "La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.";
                totalPaginas = 1;
                return new List<VentaResumen>();
            }

            int paginaValida = pagina < 1 ? 1 : pagina;

            // Seguridad por rol: Si es vendedor, solo puede ver sus propias ventas
            int? idFiltrar = usuarioId;
            if (!idFiltrar.HasValue && Sesion.Rol != null && Sesion.Rol.Equals("Vendedor", StringComparison.OrdinalIgnoreCase))
            {
                idFiltrar = Sesion.UsuarioId;
            }

            return ventaData.ObtenerHistorialPaginado(desde, hasta, metodoPagoId, idFiltrar, paginaValida, FILAS_POR_PAGINA_HISTORIAL, out totalPaginas);
        }

        /// <summary>
        /// Obtiene todas las métricas unificadas para el Dashboard, aplicando reglas de validación y seguridad por rol.
        /// </summary>
        public ResumenDashboardVendedor ObtenerMetricasDashboard(DateTime desde, DateTime hasta, int? metodoPagoId, int? usuarioId = null)
        {
            if (desde.Date > hasta.Date)
            {
                throw new ArgumentException("La fecha inicial no puede ser mayor a la fecha final.");
            }

            // Seguridad por rol: Si es vendedor, solo puede ver las métricas de sus propias ventas
            int? idFiltrar = usuarioId;
            if (!idFiltrar.HasValue && Sesion.Rol != null && Sesion.Rol.Equals("Vendedor", StringComparison.OrdinalIgnoreCase))
            {
                idFiltrar = Sesion.UsuarioId;
            }

            return ventaData.ObtenerMetricasDashboard(desde, hasta, metodoPagoId, idFiltrar);
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
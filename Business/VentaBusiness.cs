using Data;
using Entities;
using System;
using System.Data;

namespace Business
{
    public class VentaBusiness
    {
        private readonly VentaData ventaData = new VentaData();

        /// <summary>
        /// Genera un nuevo número de comprobante basado en el tipo de comprobante proporcionado.
        /// </summary>
        /// <param name="tipoComprobante"></param>
        /// <returns></returns>
        public string GenerarNumeroComprobante(char tipoComprobante)
        {
            return ventaData.ObtenerNuevoCodigoComprobante(tipoComprobante);
        }

        /// <summary>
        /// Procesa la venta validando los datos y registrándola en la base de datos.
        /// </summary>
        /// <param name="venta"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
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

        
    }

}
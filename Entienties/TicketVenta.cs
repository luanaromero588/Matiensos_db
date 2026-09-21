using System;
using System.Collections.Generic;

namespace Entities
{
    /// <summary>
    /// Representa el comprobante/ticket completo de una venta.
    /// desde el historial.
    /// </summary>
    public class TicketVenta
    {
        public string Codigo { get; set; }
        public char TipoComprobante { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreCliente { get; set; }
        public string DniCliente { get; set; }
        public string NombreVendedor { get; set; }
        public string NombreMetodoPago { get; set; }
        public decimal Total { get; set; }
        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }
}
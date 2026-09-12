using System;
using System.Collections.Generic;

namespace Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public char TipoComprobante { get; set; } // 'A', 'B' o 'C'
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = "Completada";
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public int MetodoPagoId { get; set; }
        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }
}
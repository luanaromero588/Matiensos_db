using System;

namespace Entities
{
    /// <summary>
    /// Representa una fila del historial de ventas para mostrar en grilla.
    /// </summary>
    public class VentaResumen
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreCliente { get; set; }
        public string NombreMetodoPago { get; set; }
        public decimal Total { get; set; }
    }
}
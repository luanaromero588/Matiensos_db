using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Representa el ítem individual de una venta con su cantidad y precio unitario.
    /// </summary>
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        /// <summary>
        /// Calcula el subtotal multiplicando la cantidad por el precio unitario.
        /// </summary>
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}

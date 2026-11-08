namespace Entities
{
    /// <summary>
    /// Representa un producto del carrito que no tiene stock suficiente al momento de confirmar la venta.
    /// Se genera cuando otro vendedor realizó una venta simultánea antes de la confirmación.
    /// </summary>
    public class StockConflicto
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadSolicitada { get; set; }
        public int StockActualDisponible { get; set; }

        /// <summary>
        /// Texto descriptivo listo para mostrar al vendedor en la ventana de alerta.
        /// </summary>
        public string MensajeLinea =>
            StockActualDisponible > 0
                ? $"• {NombreProducto}  (pediste {CantidadSolicitada}, solo quedan {StockActualDisponible})"
                : $"• {NombreProducto}  (pediste {CantidadSolicitada}, sin stock disponible)";
    }
}

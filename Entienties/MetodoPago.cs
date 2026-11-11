namespace Entities
{
    /// <summary>
    /// Representa un método o forma de pago disponible para registrar ventas.
    /// </summary>
    public class MetodoPago
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; } = true;
    }
}
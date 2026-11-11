namespace Entities
{
    /// <summary>
    /// Representa un cliente del negocio.
    /// </summary>
    public class Cliente
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; } = true;

        /// <summary>
        /// Estado textual del cliente ('Activo' o 'Inactivo').
        /// </summary>
        public string Estado => Activo ? "Activo" : "Inactivo";

        /// <summary>
        /// Nombre y apellido formateados para mostrar en grillas o combos.
        /// </summary>
        public string NombreCompleto => $"{Apellido}, {Nombre}".Trim(',', ' ');
    }
}
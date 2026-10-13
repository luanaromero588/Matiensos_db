namespace Entities
{
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

        public string Estado => Activo ? "Activo" : "Inactivo";

        // Propiedad de conveniencia para mostrar en grillas o combos
        public string NombreCompleto => $"{Apellido}, {Nombre}".Trim(',', ' ');
    }
}
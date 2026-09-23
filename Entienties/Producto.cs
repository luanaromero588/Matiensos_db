namespace Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public int CategoriaId { get; set; }
        public bool Activo { get; set; } = true;
        public string CategoriaNombre { get; set; }

        // Propiedad calculada útil para validaciones rápidas
        public bool TieneStockSuficiente(int cantidadRequerida) => Stock >= cantidadRequerida;

    }
}
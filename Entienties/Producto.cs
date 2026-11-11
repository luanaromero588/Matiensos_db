namespace Entities
{
    /// <summary>
    /// Representa un producto del catálogo del negocio.
    /// </summary>
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

        /// <summary>
        /// Determina si el producto cuenta con stock suficiente para satisfacer la cantidad solicitada.
        /// </summary>
        /// <param name="cantidadRequerida"></param>
        /// <returns></returns>
        public bool TieneStockSuficiente(int cantidadRequerida) => Stock >= cantidadRequerida;

        /// <summary>
        /// Estado textual del producto ('Activo' o 'Inactivo').
        /// </summary>
        public string EstadoTexto => Activo ? "Activo" : "Inactivo";

    }
}
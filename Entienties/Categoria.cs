namespace Entities
{
    /// <summary>
    /// Representa una categoría de productos en el sistema.
    /// </summary>
    public class Categoria
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; } = true;
    }

    /// <summary>
    /// Objeto de transferencia de datos de categoría para visualización en grilla con métricas de stock y productos.
    /// </summary>
    public class CategoriaListadoDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CantidadProductos { get; set; }
        public int StockTotal { get; set; }
        public string Estado { get; set; }
    }


}
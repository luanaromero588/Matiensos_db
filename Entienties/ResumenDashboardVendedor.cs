using System.Collections.Generic;

namespace Entities
{
    public class ResumenDashboardVendedor
    {
        public int CantidadVentas { get; set; }
        public decimal TotalRecaudado { get; set; }
        public string CategoriaTop { get; set; } = "-";
        
        // Diccionario para enlazar directo al control Chart (Gráfico de Torta)
        public Dictionary<string, decimal> VentasPorMetodoPago { get; set; } = new Dictionary<string, decimal>();
    }
}

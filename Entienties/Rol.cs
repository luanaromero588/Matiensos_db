using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }
        public DateTime? EliminadoEn { get; set; }
        public int? CreadoPor { get; set; }
        public int? ActualizadoPor { get; set; }
        public bool EstaActivo { get; set; }
    }
}

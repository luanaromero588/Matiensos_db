using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Representa un elemento o archivo de copia de seguridad para mostrar en la grilla.
    /// </summary>
    public class BackupItem
    {
        public string archvo { get; set; }
        public string fecha { get; set; }
        public string tamaño { get; set; }
        public string usuario { get; set; }
        public string RutaCompleta { get; set; }
    }
}

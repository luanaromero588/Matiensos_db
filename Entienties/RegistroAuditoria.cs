using System;

namespace Entities
{
    /// <summary>
    /// Representa un registro de auditoría con información sobre la fecha, usuario, módulo, acción y detalles del evento registrado.
    /// </summary>
    public class RegistroAuditoria
    {
        public string FechaHora { get; set; }
        public string Usuario { get; set; }
        public string Modulo { get; set; }
        public string Accion { get; set; }
        public string Detalles { get; set; }
    }
}

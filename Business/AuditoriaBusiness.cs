using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Entities;

namespace Business
{
    public static class AuditoriaBusiness
    {
        private static string ObtenerRutaLogActual()
        {
            // Apunta a C:\Users\Usuario\AppData\Roaming\Matiensos_Auditoria\Logs
            string rutaAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string carpetaLogs = Path.Combine(rutaAppData, "Matiensos_Auditoria", "Logs");

            if (!Directory.Exists(carpetaLogs))
            {
                Directory.CreateDirectory(carpetaLogs);
            }

            // Formato mensual: Auditoria_2026_10.log
            string nombreArchivo = $"Auditoria_{DateTime.Now:yyyy_MM}.log";
            return Path.Combine(carpetaLogs, nombreArchivo);
        }

        /// <summary>
        /// Guarda un evento en el archivo de texto mensual.
        /// </summary>
        public static void RegistrarEvento(string modulo, string accion, string detalles)
        {
            try
            {
                string ruta = ObtenerRutaLogActual();
                string usuarioActual = Sesion.Nombre ?? "Usuario Desconocido";
                string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Formato: Fecha|Usuario|Módulo|Acción|Detalles
                string linea = $"{fecha}|{usuarioActual}|{modulo}|{accion}|{detalles}";

                File.AppendAllText(ruta, linea + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar auditoría: " + ex.Message);
            }
        }

        /// <summary>
        /// Lee el archivo del mes actual y devuelve la lista de auditorías paginada.
        /// </summary>
        public static List<RegistroAuditoria> ObtenerHistorialDelMes(int pagina, int registrosPorPagina, out int totalPaginas)
        {
            return ObtenerHistorialFiltrado(null, null, null, null, pagina, registrosPorPagina, out totalPaginas);
        }

        /// <summary>
        /// Obtiene los registros de auditoría filtrados por rango de fechas, operación y término de búsqueda (usuario/módulo).
        /// </summary>
        public static List<RegistroAuditoria> ObtenerHistorialFiltrado(
            DateTime? fechaDesde,
            DateTime? fechaHasta,
            string operacion,
            string busqueda,
            int pagina,
            int registrosPorPagina,
            out int totalPaginas)
        {
            var listaFiltrada = new List<RegistroAuditoria>();
            totalPaginas = 1;
            string ruta = ObtenerRutaLogActual();

            if (!File.Exists(ruta))
            {
                return listaFiltrada;
            }

            string[] lineas = File.ReadAllLines(ruta);

            // más recientes primero
            var registros = new List<RegistroAuditoria>();
            for (int i = lineas.Length - 1; i >= 0; i--)
            {
                string[] partes = lineas[i].Split('|');
                if (partes.Length >= 5)
                {
                    registros.Add(new RegistroAuditoria
                    {
                        FechaHora = partes[0],
                        Usuario = partes[1],
                        Modulo = partes[2],
                        Accion = partes[3],
                        Detalles = partes[4]
                    });
                }
            }

            // 2. Aplicar Filtros
            IEnumerable<RegistroAuditoria> consulta = registros;

            // fecha desde
            if (fechaDesde.HasValue)
            {
                DateTime d = fechaDesde.Value.Date;
                consulta = consulta.Where(r =>
                    DateTime.TryParse(r.FechaHora, out DateTime f) && f >= d);
            }

            // fecha hasta
            if (fechaHasta.HasValue)
            {
                DateTime h = fechaHasta.Value.Date.AddDays(1).AddTicks(-1);
                consulta = consulta.Where(r =>
                    DateTime.TryParse(r.FechaHora, out DateTime f) && f <= h);
            }

            // por operación (Alta, Modificación, Baja Lógica, Reactivación)
            if (!string.IsNullOrWhiteSpace(operacion) && !operacion.Equals("Todas", StringComparison.OrdinalIgnoreCase))
            {
                consulta = consulta.Where(r =>
                    r.Accion != null && r.Accion.Equals(operacion.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            // Filtro por Usuario o Módulo o Detalles
            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                string b = busqueda.Trim().ToLower();
                consulta = consulta.Where(r =>
                    (r.Usuario != null && r.Usuario.ToLower().Contains(b)) ||
                    (r.Modulo != null && r.Modulo.ToLower().Contains(b)) ||
                    (r.Detalles != null && r.Detalles.ToLower().Contains(b)));
            }

            var resultados = consulta.ToList();
            int totalRegistros = resultados.Count;
            if (totalRegistros == 0) return listaFiltrada;

            totalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPagina);
            if (pagina < 1) pagina = 1;
            if (pagina > totalPaginas) pagina = totalPaginas;

            int skip = (pagina - 1) * registrosPorPagina;
            return resultados.Skip(skip).Take(registrosPorPagina).ToList();
        }
    }
}

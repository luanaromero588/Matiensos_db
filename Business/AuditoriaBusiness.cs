using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Entities;

namespace Business
{
    public static class AuditoriaBusiness
    {
        // Ruta base segura usando la carpeta del sistema AppData
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
        /// Lee el archivo del mes actual y devuelve la lista de auditorías.
        /// </summary>
        public static List<RegistroAuditoria> ObtenerHistorialDelMes(int pagina, int registrosPorPagina, out int totalPaginas)
        {
            var lista = new List<RegistroAuditoria>();
            totalPaginas = 1;
            string ruta = ObtenerRutaLogActual();

            if (!File.Exists(ruta))
            {
                return lista; 
            }

            string[] lineas = File.ReadAllLines(ruta);

            //Filtro de lineas descendientes
            var lineasValidas = new List<string>();
            for (int i = lineas.Length - 1; i >= 0; i--)
            {
                if (lineas[i].Split('|').Length >= 5) //Filtro
                {
                    lineasValidas.Add(lineas[i]);
                }
            }

            int totalRegistros = lineasValidas.Count;
            if (totalRegistros == 0) return lista;

            totalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPagina); //Calcular total de páginas
            if (pagina < 1) pagina = 1;
            if (pagina > totalPaginas) pagina = totalPaginas;

            int skip = (pagina - 1) * registrosPorPagina;
            
            // Paginado en memoria
            var lineasPaginadas = lineasValidas.Skip(skip).Take(registrosPorPagina);

            foreach (var linea in lineasPaginadas)
            {
                string[] partes = linea.Split('|');
                lista.Add(new RegistroAuditoria
                {
                    FechaHora = partes[0],
                    Usuario = partes[1],
                    Modulo = partes[2],
                    Accion = partes[3],
                    Detalles = partes[4]
                });
            }

            return lista;
        }
    }
}

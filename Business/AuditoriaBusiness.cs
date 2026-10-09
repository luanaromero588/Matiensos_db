using System;
using System.Collections.Generic;
using System.IO;
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

                // Separador: Pipe (|)
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
        public static List<RegistroAuditoria> ObtenerHistorialDelMes()
        {
            var lista = new List<RegistroAuditoria>();
            string ruta = ObtenerRutaLogActual();

            if (!File.Exists(ruta))
            {
                return lista; 
            }

            string[] lineas = File.ReadAllLines(ruta);
            
            // De abajo hacia arriba para que lo más reciente salga primero
            for (int i = lineas.Length - 1; i >= 0; i--)
            {
                string[] partes = lineas[i].Split('|');
                
                if (partes.Length >= 5)
                {
                    lista.Add(new RegistroAuditoria
                    {
                        FechaHora = partes[0],
                        Usuario = partes[1],
                        Modulo = partes[2],
                        Accion = partes[3],
                        Detalles = partes[4]
                    });
                }
            }

            return lista;
        }
    }
}

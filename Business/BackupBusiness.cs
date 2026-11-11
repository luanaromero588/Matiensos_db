using System;
using System.Collections.Generic;
using System.IO;
using Entities;
using Data;

namespace Business
{
    public class BackupBusiness
    {
        private readonly BackupData _backupData = new BackupData();

        // Carpeta dinámica dentro del directorio de la aplicación (Debug/Release)
        private string ObtenerCarpetaBackups()
        {
            string ruta = @"C:\BackupsSQL\";
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }
            return ruta;
        }

        public List<BackupItem> ListarBackups()
        {
            string carpeta = ObtenerCarpetaBackups();
            DirectoryInfo di = new DirectoryInfo(carpeta);
            FileInfo[] archivos = di.GetFiles("*.bak");

            List<BackupItem> lista = new List<BackupItem>();

            // Ordenamos del más reciente al más antiguo
            Array.Sort(archivos, (x, y) => y.CreationTime.CompareTo(x.CreationTime));

            foreach (FileInfo archivo in archivos)
            {
                double megas = (double)archivo.Length / (1024 * 1024);

                lista.Add(new BackupItem
                {
                    archvo = archivo.Name,
                    fecha = archivo.CreationTime.ToString("dd/MM/yyyy HH:mm"),
                    tamaño = $"{megas:F2} MB",
                    usuario = "Admin",
                    RutaCompleta = archivo.FullName
                });
            }

            return lista;
        }

        public void GenerarNuevoBackup()
        {
            ObtenerCarpetaBackups();

            string nombreArchivo = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            _backupData.RealizarBackup(nombreArchivo);

            AuditoriaBusiness.RegistrarEvento("Base de Datos", "Backup", $"RESPALDO REALIZADO: '{nombreArchivo}'");
        }

        public void RestaurarBackup(string rutaOArchivo)
        {
            string carpeta = ObtenerCarpetaBackups();
            string nombreLimpio = Path.GetFileName(rutaOArchivo);
            string destino = Path.Combine(carpeta, nombreLimpio);

            string rutaFinal = File.Exists(rutaOArchivo) ? rutaOArchivo : (File.Exists(destino) ? destino : null);

            if (rutaFinal == null)
            {
                throw new FileNotFoundException("El archivo de respaldo seleccionado ya no existe en el disco.");
            }

            if (!string.Equals(Path.GetFullPath(rutaFinal), Path.GetFullPath(destino), StringComparison.OrdinalIgnoreCase))
            {
                File.Copy(rutaFinal, destino, true);
            }
            
            _backupData.RealizarRestore(nombreLimpio);

            AuditoriaBusiness.RegistrarEvento("Base de Datos", "Restore", $"BASE DE DATOS RESTAURADA DESDE: '{nombreLimpio}'");
        }

        public void EliminarBackup(string rutaBak)
        {
            if (File.Exists(rutaBak))
            {
                string nombreLimpio = Path.GetFileName(rutaBak);
                File.Delete(rutaBak);

                AuditoriaBusiness.RegistrarEvento("Base de Datos", "Baja", $"ARCHIVO DE RESPALDO ELIMINADO: '{nombreLimpio}'");
            }
        }
    }
}

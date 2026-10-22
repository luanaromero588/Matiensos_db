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
            string ruta = @"C:\BackupsSQL";
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
                    fecha = archivo.CreationTime.ToString("dd/MM/yyyy"),
                    tamaño = $"{megas:F2} MB",
                    usuario = "Admin",
                    RutaCompleta = archivo.FullName
                });
            }

            return lista;
        }

        public void GenerarNuevoBackup()
        {
            string nombreArchivo = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            _backupData.RealizarBackup(nombreArchivo);
        }

        public void RestaurarBackup(string rutaBak)
        {
            if (!File.Exists(rutaBak))
            {
                throw new FileNotFoundException("El archivo de respaldo seleccionado no existe.");
            }

            _backupData.RealizarRestore(rutaBak);
        }

        public void EliminarBackup(string rutaBak)
        {
            if (File.Exists(rutaBak))
            {
                File.Delete(rutaBak);
            }
        }
    }
}
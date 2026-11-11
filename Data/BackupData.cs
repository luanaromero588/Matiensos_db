using System;
using System.Data.SqlClient;

namespace Data
{
    public class BackupData
    {
        private readonly string _cadenaConexion = "Server=127.0.0.1,1433; Database=Matiensos_db; User Id=sa; Password=Matiensos123!; TrustServerCertificate=True;";

        // Cadena conectada a 'master' para tareas administrativas de restauración
        private readonly string _cadenaMaster = "Server=127.0.0.1,1433;Database=master;User Id=sa; Password=Matiensos123!; TrustServerCertificate=True;";
        private readonly string _nombreBaseDatos = "Matiensos_db";

        /// <summary>
        /// Realiza una copia de seguridad completa de la base de datos en disco.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        public void RealizarBackup(string nombreArchivo)
        {
            // Script que detecta si SQL Server corre en Linux o Windows

            string archivoLimpio = System.IO.Path.GetFileName(nombreArchivo);

            string query = $@"
                DECLARE @esLinux INT = CHARINDEX('Linux', @@VERSION);
                DECLARE @rutaFinal NVARCHAR(500);

                IF @esLinux > 0
                    SET @rutaFinal = '/var/opt/mssql/backup/' + @nombreArchivo;
                ELSE
                    SET @rutaFinal = 'C:\BackupsSQL\' + @nombreArchivo;

                BACKUP DATABASE [{_nombreBaseDatos}] 
                TO DISK = @rutaFinal 
                WITH FORMAT, MEDIANAME = 'MatiensosBackups', NAME = 'Full Backup';";

            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@nombreArchivo", nombreArchivo);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Restaura la base de datos desde un archivo de copia de seguridad.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        public void RealizarRestore(string nombreArchivo)
        {
            string archivoLimpio = System.IO.Path.GetFileName(nombreArchivo);

            string query = $@"
                DECLARE @esLinux INT = CHARINDEX('Linux', @@VERSION);
                DECLARE @rutaFinal NVARCHAR(500);

                IF @esLinux > 0
                    SET @rutaFinal = '/var/opt/mssql/backup/' + @nombreArchivo;
                ELSE
                    SET @rutaFinal = 'C:\BackupsSQL\' + @nombreArchivo;

                BEGIN TRY
                RESTORE DATABASE [{_nombreBaseDatos}] FROM DISK = @rutaFinal WITH REPLACE;
                ALTER DATABASE [{_nombreBaseDatos}] SET MULTI_USER;
                END TRY
                BEGIN CATCH
                    ALTER DATABASE [{_nombreBaseDatos}] SET MULTI_USER;
                    THROW;
                END CATCH;";

            using (SqlConnection con = new SqlConnection(_cadenaMaster))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@nombreArchivo", archivoLimpio);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
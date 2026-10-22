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

        public void RealizarBackup(string nombreArchivo)
        {
            // Script T-SQL que detecta automáticamente si SQL Server corre en Linux o Windows
            string query = $@"
                DECLARE @plataforma NVARCHAR(50) = CAST(SERVERPROPERTY('Platform') AS NVARCHAR(50));
                DECLARE @rutaFinal NVARCHAR(500);

                IF @plataforma = 'Linux'
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

        public void RealizarRestore(string nombreArchivo)
        {   
            string query = $@"
                DECLARE @plataforma NVARCHAR(50) = CAST(SERVERPROPERTY('Platform') AS NVARCHAR(50));
                DECLARE @rutaFinal NVARCHAR(500);

                IF @plataforma = 'Linux'
                    SET @rutaFinal = '/var/opt/mssql/backup/' + @nombreArchivo;
                ELSE
                    SET @rutaFinal = 'C:\BackupsSQL\' + @nombreArchivo;

                ALTER DATABASE [{_nombreBaseDatos}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                RESTORE DATABASE [{_nombreBaseDatos}] FROM DISK = @rutaFinal WITH REPLACE;
                ALTER DATABASE [{_nombreBaseDatos}] SET MULTI_USER;";

            using (SqlConnection con = new SqlConnection(_cadenaMaster))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@nombreArchivo", nombreArchivo);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
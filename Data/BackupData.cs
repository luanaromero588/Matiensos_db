using System;
using System.Data.SqlClient;

namespace Data
{
    public class BackupData
    {
        private readonly string _cadenaConexion = "Server=localhost;Database=Matiensos_db;Trusted_Connection=True;";

        // Cadena conectada a 'master' para tareas administrativas de restauración
        private readonly string _cadenaMaster = "Server=localhost;Database=master;Trusted_Connection=True;";
        private readonly string _nombreBaseDatos = "Matiensos_db";

        public void RealizarBackup(string rutaDestino)
        {
            string query = $@"
                BACKUP DATABASE [{_nombreBaseDatos}] 
                TO DISK = @rutaDestino 
                WITH FORMAT, MEDIANAME = 'MatiensosBackups', NAME = 'Full Backup';";

            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@rutaDestino", rutaDestino);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RealizarRestore(string rutaArchivoBak)
        {
            // Ponemos la base en SINGLE_USER desconectando a los demás usuarios, 
            // restauramos y volvemos a MULTI_USER
            string query = $@"
                ALTER DATABASE [{_nombreBaseDatos}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                RESTORE DATABASE [{_nombreBaseDatos}] FROM DISK = @rutaBak WITH REPLACE;
                ALTER DATABASE [{_nombreBaseDatos}] SET MULTI_USER;";

            using (SqlConnection con = new SqlConnection(_cadenaMaster))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@rutaBak", rutaArchivoBak);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
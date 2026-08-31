
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class Conexion
    {
        // Cadena de conexión hacia el contenedor en Docker
        private readonly string _cadenaConexion = "Server=127.0.0.1,1433; Database=Matiensos_db; User Id=sa; Password=Matiensos123!; TrustServerCertificate=True;";

        // Método para obtener una conexión abierta
        protected SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadenaConexion);
        }
    }
}

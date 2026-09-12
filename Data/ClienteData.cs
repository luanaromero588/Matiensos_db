using Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class ClienteData : Conexion
    {
        /// <summary>
        /// Obtiene un cliente por su número de DNI.
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public Cliente ObtenerPorDni(string dni)
        {
            const string query = @"
                SELECT c.customer_id, p.first_name, p.last_name, p.dni, p.phone, p.email, c.address
                FROM dbo.customer c
                INNER JOIN dbo.person p ON c.customer_id = p.id
                WHERE p.dni = @dni AND p.is_active = 1;";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@dni", SqlDbType.VarChar, 8).Value = dni;
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Cliente
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            Apellido = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            Dni = reader.GetString(3),
                            Telefono = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                            Email = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                            Direccion = reader.IsDBNull(6) ? string.Empty : reader.GetString(6)
                        };
                    }
                }
            }
            return null;
        }
    }
}
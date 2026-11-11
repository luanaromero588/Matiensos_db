using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
    public class PersonaRepository : Conexion
    {
        /// <summary>
        /// Verifica si un número de DNI ya se encuentra registrado en el sistema.
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="personaIdExcluir"></param>
        /// <returns></returns>
        public bool ExisteDni(string dni, int? personaIdExcluir = null)
        {
            const string query = @"SELECT COUNT(1)
                                   FROM dbo.person 
                                   WHERE LTRIM(RTRIM(dni)) = @dni
                                   AND (@personaId IS NULL OR id != @personaId)";

            using (SqlConnection cn = ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@dni", dni.Trim());

                if (personaIdExcluir.HasValue)
                    cmd.Parameters.AddWithValue("@personaId", personaIdExcluir.Value);
                else
                    cmd.Parameters.AddWithValue("@personaId", DBNull.Value);

                cn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}

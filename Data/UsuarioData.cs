using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
     public class UsuarioData
        {

            private readonly string connectionString = "Server=localhost,1433;Database=Matiensos_db;User Id=sa;Password=Matiensos123!;TrustServerCertificate=True;";

            public void InsertarUsuarioCompleto(string nombre, string apellido, string dni, string email, string telefono, int rolId, string password)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            //  Insertar Persona
                            string queryPersona = @"
                            INSERT INTO [person] (first_name, last_name, dni, email, phone, is_active)
                            VALUES (@Nombre, @Apellido, @Dni, @Email, @Telefono, 1);
                            SELECT SCOPE_IDENTITY();";

                            SqlCommand cmdPersona = new SqlCommand(queryPersona, conn, trans);
                            cmdPersona.Parameters.AddWithValue("@Nombre", nombre);
                            cmdPersona.Parameters.AddWithValue("@Apellido", apellido);
                            cmdPersona.Parameters.AddWithValue("@Dni", dni);
                            cmdPersona.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                            cmdPersona.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(telefono) ? (object)DBNull.Value : telefono);

                            int nuevaPersonaId = Convert.ToInt32(cmdPersona.ExecuteScalar());

                            //  Insertar Usuario
                            string queryUsuario = @"
                            INSERT INTO [user] (password, role_id, person_id)
                            VALUES (@Password, @RoleId, @PersonId);";

                            SqlCommand cmdUsuario = new SqlCommand(queryUsuario, conn, trans);
                            cmdUsuario.Parameters.AddWithValue("@Password", password);
                            cmdUsuario.Parameters.AddWithValue("@RoleId", rolId);
                            cmdUsuario.Parameters.AddWithValue("@PersonId", nuevaPersonaId);
                            cmdUsuario.ExecuteNonQuery();

                            trans.Commit();
                        }
                        catch
                        {
                            trans.Rollback();
                            throw; // Reenvía el error a Business/Presentation
                        }
                    }
                }
            }

            public void ModificarUsuarioCompleto(int personaId, int usuarioId, string nombre, string apellido, string dni, string email, string telefono, int rolId, string password)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            //  Modificar Persona
                            string queryPersona = @"
                            UPDATE [person] 
                            SET first_name = @Nombre, last_name = @Apellido, dni = @Dni, 
                                email = @Email, phone = @Telefono, updated_at = GETDATE()
                            WHERE id = @PersonaId";

                            SqlCommand cmdPersona = new SqlCommand(queryPersona, conn, trans);
                            cmdPersona.Parameters.AddWithValue("@Nombre", nombre);
                            cmdPersona.Parameters.AddWithValue("@Apellido", apellido);
                            cmdPersona.Parameters.AddWithValue("@Dni", dni);
                            cmdPersona.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                            cmdPersona.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(telefono) ? (object)DBNull.Value : telefono);
                            cmdPersona.Parameters.AddWithValue("@PersonaId", personaId);
                            cmdPersona.ExecuteNonQuery();

                            //  Modificar Usuario (si la clave está vacía, no se sobreescribe)
                            string queryUsuario = string.IsNullOrWhiteSpace(password)
                                ? "UPDATE [user] SET role_id = @RoleId WHERE id = @UsuarioId"
                                : "UPDATE [user] SET role_id = @RoleId, password = @Password WHERE id = @UsuarioId";

                            SqlCommand cmdUsuario = new SqlCommand(queryUsuario, conn, trans);
                            cmdUsuario.Parameters.AddWithValue("@RoleId", rolId);
                            cmdUsuario.Parameters.AddWithValue("@UsuarioId", usuarioId);
                            if (!string.IsNullOrWhiteSpace(password))
                            {
                                cmdUsuario.Parameters.AddWithValue("@Password", password);
                            }
                            cmdUsuario.ExecuteNonQuery();

                            trans.Commit();
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
        }
}


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class UsuarioData : Conexion
    {
        // Inserta Persona y Usuario 
        public void InsertarUsuarioCompleto(string nombre, string apellido, string dni, string email, string telefono, int rolId, string password, int creadoPor)
        {
            using (SqlConnection conn = ObtenerConexion())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        
                        string queryPersona = @"
                    INSERT INTO [person] (first_name, last_name, dni, email, phone, is_active, created_by)
                    VALUES (@Nombre, @Apellido, @Dni, @Email, @Telefono, 1, @CreadoPor);
                    SELECT SCOPE_IDENTITY();";

                        SqlCommand cmdPersona = new SqlCommand(queryPersona, conn, trans);
                        cmdPersona.Parameters.AddWithValue("@Nombre", nombre);
                        cmdPersona.Parameters.AddWithValue("@Apellido", apellido);
                        cmdPersona.Parameters.AddWithValue("@Dni", dni);
                        cmdPersona.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                        cmdPersona.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(telefono) ? (object)DBNull.Value : telefono);
                        cmdPersona.Parameters.AddWithValue("@CreadoPor", creadoPor);

                        int nuevaPersonaId = Convert.ToInt32(cmdPersona.ExecuteScalar());

                        
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
                        throw;
                    }
                }
            }
        }


        // Modifica Persona y Usuario
        public void ModificarUsuarioCompleto(int personaId, int usuarioId, string nombre, string apellido, string dni, string email, string telefono, int rolId, string password, int modificadoPor)
        {
            using (SqlConnection conn = ObtenerConexion())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //  Modifica Persona 
                        string queryPersona = @"
                    UPDATE [person] 
                    SET first_name = @Nombre, 
                        last_name = @Apellido, 
                        dni = @Dni, 
                        email = @Email, 
                        phone = @Telefono, 
                        updated_at = SYSDATETIME(),
                        updated_by = @ModificadoPor
                    WHERE id = @PersonaId";

                        SqlCommand cmdPersona = new SqlCommand(queryPersona, conn, trans);
                        cmdPersona.Parameters.AddWithValue("@Nombre", nombre);
                        cmdPersona.Parameters.AddWithValue("@Apellido", apellido);
                        cmdPersona.Parameters.AddWithValue("@Dni", dni);
                        cmdPersona.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                        cmdPersona.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(telefono) ? (object)DBNull.Value : telefono);
                        cmdPersona.Parameters.AddWithValue("@PersonaId", personaId);
                        cmdPersona.Parameters.AddWithValue("@ModificadoPor", modificadoPor);
                        cmdPersona.ExecuteNonQuery();
 
                        // Modifica Usuario (solo rol y contraseña si corresponde)
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

        // Buscador de usuarios por DNI
        public DataTable ObtenerUsuarios(string filtroDni = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = ObtenerConexion())
            {
                string query = @"
                    SELECT 
                        u.id AS id,
                        p.id AS person_id,
                        p.dni AS dni,
                        p.first_name AS first_name,
                        p.last_name AS last_name,
                        p.email AS email,
                        p.phone AS phone,
                        r.name AS role_name,
                        u.role_id AS role_id,
                        CASE WHEN p.is_active = 1 THEN 'Activo' ELSE 'Inactivo' END AS status_text
                    FROM [user] u
                    INNER JOIN [person] p ON u.person_id = p.id
                    INNER JOIN [role] r ON u.role_id = r.id
                    WHERE p.is_active = 1 
                      AND (@FiltroDni IS NULL OR p.dni LIKE '%' + @FiltroDni + '%')
                    ORDER BY u.id ASC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (string.IsNullOrWhiteSpace(filtroDni))
                        cmd.Parameters.AddWithValue("@FiltroDni", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@FiltroDni", filtroDni.Trim());

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        // Baja logica (Actualiza is_active = 0 en person)
        public void EliminarUsuario(int usuarioId, int eliminadoPor)
        {
            using (SqlConnection conn = ObtenerConexion())
            {
                conn.Open();

               
                string query = @"
            UPDATE p 
            SET p.is_active = 0,
                p.deleted_at = SYSDATETIME(),
                p.deleted_by = @EliminadoPor
            FROM [person] p
            INNER JOIN [user] u ON u.person_id = p.id
            WHERE u.id = @UsuarioId;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    cmd.Parameters.AddWithValue("@EliminadoPor", eliminadoPor);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
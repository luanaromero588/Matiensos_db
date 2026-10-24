using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

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
                            INSERT INTO [person] (first_name, last_name, dni, email, phone, created_by)
                            OUTPUT INSERTED.id
                            VALUES (@Nombre, @Apellido, @Dni, @Email, @Telefono, @CreadoPor);";

                        SqlCommand cmdPersona = new SqlCommand(queryPersona, conn, trans);
                        cmdPersona.Parameters.AddWithValue("@Nombre", nombre);
                        cmdPersona.Parameters.AddWithValue("@Apellido", apellido);
                        cmdPersona.Parameters.AddWithValue("@Dni", dni);
                        cmdPersona.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                        cmdPersona.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(telefono) ? (object)DBNull.Value : telefono);
                        cmdPersona.Parameters.AddWithValue("@CreadoPor", creadoPor);

                        int nuevaPersonaId = Convert.ToInt32(cmdPersona.ExecuteScalar());

                        string queryUsuario = @"
                            INSERT INTO [user] (user_id, password, role_id)
                            VALUES (@PersonId, @Password, @RoleId);";

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
                            WHERE id = @PersonaId;";

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
                            ? "UPDATE [user] SET role_id = @RoleId WHERE user_id = @UsuarioId"
                            : "UPDATE [user] SET role_id = @RoleId, password = @Password WHERE user_id = @UsuarioId";

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

                string query = @"
                    SELECT 
                        u.user_id AS id,
                        p.id AS person_id,
                        p.dni,
                        p.first_name,
                        p.last_name,
                        p.email,
                        p.phone,
                        r.name AS role_name,
                        r.id AS role_id,
                        CASE WHEN p.is_active = 1 THEN 'Activo' ELSE 'Suspendido' END AS status_text
                    FROM [user] u
                    INNER JOIN [person] p ON u.user_id = p.id
                    INNER JOIN [role] r ON u.role_id = r.id
                    WHERE (@FiltroDni IS NULL OR p.dni LIKE '%' + @FiltroDni + '%');";

                using (SqlConnection cn = ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(query, cn))
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

            return dt;
        }

        /// <summary>
        /// Obtiene los datos completos de un usuario por su ID para auditoría y operaciones de negocio.
        /// </summary>
        public DataTable ObtenerUsuarioPorId(int usuarioId)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT 
                    u.user_id AS id,
                    p.id AS person_id,
                    p.dni,
                    p.first_name,
                    p.last_name,
                    p.email,
                    p.phone,
                    r.name AS role_name,
                    r.id AS role_id,
                    CASE WHEN p.is_active = 1 THEN 'Activo' ELSE 'Suspendido' END AS status_text
                FROM [user] u
                INNER JOIN [person] p ON u.user_id = p.id
                INNER JOIN [role] r ON u.role_id = r.id
                WHERE u.user_id = @Id;";

            using (SqlConnection cn = ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@Id", usuarioId);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        /// <summary>
        /// Obtiene el nombre del rol a partir de su ID.
        /// </summary>
        public string ObtenerNombreRolPorId(int rolId)
        {
            string nombre = "Rol #" + rolId;
            using (SqlConnection cn = ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("SELECT name FROM [role] WHERE id = @Id;", cn))
            {
                cmd.Parameters.AddWithValue("@Id", rolId);
                cn.Open();
                object obj = cmd.ExecuteScalar();
                if (obj != null && obj != DBNull.Value)
                {
                    nombre = obj.ToString();
                }
            }
            return nombre;
        }

        // Baja logica 
        public void SuspenderUsuario(int usuarioId, bool activo, int modificadoPor)
        {
            string query = @"
                UPDATE p
                SET p.is_active = @Activo,
                    p.updated_at = SYSDATETIME(),
                    p.updated_by = @ModificadoPor
                FROM [person] p
                INNER JOIN [user] u ON u.user_id = p.id
                WHERE u.user_id = @Id";

            using (SqlConnection cn = ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, cn))

            {
                cmd.Parameters.AddWithValue("@activo", activo ? 1 : 0);
                cmd.Parameters.AddWithValue("@modificadoPor", modificadoPor);
                cmd.Parameters.AddWithValue("@id", usuarioId);

                 cn.Open();
                 cmd.ExecuteNonQuery();
                
            }
        }

        //cards
        public (int TotalActivos, int AdminsActivos, int VendedoresActivos) ObtenerResumenCards()
        {
            int totalActivos = 0;
            int adminsActivos = 0;
            int vendedoresActivos = 0;

            // Conteo condicional: solo tomamos personas con is_active = 1
            string query = @"
                SELECT 
                    COUNT(u.user_id) AS total_activos,
                    COUNT(CASE WHEN r.name IN ('Admin', 'Administrador', 'SuperAdmin') THEN 1 END) AS admins_activos,
                    COUNT(CASE WHEN r.name IN ('Vendedor') THEN 1 END) AS vendedores_activos
                FROM [user] u
                INNER JOIN [person] p ON u.user_id = p.id
                INNER JOIN [role] r ON u.role_id = r.id
                WHERE p.is_active = 1";

            using (SqlConnection cn = ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        totalActivos = dr["total_activos"] != DBNull.Value ? Convert.ToInt32(dr["total_activos"]) : 0;
                        adminsActivos = dr["admins_activos"] != DBNull.Value ? Convert.ToInt32(dr["admins_activos"]) : 0;
                        vendedoresActivos = dr["vendedores_activos"] != DBNull.Value ? Convert.ToInt32(dr["vendedores_activos"]) : 0;
                    }
                }
            }

            return (totalActivos, adminsActivos, vendedoresActivos);
        }

        public DataTable Autenticar(string email, string password)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = ObtenerConexion())
            {
                string query = @"
            SELECT 
                u.user_id,
                p.first_name,
                p.last_name,
                r.name AS rol
            FROM [user] u
            INNER JOIN person p ON u.user_id = p.id
            INNER JOIN role r ON u.role_id = r.id
            WHERE p.email = @email
              AND u.password = @password
              AND p.is_active = 1
              AND r.is_active = 1";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }
        public bool ValidarClaveSuperAdmin(string password)
        {
            using (SqlConnection con = ObtenerConexion())
            {
                string query = @"
                    SELECT COUNT(1)
                    FROM [user] u
                    INNER JOIN role r ON u.role_id = r.id
                    INNER JOIN person p ON u.user_id = p.id
                    WHERE u.password = @password
                      AND r.name = 'SuperAdmin'
                      AND p.is_active = 1
                      AND r.is_active = 1";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@password", password);
                    con.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public bool ValidarClavePorId(int userId, string password)
        {
            using (SqlConnection con = ObtenerConexion())
            {
                string query = @"
            SELECT COUNT(1)
            FROM [user] u
            INNER JOIN person p ON u.user_id = p.id
            WHERE u.user_id = @userId
              AND u.password = @password
              AND p.is_active = 1;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@password", password);
                    con.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }
    }
}
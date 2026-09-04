using System;
using System.Data.SqlClient;

namespace Presentation
{
    internal class DatabaseSeeder
    {
        private static string connectionString = "Server=localhost,1433;Database=Matiensos_db;User Id=sa;Password=Matiensos123!;TrustServerCertificate=True;";

        public static void Seed()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. ROLES INICIALES (Superadmin, Administrador, Vendedor)
                string checkRoles = "SELECT COUNT(*) FROM [role]";
                using (SqlCommand cmdCheck = new SqlCommand(checkRoles, conn))
                {
                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count == 0)
                    {
                        string insertRoles = @"
                            INSERT INTO [role] ([name], [description], [is_active])
                            VALUES 
                                ('Superadmin', 'Propietario con control total', 1),
                                ('Administrador', 'Gestion general del sistema', 1),
                                ('Vendedor', 'Gestion comercial y clientes', 1);";

                        using (SqlCommand cmdInsert = new SqlCommand(insertRoles, conn))
                        {
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }

                // 2. USUARIOS INICIALES (Superadmin autoasignado + Vendedor)
                string checkUsers = "SELECT COUNT(*) FROM [user]";
                using (SqlCommand cmdCheckUsers = new SqlCommand(checkUsers, conn))
                {
                    int userCount = (int)cmdCheckUsers.ExecuteScalar();
                    if (userCount == 0)
                    {
                        using (SqlTransaction trans = conn.BeginTransaction())
                        {
                            try
                            {
                                // Obtener IDs de los roles existentes
                                SqlCommand cmdGetSuper = new SqlCommand("SELECT TOP 1 id FROM [role] WHERE name = 'Superadmin'", conn, trans);
                                int superRoleId = Convert.ToInt32(cmdGetSuper.ExecuteScalar());

                                SqlCommand cmdGetVendedor = new SqlCommand("SELECT TOP 1 id FROM [role] WHERE name = 'Vendedor'", conn, trans);
                                int vendedorRoleId = Convert.ToInt32(cmdGetVendedor.ExecuteScalar());

                                // Superadmin (Matias Castro)
                                string insertSuperPerson = @"
                                    INSERT INTO [person] (first_name, last_name, dni, email, phone, is_active)
                                    VALUES ('Matias', 'Castro', '40123456', 'superadmin@sistema.com', '3794112233', 1);
                                    SELECT SCOPE_IDENTITY();";
                                SqlCommand cmdSuperPerson = new SqlCommand(insertSuperPerson, conn, trans);
                                int superPersonId = Convert.ToInt32(cmdSuperPerson.ExecuteScalar());

                                string insertSuperUser = @"
                                    INSERT INTO [user] (password, role_id, person_id)
                                    VALUES ('superadmin123', @RoleId, @PersonId);
                                    SELECT SCOPE_IDENTITY();";
                                SqlCommand cmdSuperUser = new SqlCommand(insertSuperUser, conn, trans);
                                cmdSuperUser.Parameters.AddWithValue("@RoleId", superRoleId);
                                cmdSuperUser.Parameters.AddWithValue("@PersonId", superPersonId);
                                int superUserId = Convert.ToInt32(cmdSuperUser.ExecuteScalar());

                                // Vendedor de prueba (Lucas Gomez)
                                string insertVendedorPerson = @"
                                    INSERT INTO [person] (first_name, last_name, dni, email, phone, is_active, created_by)
                                    VALUES ('Lucas', 'Gomez', '38987654', 'lucas@sistema.com', '3794445566', 1, @CreatedBy);
                                    SELECT SCOPE_IDENTITY();";
                                SqlCommand cmdVendedorPerson = new SqlCommand(insertVendedorPerson, conn, trans);
                                cmdVendedorPerson.Parameters.AddWithValue("@CreatedBy", superUserId);
                                int vendedorPersonId = Convert.ToInt32(cmdVendedorPerson.ExecuteScalar());

                                string insertVendedorUser = @"
                                    INSERT INTO [user] (password, role_id, person_id)
                                    VALUES ('vendedor123', @RoleId, @PersonId);";
                                SqlCommand cmdVendedorUser = new SqlCommand(insertVendedorUser, conn, trans);
                                cmdVendedorUser.Parameters.AddWithValue("@RoleId", vendedorRoleId);
                                cmdVendedorUser.Parameters.AddWithValue("@PersonId", vendedorPersonId);
                                cmdVendedorUser.ExecuteNonQuery();

                                // Auditoría inicial (created_by)
                                string updateAudit = @"
                                    UPDATE [role] SET created_by = @SuperUserId WHERE created_by IS NULL;
                                    UPDATE [person] SET created_by = @SuperUserId WHERE id = @SuperPersonId;";
                                SqlCommand cmdAudit = new SqlCommand(updateAudit, conn, trans);
                                cmdAudit.Parameters.AddWithValue("@SuperUserId", superUserId);
                                cmdAudit.Parameters.AddWithValue("@SuperPersonId", superPersonId);
                                cmdAudit.ExecuteNonQuery();

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
    }
}
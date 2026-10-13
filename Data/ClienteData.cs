using Entities;
using System;
using System.Collections.Generic;
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
                SELECT c.customer_id, p.first_name, p.last_name, p.dni, p.phone, p.email, c.address, p.is_active
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
                            Direccion = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                            Activo = !reader.IsDBNull(7) && reader.GetBoolean(7)
                        };
                    }
                }
            }
            return null;
        }

        // Obtiene la lista con coincidencia parcial (LIKE)
        public List<Cliente> BuscarCoincidenciasPorDni(string dni)
        {
            var lista = new List<Cliente>();
            const string query = @"
        SELECT 
            c.customer_id, 
            p.first_name, 
            p.last_name, 
            p.dni, 
            p.phone, 
            p.email, 
            c.address,
            p.is_active
        FROM dbo.customer c
        INNER JOIN dbo.person p ON c.customer_id = p.id
        WHERE p.dni <> '99999999'
          AND RTRIM(p.dni) LIKE @Dni + '%'
        ORDER BY p.last_name ASC, p.first_name ASC;";

            using (var conn = ObtenerConexion())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@Dni", SqlDbType.VarChar, 20).Value = dni.Trim();
                conn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Cliente
                        {
                            Id = Convert.ToInt32(dr["customer_id"]),
                            Nombre = dr["first_name"] != DBNull.Value ? dr["first_name"].ToString() : string.Empty,
                            Apellido = dr["last_name"] != DBNull.Value ? dr["last_name"].ToString() : string.Empty,
                            Dni = dr["dni"] != DBNull.Value ? dr["dni"].ToString().Trim() : string.Empty,
                            Telefono = dr["phone"] != DBNull.Value ? dr["phone"].ToString() : string.Empty,
                            Email = dr["email"] != DBNull.Value ? dr["email"].ToString() : string.Empty,
                            Direccion = dr["address"] != DBNull.Value ? dr["address"].ToString() : string.Empty,
                            Activo = dr["is_active"] != DBNull.Value && Convert.ToBoolean(dr["is_active"])
                        });
                    }
                }
            }

            return lista;
        }
        /// <summary>
        /// Registra un nuevo cliente. Inserta primero en dbo.person y luego en dbo.customer.
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="usuarioOperadorId"></param>
        /// <param name="nuevoClienteId"></param>
        /// <param name="mensajeResultado"></param>
        /// <returns></returns>
        public bool RegistrarCliente(Cliente cliente, int usuarioOperadorId, out int nuevoClienteId, out string mensajeResultado)
        {
            nuevoClienteId = 0;
            mensajeResultado = string.Empty;

            using (var conn = ObtenerConexion())
            {
                conn.Open();
                using (var transaccion = conn.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        // 1. Insertar en dbo.person
                        const string queryPerson = @"
                            INSERT INTO dbo.person 
                                (first_name, last_name, dni, email, phone, created_at, created_by, is_active)
                            VALUES 
                                (@first_name, @last_name, @dni, @email, @phone, GETDATE(), @created_by, 1);
                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int personId;
                        using (var cmdPerson = new SqlCommand(queryPerson, conn, transaccion))
                        {
                            cmdPerson.Parameters.Add("@first_name", SqlDbType.VarChar, 100).Value = cliente.Nombre;
                            cmdPerson.Parameters.Add("@last_name", SqlDbType.VarChar, 100).Value = cliente.Apellido;
                            cmdPerson.Parameters.Add("@dni", SqlDbType.VarChar, 8).Value = cliente.Dni;

                            cmdPerson.Parameters.Add("@email", SqlDbType.VarChar, 255).Value =
                                string.IsNullOrWhiteSpace(cliente.Email) ? (object)DBNull.Value : cliente.Email.Trim();

                            cmdPerson.Parameters.Add("@phone", SqlDbType.VarChar, 15).Value =
                                string.IsNullOrWhiteSpace(cliente.Telefono) ? (object)DBNull.Value : cliente.Telefono.Trim();

                            cmdPerson.Parameters.Add("@created_by", SqlDbType.Int).Value =
                                usuarioOperadorId > 0 ? (object)usuarioOperadorId : DBNull.Value;

                            personId = (int)cmdPerson.ExecuteScalar();
                        }

                        // 2. Insertar en dbo.customer (Usa el mismo ID generado por person)
                        const string queryCustomer = @"
                            INSERT INTO dbo.customer (customer_id, address)
                            VALUES (@customer_id, @address);";

                        using (var cmdCustomer = new SqlCommand(queryCustomer, conn, transaccion))
                        {
                            cmdCustomer.Parameters.Add("@customer_id", SqlDbType.Int).Value = personId;
                            cmdCustomer.Parameters.Add("@address", SqlDbType.VarChar, 255).Value =
                                string.IsNullOrWhiteSpace(cliente.Direccion) ? (object)DBNull.Value : cliente.Direccion.Trim();

                            cmdCustomer.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                        nuevoClienteId = personId;
                        mensajeResultado = "Cliente registrado con éxito.";
                        return true;
                    }
                    catch (SqlException exSql)
                    {
                        transaccion.Rollback();

                        // Control de restricciones UNIQUE (2627 o 2601 en SQL Server)
                        if (exSql.Number == 2627 || exSql.Number == 2601)
                        {
                            if (exSql.Message.Contains("UQ_person_dni"))
                                mensajeResultado = "Ya existe una persona registrada con ese número de DNI.";
                            else if (exSql.Message.Contains("UQ_person_email"))
                                mensajeResultado = "Ya existe una persona registrada con ese correo electrónico.";
                            else
                                mensajeResultado = "El registro ya existe en el sistema.";
                        }
                        else
                        {
                            mensajeResultado = $"Error en base de datos al registrar: Código {exSql.Number}.";
                        }
                        return false;
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        mensajeResultado = $"Ocurrió un error imprevisto: {ex.Message}";
                        return false;
                    }
                }
            }
        }

        public List<Cliente> ListarActivos()
        {
            var lista = new List<Cliente>();
            const string query = @"
            SELECT 
                c.customer_id, 
                p.first_name, 
                p.last_name, 
                p.dni, 
                p.phone, 
                p.email, 
                c.address,
                p.is_active
            FROM dbo.customer c
            INNER JOIN dbo.person p ON c.customer_id = p.id
            WHERE p.is_active = 1
                AND p.dni <> '99999999'
                ORDER BY p.last_name ASC, p.first_name ASC;";

            using (var conn = ObtenerConexion())
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente
                            {
                                Id = Convert.ToInt32(dr["customer_id"]),
                                Nombre = dr["first_name"].ToString(),
                                Apellido = dr["last_name"].ToString(),
                                Dni = dr["dni"].ToString(),
                                Telefono = dr["phone"] != DBNull.Value ? dr["phone"].ToString() : string.Empty,
                                Email = dr["email"] != DBNull.Value ? dr["email"].ToString() : string.Empty,
                                Direccion = dr["address"] != DBNull.Value ? dr["address"].ToString() : string.Empty,
                                Activo = Convert.ToBoolean(dr["is_active"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public int ContarTotalClientes()
        {
            int total = 0;
            const string query = @"
        SELECT COUNT(1) 
        FROM dbo.customer c
        INNER JOIN dbo.person p ON c.customer_id = p.id
        WHERE p.is_active = 1 
          AND p.dni <> '99999999';";

            using (var conn = ObtenerConexion())
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    total = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return total;
        }

        public int ContarClientesNuevosMes()
        {
            int total = 0;
            const string query = @"
        SELECT COUNT(1) 
        FROM dbo.customer c
        INNER JOIN dbo.person p ON c.customer_id = p.id
        WHERE p.is_active = 1 
          AND p.dni <> '99999999'
          AND p.created_at >= DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0);";

            using (var conn = ObtenerConexion())
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    total = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return total;
        }

        public string ObtenerClienteTopMes()
        {
            string topCliente = "-";
            const string query = @"
        SELECT TOP 1 CONCAT(p.first_name, ' ', p.last_name)
        FROM dbo.sale s
        INNER JOIN dbo.customer c ON s.customer_id = c.customer_id
        INNER JOIN dbo.person p ON c.customer_id = p.id
        WHERE p.dni <> '99999999'
          AND s.created_at >= DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0)
        GROUP BY p.id, p.first_name, p.last_name
        ORDER BY SUM(s.total_amount) DESC;";

            using (var conn = ObtenerConexion())
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    object resultado = cmd.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        topCliente = resultado.ToString();
                    }
                }
            }

            return topCliente;
        }

        public bool Modificar(Cliente cliente)
        {
            const string query = @"
        BEGIN TRANSACTION;
        BEGIN TRY
            -- 1. Actualizar person
            UPDATE dbo.person
            SET first_name = @Nombre,
                last_name  = @Apellido,
                phone      = @Telefono,
                email      = @Email
            WHERE id = @Id;

            -- 2. Actualizar customer
            UPDATE dbo.customer
            SET address = @Direccion
            WHERE customer_id = @Id;

            COMMIT TRANSACTION;
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION;
            THROW;
        END CATCH;";

            using (var conn = ObtenerConexion())
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", cliente.Id);
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(cliente.Telefono) ? (object)DBNull.Value : cliente.Telefono);
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(cliente.Email) ? (object)DBNull.Value : cliente.Email);
                    cmd.Parameters.AddWithValue("@Direccion", string.IsNullOrWhiteSpace(cliente.Direccion) ? (object)DBNull.Value : cliente.Direccion);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public bool CambiarEstado(int id, bool estado)
        {

            const string query = @"
        UPDATE dbo.person 
        SET is_active = @Estado 
        WHERE id = @Id;";

            using (var conn = ObtenerConexion())
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Estado", estado ? 1 : 0);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Cliente> ListarTodos()
        {
            var lista = new List<Cliente>();
            const string query = @"
        SELECT 
            c.customer_id, 
            p.first_name, 
            p.last_name, 
            p.dni, 
            p.phone, 
            p.email, 
            c.address,

            p.is_active
        FROM dbo.customer c
        INNER JOIN dbo.person p ON c.customer_id = p.id
        WHERE p.dni <> '99999999'  -- Solo excluimos Consumidor Final, no los inactivos
        ORDER BY p.last_name ASC, p.first_name ASC;";

            using (var conn = ObtenerConexion())
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente
                            {
                                Id = Convert.ToInt32(dr["customer_id"]),
                                Nombre = dr["first_name"].ToString(),
                                Apellido = dr["last_name"].ToString(),
                                Dni = dr["dni"].ToString(),
                                Telefono = dr["phone"] != DBNull.Value ? dr["phone"].ToString() : string.Empty,
                                Email = dr["email"] != DBNull.Value ? dr["email"].ToString() : string.Empty,
                                Direccion = dr["address"] != DBNull.Value ? dr["address"].ToString() : string.Empty,
                                Activo = Convert.ToBoolean(dr["is_active"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

    }
}
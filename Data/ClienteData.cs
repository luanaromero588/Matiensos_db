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
                c.address
            FROM dbo.customer c
            INNER JOIN dbo.person p ON c.customer_id = p.id
            WHERE p.is_active = 1";

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
                                Direccion = dr["address"] != DBNull.Value ? dr["address"].ToString() : string.Empty
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
using Data;
using Entities;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Business
{
    public class ClienteBusiness
    {
        private readonly ClienteData clienteData = new ClienteData();


        /// <summary>
        /// Registra un nuevo cliente en el sistema, validando los datos antes de persistirlos.
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="usuarioOperadorId"></param>
        /// <param name="nuevoClienteId"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public bool RegistrarCliente(Cliente cliente, int usuarioOperadorId, out int nuevoClienteId, out string mensaje)
        {
            nuevoClienteId = 0;

            if (cliente == null)
            {
                mensaje = "Los datos del cliente no fueron provistos.";
                return false;
            }

            // Validar DNI: exactamente entre 7 y 8 dígitos numéricos sin puntos ni guiones
            if (string.IsNullOrWhiteSpace(cliente.Dni) || !Regex.IsMatch(cliente.Dni, @"^\d{7,8}$"))
            {
                mensaje = "El DNI debe tener 7 u 8 caracteres estrictamente numéricos.";
                return false;
            }

            // Validar Nombre y Apellido
            if (string.IsNullOrWhiteSpace(cliente.Nombre) || cliente.Nombre.Trim().Length < 2)
            {
                mensaje = "El nombre es obligatorio y debe tener al menos 2 caracteres.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(cliente.Apellido) || cliente.Apellido.Trim().Length < 2)
            {
                mensaje = "El apellido es obligatorio y debe tener al menos 2 caracteres.";
                return false;
            }

            // Validar Email (si fue ingresado)
            if (!string.IsNullOrWhiteSpace(cliente.Email))
            {
                const string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(cliente.Email.Trim(), emailPattern))
                {
                    mensaje = "El formato del correo electrónico ingresado no es válido.";
                    return false;
                }
            }

            // Delegar la persistencia atómica a la capa de datos
            return clienteData.RegistrarCliente(cliente, usuarioOperadorId, out nuevoClienteId, out mensaje);
        }

        public bool ModificarCliente(Cliente cliente, out string mensaje)
        {
            if (cliente == null || cliente.Id <= 0)
            {
                mensaje = "Identificador de cliente inválido.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                mensaje = "El nombre es obligatorio.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(cliente.Apellido))
            {
                mensaje = "El apellido es obligatorio.";
                return false;
            }

            // Validación opcional de email si tiene contenido
            if (!string.IsNullOrWhiteSpace(cliente.Email) && !cliente.Email.Contains("@"))
            {
                mensaje = "El formato del correo electrónico no es válido.";
                return false;
            }

            bool exito = clienteData.Modificar(cliente);
            mensaje = exito ? "Cliente actualizado con éxito." : "Error al actualizar los datos del cliente.";
            return exito;
        }

        public bool CambiarEstado(int id, bool estado, out string mensaje)
        {
            if (id <= 0)
            {
                mensaje = "Identificador inválido.";
                return false;
            }

            bool exito = clienteData.CambiarEstado(id, estado);
            string accion = estado ? "reactivado" : "desactivado";
            mensaje = exito ? $"Cliente {accion} con éxito." : $"No se pudo actualizar el estado del cliente.";
            return exito;
        }

        /// <summary>
        /// Busca un único cliente por DNI exacto (utilizado en ventas y nuevo cliente).
        /// </summary>
        public Cliente BuscarPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return null;
            return clienteData.ObtenerPorDni(dni);
        }

        /// <summary>
        /// Busca clientes por coincidencia parcial de DNI (utilizado en la grilla de búsqueda).
        /// </summary>
        public List<Cliente> BuscarCoincidenciasPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                return clienteData.ListarTodos();
            }

            return clienteData.BuscarCoincidenciasPorDni(dni);
        }

        public List<Cliente> ListarTodos()
        {
            return clienteData.ListarTodos();
        }
        public List<Cliente> ObtenerClientesActivos()
        {
            return clienteData.ListarActivos();
        }

        public int ContarTotalClientes()
        {
            return clienteData.ContarTotalClientes();
        }

        public int ContarClientesNuevosMes()
        {
            return clienteData.ContarClientesNuevosMes();
        }

        public string ObtenerClienteTopMes()
        {
            return clienteData.ObtenerClienteTopMes();
        }
    }
}
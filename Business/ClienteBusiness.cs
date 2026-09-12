using Data;
using Entities;
using System.Text.RegularExpressions;

namespace Business
{
    public class ClienteBusiness
    {
        private readonly ClienteData clienteData = new ClienteData();

        /// <summary>
        /// Busca un cliente por su DNI.
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public Cliente BuscarPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return null;
            return clienteData.ObtenerPorDni(dni);
        }

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
    }
}
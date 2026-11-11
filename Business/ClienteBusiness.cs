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

            // Valida DNI (entre 7 y 8 numeros sin puntos ni guiones)
            if (string.IsNullOrWhiteSpace(cliente.Dni) || !Regex.IsMatch(cliente.Dni, @"^\d{7,8}$"))
            {
                mensaje = "El DNI debe tener 7 u 8 caracteres estrictamente numéricos.";
                return false;
            }

            // Valida Nombre y Apellido
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

            // Valida Email (si fue ingresado)
            if (!string.IsNullOrWhiteSpace(cliente.Email))
            {
                const string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(cliente.Email.Trim(), emailPattern))
                {
                    mensaje = "El formato del correo electrónico ingresado no es válido.";
                    return false;
                }
            }

            return clienteData.RegistrarCliente(cliente, usuarioOperadorId, out nuevoClienteId, out mensaje);
        }

        /// <summary>
        /// Permite modificar datos del cliente en el grid.
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Cambia de estado entre activo y inactivo (baja logica).
        /// </summary>
        /// <param name="id"></param>
        /// <param name="estado"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
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
        /// Busca un único cliente por DNI (coincidencia exacta).
        /// </summary>
        public Cliente BuscarPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return null;
            return clienteData.ObtenerPorDni(dni);
        }

        /// <summary>
        /// Busca clientes por coincidencia parcial de DNI.
        /// </summary>
        public List<Cliente> BuscarCoincidenciasPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                return clienteData.ListarTodos();
            }

            return clienteData.BuscarCoincidenciasPorDni(dni);
        }

        /// <summary>
        /// Busca clientes por DNI, Nombre o Apellido (coincidencia parcial).
        /// Si el término de búsqueda está vacío, retorna el listado completo.
        /// </summary>
        public List<Cliente> BuscarPorDniONombre(string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro))
            {
                return clienteData.ListarTodos();
            }

            return clienteData.BuscarPorDniONombre(filtro.Trim());
        }

        /// <summary>
        /// Lista todos los clientes.
        /// </summary>
        /// <returns></returns>
        public List<Cliente> ListarTodos()
        {
            return clienteData.ListarTodos();
        }

        /// <summary>
        /// Lista sólo los clientes activos.
        /// </summary>
        /// <returns></returns>
        public List<Cliente> ObtenerClientesActivos()
        {
            return clienteData.ListarActivos();
        }

        /// <summary>
        /// Devuelve la cantidad total de clientes.
        /// </summary>
        /// <returns></returns>
        public int ContarTotalClientes()
        {
            return clienteData.ContarTotalClientes();
        }

        /// <summary>
        /// Devuelve la cantidad total de nuevos clientes en el mes actual.
        /// </summary>
        /// <returns></returns>
        public int ContarClientesNuevosMes()
        {
            return clienteData.ContarClientesNuevosMes();
        }

        /// <summary>
        /// Obtiene el cliente con la mayor compra del mes, en terminos monetarios.
        /// </summary>
        /// <returns></returns>
        public string ObtenerClienteTopMes()
        {
            return clienteData.ObtenerClienteTopMes();
        }
    }
}
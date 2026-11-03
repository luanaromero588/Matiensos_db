using Data;
using Entities;
using System.Collections.Generic;
using System;

namespace Business
{
    public class MetodoPagoBusiness
    {
        private readonly MetodoPagoData metodoPagoData = new MetodoPagoData();

        /// <summary>
        /// Obtiene los métodos de pago activos disponibles para asociar a una venta.
        /// </summary>
        public List<MetodoPago> ListarTodos()
        {
            return metodoPagoData.ListarTodos();
        }

        /// <summary>
        /// Obtiene los métodos de pago activos disponibles para asociar a una venta.
        /// </summary>
        /// <returns></returns>
        public List<MetodoPago> ObtenerMetodosPagoActivos()
        {
            return ListarTodos();
        }

        /// <summary>
        /// Verifica si el nombre del método de pago ya se encuentra registrado.
        /// </summary>
        public bool ExisteNombre(string nombre, int idExcluir = 0)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return false;
            return metodoPagoData.ExisteNombre(nombre.Trim(), idExcluir);
        }

        /// <summary>
        /// Registra un nuevo método de pago validando obligatoriedad, longitud máxima y unicidad.
        /// Audita la acción si se realiza con éxito.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public bool RegistrarMetodoPago(string nombre, string descripcion, out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                mensaje = "El nombre del método de pago es obligatorio.";
                return false;
            }

            string nombreFinal = nombre.Trim();

            if (nombreFinal.Length > 50)
            {
                mensaje = "El nombre no puede superar los 50 caracteres.";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(descripcion) && descripcion.Trim().Length > 255)
            {
                mensaje = "La descripción no puede superar los 255 caracteres.";
                return false;
            }

            if (ExisteNombre(nombreFinal))
            {
                mensaje = $"El método de pago '{nombreFinal}' ya está registrado.";
                return false;
            }

            bool exito = metodoPagoData.Insertar(nombreFinal, descripcion?.Trim());
            mensaje = exito ? "Método de pago registrado con éxito." : "Error al guardar el método de pago.";
            
            if (exito)
            {
                AuditoriaBusiness.RegistrarEvento(
                    "Método de Pago", 
                    "Alta",
                    $"NOMBRE: '{nombreFinal}', DESCRIP: {descripcion?.Trim()}");
            }
            return exito;
        }

        /// <summary>
        /// Actualiza un método de pago existente validando obligatoriedad, longitud máxima y unicidad.
        /// Audita los cambios si se realiza con éxito.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public bool ModificarMetodoPago(int id, string nombre, string descripcion, out string mensaje)
        {
            if (id <= 0)
            {
                mensaje = "Identificador de método de pago inválido.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                mensaje = "El nombre del método de pago es obligatorio.";
                return false;
            }

            string nombreFinal = nombre.Trim();

            if (nombreFinal.Length > 50)
            {
                mensaje = "El nombre no puede superar los 50 caracteres.";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(descripcion) && descripcion.Trim().Length > 255)
            {
                mensaje = "La descripción no puede superar los 255 caracteres.";
                return false;
            }

            if (ExisteNombre(nombreFinal, id))
            {
                mensaje = $"Ya existe otro método de pago con el nombre '{nombreFinal}'.";
                return false;
            }

            MetodoPago viejo = metodoPagoData.ObtenerPorId(id);
            bool exito = metodoPagoData.Modificar(id, nombreFinal, descripcion?.Trim());
            mensaje = exito ? "Método de pago actualizado con éxito." : "Error al actualizar el método de pago.";
            
            if (exito && viejo != null)
            {
                List<string> cambios = new List<string>();
                if (viejo.Nombre != nombreFinal) cambios.Add($"NOMBRE: '{viejo.Nombre}' → '{nombreFinal}'");
                if (viejo.Descripcion != (descripcion?.Trim() ?? string.Empty)) cambios.Add($"DESCRIPCIÓN: '{viejo.Descripcion}' → '{descripcion?.Trim()}'");

                if (cambios.Count > 0)
                {
                    AuditoriaBusiness.RegistrarEvento(
                        "Método de Pago", 
                        "Modificación", 
                        $"ID [{id}], " + string.Join(", ", cambios));
                }
            }
            return exito;
        }

        /// <summary>
        /// Cambia el estado de un método de pago (activo/inactivo).
        /// Audita la acción si se realiza con éxito.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="estado"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public bool CambiarEstado(int id, bool estado, out string mensaje)
        {
            MetodoPago viejo = metodoPagoData.ObtenerPorId(id);
            bool exito = metodoPagoData.CambiarEstado(id, estado);
            mensaje = exito ? "Estado actualizado con éxito." : "No se pudo cambiar el estado.";
            
            if (exito && viejo != null)
            {
                string accion = estado ? "Reactivación" : "Baja Lógica";
                AuditoriaBusiness.RegistrarEvento(
                    "Método de Pago", 
                    accion, 
                    $"ID [{id}], NOMBRE: '{viejo.Nombre}'");
            }
            return exito;
        }

        public int ContarTotalMetodosPago()
        {
            return metodoPagoData.ContarTotalActivos();
        }

        public string ObtenerMetodoMasIngresos()
        {
            return metodoPagoData.ObtenerMetodoMasIngresos();
        }

        public string ObtenerMetodoMenosIngresos()
        {
            return metodoPagoData.ObtenerMetodoMenosIngresos();
        }
    }
}
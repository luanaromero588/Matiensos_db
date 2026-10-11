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
        /// Registra un nuevo método de pago.
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

            bool exito = metodoPagoData.Insertar(nombre, descripcion);
            mensaje = exito ? "Método de pago registrado con éxito." : "Error al guardar el método de pago.";
            
            if (exito)
            {
                AuditoriaBusiness.RegistrarEvento(
                    "Método de Pago", 
                    "Alta",
                    $"NOMBRE: '{nombre}', DESCRIP: {descripcion}");
            }
            return exito;
        }

        /// <summary>
        /// Actualiza un método de pago existente.
        /// Audita los cambios si se realiza con éxito.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public bool ModificarMetodoPago(int id, string nombre, string descripcion, out string mensaje)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(nombre))
            {
                mensaje = "Datos inválidos para actualizar.";
                return false;
            }

            MetodoPago viejo = metodoPagoData.ObtenerPorId(id);
            bool exito = metodoPagoData.Modificar(id, nombre, descripcion);
            mensaje = exito ? "Método de pago actualizado con éxito." : "Error al actualizar.";
            
            if (exito && viejo != null)
            {
                List<string> cambios = new List<string>();
                if (viejo.Nombre != nombre) cambios.Add($"NOMBRE: '{viejo.Nombre}' → '{nombre}'");
                if (viejo.Descripcion != descripcion) cambios.Add($"DESCRIPCIÓN: '{viejo.Descripcion}' → '{descripcion}'");

                if (cambios.Count > 0)
                {
                    AuditoriaBusiness.RegistrarEvento(
                        "Método de Pago", 
                        "Modificación", 
                        string.Join(", ", cambios));
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
    }
    
}
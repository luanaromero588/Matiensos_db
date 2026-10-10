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

        public List<MetodoPago> ObtenerMetodosPagoActivos()
        {
            return ListarTodos();
        }

        public bool RegistrarMetodoPago(string nombre, string descripcion, out string mensaje)
            {
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    mensaje = "El nombre del método de pago es obligatorio.";
                    return false;
                }

                bool exito = metodoPagoData.Insertar(nombre, descripcion);
                mensaje = exito ? "Método de pago registrado con éxito." : "Error al guardar el método de pago.";
                return exito;
            }

            public bool ModificarMetodoPago(int id, string nombre, string descripcion, out string mensaje)
            {
                if (id <= 0 || string.IsNullOrWhiteSpace(nombre))
                {
                    mensaje = "Datos inválidos para actualizar.";
                    return false;
                }

                bool exito = metodoPagoData.Modificar(id, nombre, descripcion);
                mensaje = exito ? "Método de pago actualizado con éxito." : "Error al actualizar.";
                return exito;
            }

            public bool CambiarEstado(int id, bool estado, out string mensaje)
            {
                bool exito = metodoPagoData.CambiarEstado(id, estado);
                mensaje = exito ? "Estado actualizado con éxito." : "No se pudo cambiar el estado.";
                return exito;
            }
        }
    
}
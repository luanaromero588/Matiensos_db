using Data;
using Entities;
using System.Collections.Generic;

namespace Business
{
    public class CategoriaBusiness
    {
        private readonly CategoriaData categoriaData = new CategoriaData();

        public List<Categoria> ObtenerCategoriasActivas()
        {
            return categoriaData.ListarActivas();
        }

        public List<CategoriaListadoDto> ObtenerCategoriasParaGrilla()
        {
            return categoriaData.ListarParaGrilla();
        }

        public bool DesactivarCategoria(int id, int cantidadProductos, out string mensaje)
        {
            if (cantidadProductos > 0)
            {
                mensaje = $"No se puede desactivar la categoría porque tiene {cantidadProductos} producto(s) asociado(s).\nReasigne o elimine los productos primero.";
                return false;
            }

            bool resultado = categoriaData.CambiarEstado(id, false);
            mensaje = resultado ? "Categoría desactivada con éxito." : "No se pudo desactivar la categoría.";
            return resultado;
        }

        public bool ReactivarCategoria(int id)
        {
            return categoriaData.CambiarEstado(id, true);
        }

        public bool ActualizarCategoria(int id, string nombre, string descripcion, out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                mensaje = "El nombre de la categoría es obligatorio.";
                return false;
            }

            if (nombre.Length > 100)
            {
                mensaje = "El nombre no puede superar los 100 caracteres.";
                return false;
            }

            bool exito = categoriaData.Actualizar(id, nombre, descripcion);
            mensaje = exito ? "Categoría actualizada con éxito." : "No se pudo actualizar la categoría.";
            return exito;
        }

        public bool RegistrarCategoria(string nombre, string descripcion, out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                mensaje = "El nombre de la categoría es obligatorio.";
                return false;
            }

            bool exito = categoriaData.Insertar(nombre, descripcion);
            mensaje = exito ? "Categoría registrada con éxito." : "No se pudo guardar la categoría.";
            return exito;
        }
    }

}
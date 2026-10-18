using Data;
using Entities;
using System.Collections.Generic;

namespace Business
{
    public class CategoriaBusiness
    {
        private readonly CategoriaData categoriaData = new CategoriaData();

        /// <summary>
        /// Obtiene las categorías activas disponibles para asociar a un producto.
        /// </summary>
        /// <returns></returns>
        public List<Categoria> ObtenerCategoriasActivas()
        {
            return categoriaData.ListarActivas();
        }

        public int ContarTotalCategorias()
        {
            return categoriaData.ContarTotalCategorias();
        }

        /// <summary>
        /// Obtiene las categorías para mostrar en la grilla de administración.
        /// </summary>
        /// <returns></returns>
        public List<CategoriaListadoDto> ObtenerCategoriasParaGrilla()
        {
            return categoriaData.ListarParaGrilla();
        }

        /// <summary>
        /// Desactiva una categoría si no tiene productos asociados. 
        /// Audita la acción si se realiza con éxito.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cantidadProductos"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public bool DesactivarCategoria(int id, int cantidadProductos, out string mensaje)
        {
            if (cantidadProductos > 0)
            {
                mensaje = $"No se puede desactivar la categoría porque tiene {cantidadProductos} producto(s) asociado(s).\nReasigne o elimine los productos primero.";
                return false;
            }

            Categoria catVieja = categoriaData.ObtenerCategoriaPorId(id);
            bool resultado = categoriaData.CambiarEstado(id, false);
            mensaje = resultado ? "Categoría desactivada con éxito." : "No se pudo desactivar la categoría.";
            
            if (resultado && catVieja != null)
            {
                AuditoriaBusiness.RegistrarEvento(
                    "Categoría", 
                    "Baja Lógica", 
                    $"CÓDIGO: [{catVieja.Codigo}], NOMBRE: '{catVieja.Nombre}'");
            }
            return resultado;
        }

        /// <summary>
        /// Reactivar una categoría.
        /// Audita la acción si se realiza con éxito.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ReactivarCategoria(int id)
        {
            Categoria catVieja = categoriaData.ObtenerCategoriaPorId(id);
            bool resultado = categoriaData.CambiarEstado(id, true);

            if (resultado && catVieja != null)
            {
                AuditoriaBusiness.RegistrarEvento(
                    "Categoría", 
                    "Reactivación", 
                    $"CÓDIGO: [{catVieja.Codigo}], NOMBRE: '{catVieja.Nombre}'");
            }
            return resultado;
        }

        /// <summary>
        /// Actualiza una categoria.
        /// Audita los cambios si se realiza con éxito.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
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

            // Estado anterior de la categoría para auditoría
            Categoria catVieja = categoriaData.ObtenerCategoriaPorId(id);

            bool exito = categoriaData.Actualizar(id, nombre, descripcion);
            mensaje = exito ? "Categoría actualizada con éxito." : "No se pudo actualizar la categoría.";
            
            if (exito && catVieja != null)
            {
                List<string> cambios = new List<string>();
                if (catVieja.Nombre != nombre) cambios.Add($"NOMBRE: '{catVieja.Nombre}' → '{nombre}'");
                if (catVieja.Descripcion != descripcion) cambios.Add($"DESCRIPCIÓN: '{catVieja.Descripcion}' → '{descripcion}'");

                if (cambios.Count > 0)
                {
                    AuditoriaBusiness.RegistrarEvento(
                        "Categoría", 
                        "Modificación", 
                        $"CÓDIGO: [{catVieja.Codigo}], " + string.Join(", ", cambios));
                }
            }
            return exito;
        }

        /// <summary>
        /// Registra una nueva categoría.
        /// Audita la acción si se realiza con éxito.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public bool RegistrarCategoria(string nombre, string descripcion, out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                mensaje = "El nombre de la categoría es obligatorio.";
                return false;
            }

            bool exito = categoriaData.Insertar(nombre, descripcion);
            mensaje = exito ? "Categoría registrada con éxito." : "No se pudo guardar la categoría.";
            
            if (exito)
            {
                AuditoriaBusiness.RegistrarEvento(
                    "Categoría",
                    "Alta",
                     $"NOMBRE: '{nombre}, DESCRIPCION: {descripcion}'"); //FALTA AGREGAR EL CODIGO
            }
            return exito;
        }

        public string ObtenerCategoriaMasVendida()
        {
            return categoriaData.ObtenerCategoriaMasVendida();
        }

        public string ObtenerCategoriaMenosVendida()
        {
            return categoriaData.ObtenerCategoriaMenosVendida();
        }
    }
}
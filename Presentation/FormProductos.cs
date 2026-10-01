using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FormProductos : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;
        private readonly ProductoBusiness productoBusiness = new ProductoBusiness();
        private readonly CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        // Variables de Paginación
        private int paginaActual = 1;
        private int totalPaginas = 1;

        // Índice de la fila actualmente en modo edición, o -1 si ninguna lo está.
        private int filaEnEdicionIndex = -1;

        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            Diseno.ConfigurarCards(FLPCards);
            ConfigurarColumnasGrid();
            CargarProductos();
            SendMessage(TBBuscar.Handle, EM_SETCUEBANNER, 0, "Buscar por nombre o código  ...");

        }

        #region Configuración de grilla
        /// <summary>
        /// Configura las columnas del DataGridView para mostrar los productos, incluyendo botones de acción para ver detalles y editar.
        /// </summary>
        private void ConfigurarColumnasGrid()
        {
            Diseno.FormatearGrilla(DGVProductos);

            DGVProductos.AutoGenerateColumns = false;
            DGVProductos.AllowUserToAddRows = false;
            DGVProductos.Columns.Clear();

            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", Visible = false });
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Codigo", HeaderText = "Código", Name = "colCodigo", Width = 100, ReadOnly = true });
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre", Name = "colNombre", Width = 220 });
            var colCategoria = new DataGridViewComboBoxColumn
            {
                Name = "colCategoria",
                HeaderText = "Categoría",
                DataPropertyName = "CategoriaId",
                DataSource = categoriaBusiness.ObtenerCategoriasActivas(),
                DisplayMember = "Nombre",
                ValueMember = "Id",
                Width = 150
            };
            DGVProductos.Columns.Add(colCategoria);
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Precio", HeaderText = "Precio", Name = "colPrecio", Width = 100, DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight } });
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Stock", HeaderText = "Stock", Name = "colStock", Width = 70, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EstadoTexto", HeaderText = "Estado", Name = "colEstado", Width = 90, ReadOnly = true, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            DGVProductos.Columns.Add(new DataGridViewButtonColumn { Name = "colAccionEditar", HeaderText = "", Text = "Editar", UseColumnTextForButtonValue = true, Width = 80 });
            DGVProductos.Columns.Add(new DataGridViewButtonColumn { Name = "colAccionEstado", HeaderText = "", UseColumnTextForButtonValue = false, Width = 90 });

            DGVProductos.ReadOnly = true;
        }

        #endregion

        #region Carga y filtros
        /// <summary>
        /// Carga los productos activos con stock disponible en el DataGridView.
        /// </summary>
        private void CargarProductos()
        {
            string busqueda = TBBuscar.Text.Trim();

            var lista = productoBusiness.ObtenerProductosPaginadosAdmin(busqueda, paginaActual, out totalPaginas, out string mensajeError);

            if (!string.IsNullOrEmpty(mensajeError))
            {
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DGVProductos.DataSource = null;
            DGVProductos.DataSource = lista;
            DGVProductos.ReadOnly = true;

            filaEnEdicionIndex = -1;
            ActualizarTextosBotonAccionEstado();
            ActualizarControlesPaginacion();
        }
        /// <summary>
        /// El texto del botón de la última columna depende del estado de cada producto
        /// ("Eliminar" si está activo, "Activar" si ya está inactivo)
        /// </summary>
        private void ActualizarTextosBotonAccionEstado()
        {
            foreach (DataGridViewRow fila in DGVProductos.Rows)
            {
                if (fila.DataBoundItem is Producto producto)
                {
                    fila.Cells["colAccionEstado"].Value = producto.Activo ? "Eliminar" : "Activar";
                }
            }
        }
        private void BBuscar_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            CargarProductos();
        }
        private void ActualizarControlesPaginacion()
        {
            LPaginas.Text = $"Página {paginaActual} de {totalPaginas}";
            BAnterior.Enabled = paginaActual > 1;
            BSiguiente.Enabled = paginaActual < totalPaginas;
        }
        private void BAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                CargarProductos();
            }
        }
        private void BSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                CargarProductos();
            }
        }

        #endregion

        #region Edición in-place y baja/alta
        private void DGVProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = DGVProductos.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "colAccionEditar")
            {
                ManejarClickEditarGuardar(e.RowIndex);
            }
            else if (nombreColumna == "colAccionEstado")
            {
                ManejarClickEstado(e.RowIndex);
            }
        }

        /// <summary>
        /// Maneja el clic en el botón de la columna "Editar/Guardar". Cambia entre los modos de edición y guardado según corresponda.
        /// </summary>
        /// <param name="filaIndex"></param>
        private void ManejarClickEditarGuardar(int filaIndex)
        {
            bool estaEnEdicion = filaIndex == filaEnEdicionIndex;

            if (!estaEnEdicion)
            {
                // Click en Editar
                if (filaEnEdicionIndex != -1)
                {
                    MessageBox.Show("Termine de editar la fila actual antes de editar otra.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                HabilitarEdicionFila(filaIndex);
            }
            else
            {
                // Click en Guardar
                GuardarFila(filaIndex);
            }
        }

        /// <summary>
        /// Habilita la edición de las celdas de la fila especificada y cambia el texto del botón a "Guardar". 
        /// Deshabilita la edición de otras filas si es necesario.
        /// </summary>
        /// <param name="filaIndex"></param>
        private void HabilitarEdicionFila(int filaIndex)
        {
            var fila = DGVProductos.Rows[filaIndex];

            fila.Cells["colNombre"].ReadOnly = false;
            fila.Cells["colCategoria"].ReadOnly = false;
            fila.Cells["colPrecio"].ReadOnly = false;
            fila.Cells["colStock"].ReadOnly = false;

            fila.Cells["colAccionEditar"].Value = "Guardar";

            filaEnEdicionIndex = filaIndex;
        }

        /// <summary>
        /// Guarda los cambios realizados en la fila especificada, validando los datos antes de enviarlos a la capa de negocio.
        /// </summary>
        /// <param name="filaIndex"></param>
        private void GuardarFila(int filaIndex)
        {
            DGVProductos.EndEdit();

            var fila = DGVProductos.Rows[filaIndex];
            var productoOriginal = fila.DataBoundItem as Producto;
            if (productoOriginal == null) return;

            string nuevoNombre = fila.Cells["colNombre"].Value?.ToString().Trim();
            string textoPrecio = fila.Cells["colPrecio"].Value?.ToString();
            string textoStock = fila.Cells["colStock"].Value?.ToString();
            object valorCategoria = fila.Cells["colCategoria"].Value;

            if (!decimal.TryParse(textoPrecio, out decimal nuevoPrecio))
            {
                MessageBox.Show("El precio ingresado no es válido.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textoStock, out int nuevoStock))
            {
                MessageBox.Show("El stock ingresado no es válido.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (valorCategoria == null || !int.TryParse(valorCategoria.ToString(), out int nuevaCategoriaId))
            {
                MessageBox.Show("Debe seleccionar una categoría válida.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var productoActualizado = new Producto
            {
                Id = productoOriginal.Id,
                Nombre = nuevoNombre,
                Precio = nuevoPrecio,
                Stock = nuevoStock,
                CategoriaId = nuevaCategoriaId
            };

            if (!productoBusiness.ActualizarProducto(productoActualizado, out string mensaje))
            {
                MessageBox.Show(mensaje, "No se pudo guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (mensaje.Contains("desactivó")) // aviso de la regla "stock 0 => inactivo"
            {
                MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            filaEnEdicionIndex = -1;
            CargarProductos();
        }

        /// <summary>
        /// Maneja el clic en el botón de la columna "Eliminar/Activar". 
        /// Cambia el estado del producto según corresponda, mostrando mensajes de confirmación y error según sea necesario.
        /// </summary>
        /// <param name="filaIndex"></param>
        private void ManejarClickEstado(int filaIndex)
        {
            if (filaEnEdicionIndex != -1)
            {
                MessageBox.Show("Termine de editar la fila actual antes de cambiar el estado de otro producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var producto = DGVProductos.Rows[filaIndex].DataBoundItem as Producto;
            if (producto == null) return;

            if (producto.Activo)
            {
                var respuesta = MessageBox.Show(
                    $"¿Eliminar el producto \"{producto.Nombre}\"? Podrá reactivarlo más adelante si tiene stock disponible.",
                    "Confirmar baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta != DialogResult.Yes) return;

                if (!productoBusiness.DesactivarProducto(producto.Id, out string mensaje))
                {
                    MessageBox.Show(mensaje, "No se pudo desactivar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (!productoBusiness.ReactivarProducto(producto.Id, out string mensaje))
                {
                    MessageBox.Show(mensaje, "No se pudo activar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            CargarProductos();
        }

        #endregion


    }
}

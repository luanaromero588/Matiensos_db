using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Business;
using Entities;

namespace Presentation.GestionVentas
{
    /// <summary>
    /// Consulta el historial de ventas registradas, con filtros por rango de fechas
    /// y método de pago, paginado, más indicadores del día.
    /// </summary>
    public partial class FormHistorialVentas : Form
    {
        private readonly VentaBusiness ventaBusiness = new VentaBusiness();
        private readonly MetodoPagoBusiness metodoPagoBusiness = new MetodoPagoBusiness();

        private int paginaActual = 1;
        private int totalPaginas = 1;
        private const int FILTRO_TODOS_LOS_METODOS = 0; // Valor sentinela para el ítem "Todos" del combo de método de pago.

        public FormHistorialVentas()
        {
            InitializeComponent();
        }

        private void FormHistorialVentas_Load(object sender, EventArgs e)
        {
            Diseno.ConfigurarCards(FCardsVentas);
            ConfigurarGrilla();
            CargarMetodosPagoFiltro();
            EstablecerFiltrosPorDefecto();
            
            BuscarHistorial();

            PContenedorVentas.Dock = DockStyle.Fill;
            PContenedorVentas.BringToFront();
        }

        #region Inicialización

        /// <summary>
        /// Configura las propiedades de la grilla de historial de ventas, incluyendo columnas y estilos.
        /// </summary>
        private void ConfigurarGrilla()
        {
            Diseno.FormatearGrilla(DGVHistorial);

            // Limpiar y configurar las columnas específicas
            DGVHistorial.Columns.Clear();
            DGVHistorial.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", Visible = false });
            DGVHistorial.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Codigo", HeaderText = "Comprobante", Width = 120 });
            DGVHistorial.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Fecha", HeaderText = "Fecha y Hora", Width = 140, DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" } });
            DGVHistorial.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreCliente", HeaderText = "Cliente", Width = 200 });
            DGVHistorial.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreMetodoPago", HeaderText = "Método de Pago", Width = 140 });
            DGVHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Total",
                HeaderText = "Total",
                Width = 110,
                DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            var btnVer = new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Ver",
                UseColumnTextForButtonValue = true,
                Width = 60
            };
            DGVHistorial.Columns.Add(btnVer);
        }

        /// <summary>
        /// Carga los métodos de pago activos en el combo de filtro.
        /// </summary>
        private void CargarMetodosPagoFiltro()
        {
            var metodos = metodoPagoBusiness.ObtenerMetodosPagoActivos();
            var opciones = new List<MetodoPago>
            {
                new MetodoPago { Id = FILTRO_TODOS_LOS_METODOS, Nombre = "Todos" }
            };
            opciones.AddRange(metodos);

            CBMetodoPagoFiltro.DataSource = opciones;
            CBMetodoPagoFiltro.DisplayMember = "Nombre";
            CBMetodoPagoFiltro.ValueMember = "Id";
            CBMetodoPagoFiltro.SelectedIndex = 0;
        }

        /// <summary>
        /// Rango por defecto al abrir el formulario: mes en curso.
        /// </summary>
        private void EstablecerFiltrosPorDefecto()
        {
            DTPFechaDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DTPFechaHasta.Value = DateTime.Today;
        }


        #endregion

        #region Filtros y búsqueda

        private void BFiltrar_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            BuscarHistorial();
        }

        private void BLimpiarFiltros_Click(object sender, EventArgs e)
        {
            EstablecerFiltrosPorDefecto();
            CBMetodoPagoFiltro.SelectedIndex = 0;
            paginaActual = 1;
            BuscarHistorial();
        }

        /// <summary>
        /// Obtiene el método de pago seleccionado en el filtro, o null si está en "Todos".
        /// </summary>
        private int? ObtenerMetodoPagoFiltroSeleccionado()
        {
            if (CBMetodoPagoFiltro.SelectedItem is MetodoPago metodo && metodo.Id != FILTRO_TODOS_LOS_METODOS)
            {
                return metodo.Id;
            }
            return null;
        }

        /// <summary>
        /// Realiza la búsqueda del historial de ventas según los filtros seleccionados y actualiza la grilla.
        /// </summary>
        private void BuscarHistorial()
        {
            DateTime desde = DTPFechaDesde.Value.Date;
            DateTime hasta = DTPFechaHasta.Value.Date;
            int? metodoPagoId = ObtenerMetodoPagoFiltroSeleccionado();

            var resultados = ventaBusiness.ObtenerHistorial(desde, hasta, metodoPagoId, paginaActual, out totalPaginas, out string mensajeError);

            if (!string.IsNullOrEmpty(mensajeError))
            {
                MessageBox.Show(mensajeError, "Filtro inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DGVHistorial.DataSource = null;
            DGVHistorial.DataSource = resultados;

            ActualizarControlesPaginacion();

            //Sincroniza las cards con los resultados del filtro actual
            LValorVentas.Text = ventaBusiness.ContarVentas(desde, hasta, metodoPagoId).ToString();
            LValorRecaudacion.Text = ventaBusiness.ObtenerTotalRecaudado(desde, hasta, metodoPagoId).ToString("C2");
            LValorRubroTop.Text = ventaBusiness.ObtenerCategoriaTop(desde, hasta, metodoPagoId);
        }

        #endregion

        #region Paginación

        /// <summary>
        /// Actualiza los controles de paginación según la página actual y el total de páginas.
        /// </summary>
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
                BuscarHistorial();
            }
        }

        private void BSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                BuscarHistorial();
            }
        }

        #endregion

        #region Ver ticket
        /// <summary>
        /// Maneja el evento de clic en la grilla de historial de ventas. 
        /// Si se hace clic en la columna "Ver", se obtiene la venta seleccionada y se muestra su ticket.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool esColumnaVer = e.ColumnIndex == DGVHistorial.Columns.Count - 1;
            if (esColumnaVer && e.RowIndex >= 0)
            {
                var ventaSeleccionada = (VentaResumen)DGVHistorial.Rows[e.RowIndex].DataBoundItem;
                MostrarTicket(ventaSeleccionada.Id);
            }
        }

        /// <summary>
        /// Muestra el ticket de la venta con el ID proporcionado en un formulario modal.
        /// </summary>
        /// <param name="ventaId"></param>
        private void MostrarTicket(int ventaId)
        {
            var ticket = ventaBusiness.ObtenerTicketPorVentaId(ventaId);

            if (ticket == null)
            {
                MessageBox.Show("No se pudo recuperar el comprobante de esta venta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var formTicket = new FormTicket(ticket))
            {
                formTicket.ShowDialog();
            }
        }

        #endregion
    }
}
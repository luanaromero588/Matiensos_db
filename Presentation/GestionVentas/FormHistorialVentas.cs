using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
        
        // Control de gráfico generado dinámicamente para proteger el Designer
        private Chart CGraficoMetodos;

        private int paginaActual = 1;
        private int totalPaginas = 1;
        private const int FILTRO_TODOS_LOS_METODOS = 0; // Valor sentinela para el ítem "Todos" del combo de método de pago.

        public FormHistorialVentas()
        {
            InitializeComponent();
        }

        private void FormHistorialVentas_Load(object sender, EventArgs e)
        {
            Diseno.ConfigurarCards(TLPCards);
            InicializarGraficoVendedor();
            
            ConfigurarGrilla();
            CargarMetodosPagoFiltro();
            EstablecerFiltrosPorDefecto();
            
            BuscarHistorial();

            PContenido.Dock = DockStyle.Fill;
            PContenido.BringToFront();
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
                DefaultCellStyle = { Format = "C2"}
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

        /// <summary>
        /// Construye el control Chart dinámicamente y lo añade al panel de tarjetas.
        /// </summary>
        private void InicializarGraficoVendedor()
        {
            CGraficoMetodos = new Chart();
            CGraficoMetodos.Dock = DockStyle.Fill;
            CGraficoMetodos.BackColor = System.Drawing.Color.White;

            ChartArea area = new ChartArea("MainArea");
            area.BackColor = System.Drawing.Color.Transparent;
            CGraficoMetodos.ChartAreas.Add(area);

            Legend leyenda = new Legend("MainLegend");
            leyenda.Docking = Docking.Bottom;
            leyenda.Alignment = System.Drawing.StringAlignment.Center;
            leyenda.BackColor = System.Drawing.Color.Transparent;
            CGraficoMetodos.Legends.Add(leyenda);

            Series serie = new Series("MetodosPago");
            serie.ChartType = SeriesChartType.Pie;
            serie.IsValueShownAsLabel = true;
            serie.LabelFormat = "C0";
            serie.CustomProperties = "PieLabelStyle=Outside";
            CGraficoMetodos.Series.Add(serie);

            PGrafico.Controls.Add(CGraficoMetodos);
        }

        /// <summary>
        /// Pinta el gráfico inyectando el diccionario de métricas.
        /// </summary>
        private void ActualizarGraficoMetodosPago(Dictionary<string, decimal> datos)
        {
            var serie = CGraficoMetodos.Series["MetodosPago"];
            serie.Points.Clear();

            foreach (var item in datos)
            {
                int idx = serie.Points.AddXY(item.Key, item.Value);
                serie.Points[idx].LegendText = item.Key;
            }

            CGraficoMetodos.Invalidate(); // Fuerza la actualización del gráfico
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

            //Sincroniza las cards con los resultados del filtro actual en un solo viaje a la BD
            var metricas = ventaBusiness.ObtenerMetricasDashboard(desde, hasta, metodoPagoId);
            LValorVentas.Text = metricas.CantidadVentas.ToString();
            LValorRecaudacion.Text = metricas.TotalRecaudado.ToString("C2");
            LValorRubroTop.Text = metricas.CategoriaTop;

            // Renderiza el gráfico de torta
            ActualizarGraficoMetodosPago(metricas.VentasPorMetodoPago);
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

        #region Reportes e Impresión A4
        
        /// <summary>
        /// Genera un reporte profesional A4 nativo. Exporta directamente a PDF usando la impresora virtual de Windows 
        /// y lo abre en el visor predeterminado (ej. Chrome) sin pasar por ventanas de diálogo anticuadas.
        /// </summary>
        private void ImprimirReporte()
        {
            var ventas = DGVHistorial.DataSource as List<VentaResumen>;
            if (ventas == null || !ventas.Any())
            {
                MessageBox.Show("No hay datos para exportar. Realice una búsqueda primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Extraer el gráfico de la UI y lo convierte en imagen web
                string graficoBase64 = "";
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    CGraficoMetodos.SaveImage(ms, ChartImageFormat.Png);
                    graficoBase64 = Convert.ToBase64String(ms.ToArray());
                }

                // Vista
                System.Text.StringBuilder html = new System.Text.StringBuilder();
                html.AppendLine("<!DOCTYPE html>");
                html.AppendLine("<html lang='es'><head><meta charset='UTF-8'><title>Reporte de Ventas</title>");
                html.AppendLine("<style>");
                html.AppendLine("body { font-family: 'Segoe UI', Arial, sans-serif; padding: 40px; color: #333; max-width: 950px; margin: auto; }");
                
                // Cabecera de la Empresa
                html.AppendLine(".company-header { text-align: center; border-bottom: 2px solid #1e3a5f; padding-bottom: 15px; margin-bottom: 20px; }");
                html.AppendLine(".company-header h2 { margin: 0; color: #1e3a5f; font-size: 32px; letter-spacing: 2px; }");
                html.AppendLine(".company-header p { margin: 5px 0 0 0; font-size: 14px; color: #555; }");
                
                html.AppendLine("h1 { text-align: center; color: #1e3a5f; margin-bottom: 20px; font-size: 24px; }");
                html.AppendLine(".header { display: flex; justify-content: space-between; background: #f1f3f5; padding: 10px 15px; border-radius: 5px; margin-bottom: 25px; font-size: 14px; border-left: 4px solid #1e3a5f; }");
                html.AppendLine(".dashboard { display: flex; justify-content: space-between; align-items: center; margin-bottom: 30px; background: #f8f9fa; padding: 15px; border-radius: 8px; border: 1px solid #e9ecef; }");
                html.AppendLine(".metrics p { margin: 10px 0; font-size: 16px; }");
                html.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 10px; }");
                html.AppendLine("th, td { border-bottom: 1px solid #ddd; padding: 10px; text-align: left; font-size: 14px; }");
                html.AppendLine("th { background-color: #1e3a5f; color: white; text-transform: uppercase; }");
                html.AppendLine(".footer { text-align: right; font-size: 20px; font-weight: bold; margin-top: 30px; border-top: 2px solid #1e3a5f; padding-top: 15px; color: #1e3a5f; }");
                
                html.AppendLine("@media print {");
                html.AppendLine("  body { padding: 0; max-width: 100%; }");
                html.AppendLine("  .dashboard { break-inside: avoid; }");
                html.AppendLine("}");
                html.AppendLine("</style></head><body>");

                // Contenido

                // Datos Fiscales de la Empresa
                html.AppendLine("<div class='company-header'>");
                html.AppendLine("  <h2>MATIENSOS S.A.</h2>");
                html.AppendLine("  <p>CUIT: 30-12345678-9 | IVA Responsable Inscripto | Casa Central: Calle Falsa 123</p>");
                html.AppendLine("  <p>Tel: 0800-MATES | Email: administracion@matiensos.com</p>");
                html.AppendLine("</div>");

                html.AppendLine("<h1>REPORTE OPERATIVO DE VENTAS</h1>");
                
                // Cabecera Operativa 
                html.AppendLine("<div class='header'>");
                html.AppendLine($"<div><strong>Vendedor:</strong> Operador de Mostrador</div>"); // <- Aquí puedes reemplazar por Session.UsuarioLogueado.Nombre
                html.AppendLine($"<div><strong>Período:</strong> {DTPFechaDesde.Value:dd/MM/yyyy} al {DTPFechaHasta.Value:dd/MM/yyyy}</div>");
                html.AppendLine($"<div><strong>Filtro:</strong> {CBMetodoPagoFiltro.Text}</div>");
                html.AppendLine("</div>");

                html.AppendLine("<div class='dashboard'>");
                html.AppendLine("<div class='metrics'>");
                html.AppendLine($"<p><strong>Total Recaudado:</strong> {LValorRecaudacion.Text}</p>");
                html.AppendLine($"<p><strong>Cantidad de Tickets:</strong> {LValorVentas.Text}</p>");
                html.AppendLine($"<p><strong>Rubro Principal:</strong> {LValorRubroTop.Text}</p>");
                html.AppendLine("</div>");
                
                
                html.AppendLine($"<div class='chart'><img src='data:image/png;base64,{graficoBase64}' style='max-height: 260px; margin-left: 20px;' /></div>");
                html.AppendLine("</div>");

                html.AppendLine("<table>");
                html.AppendLine("<thead><tr><th>Código</th><th>Fecha</th><th>Cliente</th><th>Método</th><th>Total</th></tr></thead>");
                html.AppendLine("<tbody>");
                
                foreach (var v in ventas)
                {
                    html.AppendLine("<tr>");
                    html.AppendLine($"<td>{v.Codigo}</td>");
                    html.AppendLine($"<td>{v.Fecha:dd/MM/yy HH:mm}</td>");
                    html.AppendLine($"<td>{v.NombreCliente}</td>");
                    html.AppendLine($"<td>{v.NombreMetodoPago}</td>");
                    html.AppendLine($"<td><strong>{v.Total:C2}</strong></td>");
                    html.AppendLine("</tr>");
                }
                
                html.AppendLine("</tbody></table>");
                html.AppendLine($"<div class='footer'>TOTAL GENERAL: {LValorRecaudacion.Text}</div>");

                // Script para que Chrome abra la ventana de "Guardar como PDF / Imprimir" nada más entrar.
                html.AppendLine("<script>window.onload = function() { setTimeout(function(){ window.print(); }, 500); }</script>");

                html.AppendLine("</body></html>");

                // Guardar archivo temporal en Windows
                string archivoTemp = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"Reporte_Ventas_{DateTime.Now:yyyyMMdd_HHmmss}.html");
                System.IO.File.WriteAllText(archivoTemp, html.ToString());

                // Ordenar a Windows que abra el archivo (se abrirá tu navegador por defecto)
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = archivoTemp,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte web: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void BImprimir_Click(object sender, EventArgs e)
        {
            ImprimirReporte();
        }
    }
}
using Entities;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentation.GestionVentas
{
    /// <summary>
    /// Ventana modal que muestra el comprobante de una venta en formato de tickety permite imprimirlo.
    /// </summary>
    public partial class FormTicket : Form
    {
        private readonly TicketVenta ticket;
        private const int ANCHO_TICKET_CARACTERES = 68;

        /// <summary>
        /// Inicializa una nueva instancia del formulario de ticket a partir de los datos de la venta.
        /// </summary>
        /// <param name="ticketVenta"></param>
        public FormTicket(TicketVenta ticketVenta)
        {
            InitializeComponent();
            ticket = ticketVenta ?? throw new ArgumentNullException(nameof(ticketVenta));
        }

        /// <summary>
        /// Carga y formatea el contenido del ticket en el cuadro de texto al abrir el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTicket_Load(object sender, EventArgs e)
        {
            TBContenidoTicket.Text = ArmarTextoTicket();
        }

        /// <summary>
        /// Arma el texto plano del ticket.
        /// </summary>
        private string ArmarTextoTicket()
        {
            var sb = new StringBuilder();

            sb.AppendLine(CentrarTexto("MATIENSOS"));
            sb.AppendLine(CentrarTexto("Comprobante de Venta"));
            sb.AppendLine(new string('-', ANCHO_TICKET_CARACTERES));
            sb.AppendLine($"Comprobante: {ticket.Codigo}");
            sb.AppendLine($"Fecha: {ticket.Fecha:dd/MM/yyyy HH:mm}");
            sb.AppendLine($"Cliente: {ticket.NombreCliente}");
            if (!string.IsNullOrWhiteSpace(ticket.DniCliente))
            {
                sb.AppendLine($"DNI: {ticket.DniCliente}");
            }
            sb.AppendLine($"Vendedor: {ticket.NombreVendedor}");
            sb.AppendLine($"Pago: {ticket.NombreMetodoPago}");
            sb.AppendLine(new string('-', ANCHO_TICKET_CARACTERES));

            foreach (var item in ticket.Detalles)
            {
                sb.AppendLine(item.NombreProducto);
                string linea = $"{item.Cantidad} x {item.PrecioUnitario:N2}";
                string subtotal = item.Subtotal.ToString("N2");
                sb.AppendLine(AlinearIzquierdaDerecha(linea, $"$ {subtotal}"));
            }

            sb.AppendLine(new string('-', ANCHO_TICKET_CARACTERES));
            sb.AppendLine(AlinearIzquierdaDerecha("TOTAL", $"$ {ticket.Total:N2}"));
            sb.AppendLine(new string('-', ANCHO_TICKET_CARACTERES));
            sb.AppendLine(CentrarTexto("¡Gracias por su compra!"));

            return sb.ToString();
        }

        /// <summary>
        /// Centra una cadena de texto dentro del ancho máximo fijado para el ticket.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        private string CentrarTexto(string texto)
        {
            if (texto.Length >= ANCHO_TICKET_CARACTERES)
            {
                return texto;
            }
            int espacios = (ANCHO_TICKET_CARACTERES - texto.Length) / 2;
            return new string(' ', espacios) + texto;
        }

        /// <summary>
        /// Alinea un texto a la izquierda y otro a la derecha en la misma línea del ticket.
        /// </summary>
        /// <param name="izquierda"></param>
        /// <param name="derecha"></param>
        /// <returns></returns>
        private string AlinearIzquierdaDerecha(string izquierda, string derecha)
        {
            int espacios = ANCHO_TICKET_CARACTERES - izquierda.Length - derecha.Length;
            if (espacios < 1)
            {
                espacios = 1;
            }
            return izquierda + new string(' ', espacios) + derecha;
        }

        /// <summary>
        /// Abre el cuadro de diálogo de impresión para imprimir el ticket.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BImprimirTicket_Click(object sender, EventArgs e)
        {
            using (var dialogoImpresion = new PrintDialog { Document = PrintDocumentTicket })
            {
                if (dialogoImpresion.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        PrintDocumentTicket.Print();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"No se pudo imprimir el ticket:\n{ex.Message}", "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Dibuja el texto del ticket en la página de impresión.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintDocumentTicket_PrintPage(object sender, PrintPageEventArgs e)
        {
            var fuenteImpresion = new Font("Consolas", 9);
            e.Graphics.DrawString(TBContenidoTicket.Text, fuenteImpresion, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top);
        }

        /// <summary>
        /// Cierra la ventana del ticket.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BCerrarTicket_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
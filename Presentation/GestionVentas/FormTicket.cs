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
        private const int ANCHO_TICKET_CARACTERES = 32;

        public FormTicket(TicketVenta ticketVenta)
        {
            InitializeComponent();
            ticket = ticketVenta ?? throw new ArgumentNullException(nameof(ticketVenta));
        }

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
                sb.AppendLine(AlinearIzquierdaDerecha(linea, subtotal));
            }

            sb.AppendLine(new string('-', ANCHO_TICKET_CARACTERES));
            sb.AppendLine(AlinearIzquierdaDerecha("TOTAL", $"$ {ticket.Total:N2}"));
            sb.AppendLine(new string('-', ANCHO_TICKET_CARACTERES));
            sb.AppendLine(CentrarTexto("¡Gracias por su compra!"));

            return sb.ToString();
        }

        private string CentrarTexto(string texto)
        {
            if (texto.Length >= ANCHO_TICKET_CARACTERES)
            {
                return texto;
            }
            int espacios = (ANCHO_TICKET_CARACTERES - texto.Length) / 2;
            return new string(' ', espacios) + texto;
        }

        private string AlinearIzquierdaDerecha(string izquierda, string derecha)
        {
            int espacios = ANCHO_TICKET_CARACTERES - izquierda.Length - derecha.Length;
            if (espacios < 1)
            {
                espacios = 1;
            }
            return izquierda + new string(' ', espacios) + derecha;
        }

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

        private void PrintDocumentTicket_PrintPage(object sender, PrintPageEventArgs e)
        {
            var fuenteImpresion = new Font("Consolas", 9);
            e.Graphics.DrawString(TBContenidoTicket.Text, fuenteImpresion, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top);
        }

        private void BCerrarTicket_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
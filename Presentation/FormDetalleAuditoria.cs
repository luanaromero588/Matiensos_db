using System.Windows.Forms;

namespace Presentation
{
    public partial class FormDetalleAuditoria : Form
    {
        public FormDetalleAuditoria(string modulo, string accion, string fecha, string usuario, string detalles)
        {
            InitializeComponent();
            Diseno.FormatearBotonSecundario(btnCerrar);

            lblTitulo.Text = $"Módulo: {modulo} | Acción: {accion}";
            lblSubtitulo.Text = $"Registrado por {usuario} el {fecha}";
            txtDetalles.Text = detalles;
        
        }

        private void btnCerrar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}

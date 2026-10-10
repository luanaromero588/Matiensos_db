using System;
using System.Windows.Forms;
using Business;


namespace Presentation
{
    public partial class FormNuevoMetodoPago : Form
    {
        private readonly MetodoPagoBusiness metodoPagoBusiness = new MetodoPagoBusiness();

        public FormNuevoMetodoPago()
        {
            InitializeComponent();
        }

        private void FormNuevaCategoria_Load(object sender, EventArgs e)
        {
            this.ActiveControl = TBNombreMP;
        }
        private void BGuardar_Click(object sender, EventArgs e)
        {
            string nombre = TBNombreMP.Text.Trim();
            string descripcion = TBDescripcionMP.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre del método de pago es obligatorio.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBNombreMP.Focus();
                return;
            }
            if (!metodoPagoBusiness.RegistrarMetodoPago(nombre, descripcion, out string mensaje))
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    
    }
}
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Business;
using Entities;

namespace Presentation.GestionAdministrador
{
    public partial class FormNuevoProducto : Form
    {
        private readonly CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        private readonly ProductoBusiness productoBusiness = new ProductoBusiness();
        public FormNuevoProducto()
        {
            InitializeComponent();
        }

       

        private TextBox TBNombreProduc;
        private Label LNombreProduc;
        private ComboBox CBcategoriaProduc;
    }
}
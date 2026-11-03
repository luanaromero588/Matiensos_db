using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Business;
using Entities;

namespace Presentation.GestionAdministrador
{
    public partial class FormNuevoProducto : Form
    {
        private readonly CategoriaBusiness _categoriaBusiness = new CategoriaBusiness();
        private readonly ProductoBusiness _productoBusiness = new ProductoBusiness();
        private bool _cargando = false;

        public FormNuevoProducto()
        {
            InitializeComponent();
            Diseno.FormatearModal(this);
        }

        private void FormNuevoProducto_Load(object sender, EventArgs e)
        {
            this.ActiveControl = TBCodProduc;
            Diseno.HabilitarMovimiento(this, panel1);
            Diseno.FormatearBotonPrimario(BGuardar);
            Diseno.FormatearBotonSecundario(BCancelar);
            CargarComboCategorias();
        }

        /// <summary>
        /// Carga las categorías activas en el ComboBox.
        /// </summary>
        private void CargarComboCategorias()
        {
            try
            {
                _cargando = true;
                var categoriasActivas = _categoriaBusiness.ObtenerCategoriasActivas();

                CBcategoriaProduc.DataSource = null;
                CBcategoriaProduc.DataSource = categoriasActivas;
                CBcategoriaProduc.DisplayMember = "Nombre";
                CBcategoriaProduc.ValueMember = "Id";
                CBcategoriaProduc.DropDownStyle = ComboBoxStyle.DropDownList;
                CBcategoriaProduc.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _cargando = false;
            }
        }

        #region Métodos de Validación e Indicadores de Error

        /// <summary>
        /// Muestra el mensaje de error debajo del control y resalta su fondo.
        /// </summary>
        private void MostrarError(Label lbl, Control control, string mensaje)
        {
            lbl.Text = mensaje;
            lbl.Visible = true;
            control.BackColor = Color.MistyRose;
        }

        /// <summary>
        /// Oculta el mensaje de error y restablece el fondo original del control.
        /// </summary>
        private void LimpiarError(Label lbl, Control control)
        {
            lbl.Text = string.Empty;
            lbl.Visible = false;
            control.BackColor = Color.White;
        }

        /// <summary>
        /// Valida el código del producto (obligatorio, máximo 4 caracteres y único).
        /// </summary>
        private bool ValidarCodigo()
        {
            string codigo = TBCodProduc.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MostrarError(LErrorCodigo, TBCodProduc, "El código es obligatorio.");
                return false;
            }

            if (codigo.Length > 4)
            {
                MostrarError(LErrorCodigo, TBCodProduc, "Permite hasta 4 caracteres.");
                return false;
            }

            if (_productoBusiness.ExisteCodigo(codigo))
            {
                MostrarError(LErrorCodigo, TBCodProduc, "El código ya está registrado.");
                return false;
            }

            LimpiarError(LErrorCodigo, TBCodProduc);
            return true;
        }

        /// <summary>
        /// Valida el nombre del producto (obligatorio, solo letras y espacios).
        /// </summary>
        private bool ValidarNombre()
        {
            string nombre = TBNombreProduc.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MostrarError(LErrorNombre, TBNombreProduc, "El nombre es obligatorio.");
                return false;
            }

            LimpiarError(LErrorNombre, TBNombreProduc);
            return true;
        }

        /// <summary>
        /// Valida que se haya seleccionado una categoría válida.
        /// </summary>
        private bool ValidarCategoria()
        {
            if (CBcategoriaProduc.SelectedIndex == -1 || CBcategoriaProduc.SelectedValue == null)
            {
                MostrarError(LErrorCategoria, CBcategoriaProduc, "Debe seleccionar una categoría.");
                return false;
            }

            LimpiarError(LErrorCategoria, CBcategoriaProduc);
            return true;
        }

        /// <summary>
        /// Valida el precio (no permite letras y debe ser estrictamente mayor a 0).
        /// </summary>
        private bool ValidarPrecio()
        {
            string texto = TBPrecio.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                MostrarError(LErrorPrecio, TBPrecio, "El precio es obligatorio.");
                return false;
            }

            if (texto.Any(char.IsLetter))
            {
                MostrarError(LErrorPrecio, TBPrecio, "El precio no puede contener letras.");
                return false;
            }

            if (texto == "-" || texto.StartsWith("-"))
            {
                MostrarError(LErrorPrecio, TBPrecio, "Ingrese valores mayores a 0.");
                return false;
            }

            string normalizado = texto.Replace(',', '.');
            if (!decimal.TryParse(normalizado, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precio))
            {
                MostrarError(LErrorPrecio, TBPrecio, "Ingrese un precio numérico válido.");
                return false;
            }

            if (precio <= 0)
            {
                MostrarError(LErrorPrecio, TBPrecio, "Ingrese valores mayores a 0.");
                return false;
            }

            LimpiarError(LErrorPrecio, TBPrecio);
            return true;
        }

        /// <summary>
        /// Valida el stock inicial (solo enteros positivos o cero, no letras ni decimales).
        /// </summary>
        private bool ValidarStock()
        {
            string texto = TBStock.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                MostrarError(LErrorStock, TBStock, "El stock inicial es obligatorio.");
                return false;
            }

            if (texto.Any(char.IsLetter))
            {
                MostrarError(LErrorStock, TBStock, "El stock solo permite enteros.");
                return false;
            }

            if (texto == "-" || texto.StartsWith("-"))
            {
                MostrarError(LErrorStock, TBStock, "Ingrese valores positivos (≥ 0).");
                return false;
            }

            if (texto.Contains(".") || texto.Contains(","))
            {
                MostrarError(LErrorStock, TBStock, "El stock debe ser un número entero.");
                return false;
            }

            if (!int.TryParse(texto, out int stock) || stock < 0)
            {
                MostrarError(LErrorStock, TBStock, "Ingrese un número entero válido (≥ 0).");
                return false;
            }

            LimpiarError(LErrorStock, TBStock);
            return true;
        }

        /// <summary>
        /// Valida el stock mínimo (solo enteros positivos o cero, no letras ni decimales).
        /// </summary>
        private bool ValidarStockMinimo()
        {
            string texto = TBStockMinimo.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                MostrarError(LErrorStockMinimo, TBStockMinimo, "El stock mínimo es obligatorio.");
                return false;
            }

            if (texto.Any(char.IsLetter))
            {
                MostrarError(LErrorStockMinimo, TBStockMinimo, "El stock solo permite enteros.");
                return false;
            }

            if (texto == "-" || texto.StartsWith("-"))
            {
                MostrarError(LErrorStockMinimo, TBStockMinimo, "Ingrese valores positivos (≥ 0).");
                return false;
            }

            if (texto.Contains(".") || texto.Contains(","))
            {
                MostrarError(LErrorStockMinimo, TBStockMinimo, "El stock mínimo debe ser entero.");
                return false;
            }

            if (!int.TryParse(texto, out int stockMinimo) || stockMinimo < 0)
            {
                MostrarError(LErrorStockMinimo, TBStockMinimo, "Ingrese un número entero válido (≥ 0).");
                return false;
            }

            LimpiarError(LErrorStockMinimo, TBStockMinimo);
            return true;
        }

        /// <summary>
        /// Valida todos los campos antes de persistir los datos.
        /// </summary>
        private bool ValidarFormulario()
        {
            bool esValido = true;
            Control primerInvalido = null;

            if (!ValidarCodigo())
            {
                esValido = false;
                if (primerInvalido == null) primerInvalido = TBCodProduc;
            }

            if (!ValidarNombre())
            {
                esValido = false;
                if (primerInvalido == null) primerInvalido = TBNombreProduc;
            }

            if (!ValidarCategoria())
            {
                esValido = false;
                if (primerInvalido == null) primerInvalido = CBcategoriaProduc;
            }

            if (!ValidarPrecio())
            {
                esValido = false;
                if (primerInvalido == null) primerInvalido = TBPrecio;
            }

            if (!ValidarStock())
            {
                esValido = false;
                if (primerInvalido == null) primerInvalido = TBStock;
            }

            if (!ValidarStockMinimo())
            {
                esValido = false;
                if (primerInvalido == null) primerInvalido = TBStockMinimo;
            }

            primerInvalido?.Focus();
            return esValido;
        }

        #endregion

        #region Eventos de Controles (Tiempo Real, Blur y Filtro de Teclas)

        private void TBCodProduc_TextChanged(object sender, EventArgs e)
        {
            ValidarCodigo();
        }

        private void TBCodProduc_Leave(object sender, EventArgs e)
        {
            ValidarCodigo();
        }

        private void TBNombreProduc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TBNombreProduc_TextChanged(object sender, EventArgs e)
        {
            ValidarNombre();
        }

        private void TBNombreProduc_Leave(object sender, EventArgs e)
        {
            ValidarNombre();
        }

        private void CBcategoriaProduc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargando) return;
            ValidarCategoria();
        }

        private void TBPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-')
            {
                return;
            }

            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (TBPrecio.Text.Contains(".") || TBPrecio.Text.Contains(","))
                {
                    e.Handled = true;
                }
                return;
            }

            e.Handled = true;
        }

        private void TBPrecio_TextChanged(object sender, EventArgs e)
        {
            ValidarPrecio();
        }

        private void TBPrecio_Leave(object sender, EventArgs e)
        {
            ValidarPrecio();
        }

        private void TBStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-')
            {
                return;
            }

            e.Handled = true;
        }

        private void TBStock_TextChanged(object sender, EventArgs e)
        {
            ValidarStock();
        }

        private void TBStock_Leave(object sender, EventArgs e)
        {
            ValidarStock();
        }

        private void TBStockMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-')
            {
                return;
            }

            e.Handled = true;
        }

        private void TBStockMinimo_TextChanged(object sender, EventArgs e)
        {
            ValidarStockMinimo();
        }

        private void TBStockMinimo_Leave(object sender, EventArgs e)
        {
            ValidarStockMinimo();
        }

        #endregion

        /// <summary>
        /// Valida los datos y registra el producto en la base de datos.
        /// </summary>
        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
            {
                return;
            }

            string rawPrecio = TBPrecio.Text.Trim().Replace(',', '.');
            decimal.TryParse(rawPrecio, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precio);
            int.TryParse(TBStock.Text.Trim(), out int stock);
            int.TryParse(TBStockMinimo.Text.Trim(), out int stockMinimo);

            var nuevoProducto = new Producto
            {
                Codigo = TBCodProduc.Text.Trim(),
                Nombre = TBNombreProduc.Text.Trim(),
                Descripcion = TBDescripcion.Text.Trim(),
                CategoriaId = Convert.ToInt32(CBcategoriaProduc.SelectedValue),
                Precio = precio,
                Stock = stock,
                StockMinimo = stockMinimo,
                Activo = true
            };

            if (_productoBusiness.RegistrarProducto(nuevoProducto, out string mensaje))
            {
                MessageBox.Show("Producto registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (mensaje.IndexOf("código", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    MostrarError(LErrorCodigo, TBCodProduc, mensaje);
                    TBCodProduc.Focus();
                }
            }
        }

        /// <summary>
        /// Cierra el formulario modal cancelando la operación.
        /// </summary>
        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Business;
using Entities;

namespace Presentation.GestionVentas
{
    public partial class FormVenta : Form
    {
        private readonly VentaBusiness ventaBusiness = new VentaBusiness();
        private readonly ProductoBusiness productoBusiness = new ProductoBusiness();
        private readonly ClienteBusiness clienteBusiness = new ClienteBusiness();

        private List<DetalleVenta> carrito = new List<DetalleVenta>();
        private List<Producto> productosDisponibles = new List<Producto>();
        private int clienteSeleccionadoId = 2; // ID 2 = Consumidor Final por defecto

        public FormVenta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cargar el formulario de venta. Inicializa los métodos de pago, productos disponibles, configura la grilla y activa el modo de consumidor final.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVenta_Load(object sender, EventArgs e)
        {
            CargarMetodosPago();
            CargarProductos();
            ConfigurarGrilla();
        }

        /// <summary>
        /// Carga los métodos de pago disponibles desde la base de datos.
        /// </summary>
        private void CargarMetodosPago()
        {
            CBFormaPago.DataSource = ventaBusiness.ObtenerMetodosPago();
            CBFormaPago.DisplayMember = "name";
            CBFormaPago.ValueMember = "id";
        }

        /// <summary>
        /// Carga los productos disponibles con stock desde la base de datos.
        /// </summary>
        private void CargarProductos()
        {
            productosDisponibles = productoBusiness.ObtenerProductosConStock();
            CBProductos.DataSource = productosDisponibles;
            CBProductos.DisplayMember = "Nombre";
            CBProductos.ValueMember = "Id";
            CBProductos.SelectedIndex = -1;
        }

        /// <summary>
        /// Configura la grilla de carrito de compras, definiendo las columnas y estilos necesarios.
        /// </summary>
        private void ConfigurarGrilla()
        {
            DGVCarrito.AutoGenerateColumns = false;
            DGVCarrito.Columns.Clear();

            DGVCarrito.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductoId", Visible = false });
            DGVCarrito.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreProducto", HeaderText = "Producto", Width = 220 });
            DGVCarrito.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PrecioUnitario", HeaderText = "Precio", Width = 90, DefaultCellStyle = { Format = "C2" } });
            DGVCarrito.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = "Cant.", Width = 60 });
            DGVCarrito.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Subtotal", HeaderText = "Subtotal", Width = 100, DefaultCellStyle = { Format = "C2" } });

            var btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "X",
                UseColumnTextForButtonValue = true,
                Width = 40
            };
            DGVCarrito.Columns.Add(btnEliminar);
        }

        /// <summary>
        /// Selección de producto en el desplegable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBProductos.SelectedItem is Producto seleccionado)
            {
                LPrecioUnitario.Text = $"${seleccionado.Precio:N2}";
                LStockDisponible.Text = seleccionado.Stock.ToString();
                NUDCantidad.Maximum = seleccionado.Stock;
                NUDCantidad.Value = 1;
            }
            else
            {
                LPrecioUnitario.Text = "$0.00";
                LStockDisponible.Text = "0";
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de estado del checkbox "Consumidor Final"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkConsumidorFinal_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkConsumidorFinal.Checked)
            {
                ActivarConsumidorFinal();
            }
            else
            {
                clienteSeleccionadoId = 0;
                TBDniCliente.Clear();
                TBNombreCliente.Clear();
                TBApellidoCliente.Clear();
                TBDniCliente.ReadOnly = false;
                TBDniCliente.Focus();
            }
        }

        /// <summary>
        /// Activa el modo de "Consumidor Final", estableciendo los valores predeterminados y bloqueando la edición del DNI.
        /// </summary>
        private void ActivarConsumidorFinal()
        {
            ChkConsumidorFinal.Checked = true;
            clienteSeleccionadoId = 2; // ID en semilla
            TBDniCliente.Text = "99999999";
            TBNombreCliente.Text = "Consumidor";
            TBApellidoCliente.Text = "Final";
            TBDniCliente.ReadOnly = true;
        }

        /// <summary>
        /// Botón Buscar Cliente por DNI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BBuscarCliente_Click(object sender, EventArgs e)
        {
            string dni = TBDniCliente.Text.Trim();
            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Ingrese un DNI.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cliente = clienteBusiness.BuscarPorDni(dni);
            if (cliente != null)
            {
                clienteSeleccionadoId = cliente.Id;
                TBNombreCliente.Text = cliente.Nombre;
                TBApellidoCliente.Text = cliente.Apellido;
            }
            else
            {
                MessageBox.Show("Cliente no encontrado en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Botón Agregar al Carrito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BAgregarCarrito_Click(object sender, EventArgs e)
        {
            if (!(CBProductos.SelectedItem is Producto seleccionado))
            {
                MessageBox.Show("Seleccione un producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = (int)NUDCantidad.Value;

            // Verificar si el item ya estaba en la grilla
            var itemExistente = carrito.FirstOrDefault(d => d.ProductoId == seleccionado.Id);
            if (itemExistente != null)
            {
                if (itemExistente.Cantidad + cantidad > seleccionado.Stock)
                {
                    MessageBox.Show("Supera el stock disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                carrito.Add(new DetalleVenta
                {
                    ProductoId = seleccionado.Id,
                    CodigoProducto = seleccionado.Codigo,
                    NombreProducto = seleccionado.Nombre,
                    PrecioUnitario = seleccionado.Precio,
                    Cantidad = cantidad
                });
            }

            RefrescarGrilla();
        }

        /// <summary>
        /// Eliminar ítem de la grilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == DGVCarrito.Columns.Count - 1)
            {
                carrito.RemoveAt(e.RowIndex);
                RefrescarGrilla();
            }
        }

        /// <summary>
        /// Refresca la grilla del carrito y actualiza el total a pagar.
        /// </summary>
        private void RefrescarGrilla()
        {
            DGVCarrito.DataSource = null;
            DGVCarrito.DataSource = carrito;
            decimal total = carrito.Sum(x => x.Subtotal);
            LTotalPagar.Text = $"${total:N2}";
        }

        /// <summary>
        /// Botón Confirmar Venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BConfirmarVenta_Click(object sender, EventArgs e)
        {
            decimal total = carrito.Sum(x => x.Subtotal);
            char tipoComprobante = 'B'; // Se puede parametrizar según tipo de cliente

            var nuevaVenta = new Venta
            {
                Codigo = ventaBusiness.GenerarNumeroComprobante(tipoComprobante),
                TipoComprobante = tipoComprobante,
                Total = total,
                ClienteId = clienteSeleccionadoId,
                UsuarioId = Sesion.UsuarioId,
                MetodoPagoId = Convert.ToInt32(CBFormaPago.SelectedValue),
                Detalles = carrito
            };

            if (ventaBusiness.ProcesarVenta(nuevaVenta, out string mensaje))
            {
                MessageBox.Show($"{mensaje}\nComprobante emitido: {nuevaVenta.Codigo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show(mensaje, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón Cancelar Venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BCancelarVenta_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        /// <summary>
        /// Limpia el formulario de venta.
        /// </summary>
        private void LimpiarFormulario()
        {
            carrito.Clear();
            RefrescarGrilla();
            CargarProductos();
            ActivarConsumidorFinal();
        }
    }
}
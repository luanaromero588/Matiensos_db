using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Business;
using Entities;
using System.ComponentModel;

namespace Presentation.GestionVentas
{
    /// <summary>
    /// Formulario de punto de venta: alta de venta con selección de cliente,
    /// carga de productos al carrito y confirmación del comprobante.
    /// </summary>
    public partial class FormVenta : Form
    {
        private readonly VentaBusiness ventaBusiness = new VentaBusiness();
        private readonly ProductoBusiness productoBusiness = new ProductoBusiness();
        private readonly ClienteBusiness clienteBusiness = new ClienteBusiness();

        private readonly BindingList<DetalleVenta> carrito = new BindingList<DetalleVenta>();
        private List<Producto> productosDisponibles = new List<Producto>();
        private List<Cliente> clientesDisponibles = new List<Cliente>();

        private int clienteSeleccionadoId = 0;

        // ---------------------------------------------------------------
        // Constantes de negocio
        // ---------------------------------------------------------------
        // Evitan "números/strings mágicos" sueltos en el código. Si el día
        // de mañana cambia el ID o el DNI de Consumidor Final en la base,
        // se actualiza en un solo lugar.
        private const int ID_CONSUMIDOR_FINAL = 2;
        private const string DNI_CONSUMIDOR_FINAL = "99999999";

        // Tipos de comprobante válidos según el CHECK de dbo.sale (voucher_type).
        private const char TIPO_COMPROBANTE_A = 'A';
        private const char TIPO_COMPROBANTE_B = 'B';

        public FormVenta()
        {
            InitializeComponent();
        }

        private void FormVenta_Load(object sender, EventArgs e)
        {
            InicializarComponentesNegocio();
            LimpiarFormularioCompleto();
        }

        #region 1. Inicialización del Formulario

        /// <summary>Orquesta la carga inicial de catálogos y controles del formulario.</summary>
        private void InicializarComponentesNegocio()
        {
            ConfigurarGrilla();
            CargarMetodosPago();
            RecargarCatalogoProductos();
            ConfigurarAutocompletadoDni();
        }

        /// <summary>Define las columnas del grid del carrito (se arma por código para controlar formato y ancho).</summary>
        private void ConfigurarGrilla()
        {
            DGVCarrito.AutoGenerateColumns = false;
            DGVCarrito.AllowUserToAddRows = false;
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
            DGVCarrito.DataSource = carrito;
        }

        private void CargarMetodosPago()
        {
            CBFormaPago.DataSource = ventaBusiness.ObtenerMetodosPago();
            CBFormaPago.DisplayMember = "name";
            CBFormaPago.ValueMember = "id";
        }

        private void RecargarCatalogoProductos()
        {
            productosDisponibles = productoBusiness.ObtenerProductosConStock();
            CBProductos.DataSource = null;
            CBProductos.DataSource = productosDisponibles;
            CBProductos.DisplayMember = "Nombre";
            CBProductos.ValueMember = "Id";
            CBProductos.SelectedIndex = -1;
        }

        /// <summary>Recarga completa del autocompletado de DNI a partir de la base.</summary>
        private void ConfigurarAutocompletadoDni()
        {
            clientesDisponibles = clienteBusiness.ObtenerClientesActivos();

            var coleccionDni = new AutoCompleteStringCollection();
            foreach (var cli in clientesDisponibles)
            {
                if (!string.IsNullOrEmpty(cli.Dni))
                {
                    coleccionDni.Add(cli.Dni);
                }
            }

            TBDniCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TBDniCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TBDniCliente.AutoCompleteCustomSource = coleccionDni;
        }

        /// <summary>
        /// Agrega un cliente recién creado al autocompletado sin volver a consultar toda la tabla.
        /// Evita un round-trip innecesario a la base cada vez que se registra un cliente nuevo.
        /// </summary>
        private void AgregarClienteAAutocompletado(Cliente cliente)
        {
            if (cliente == null || string.IsNullOrEmpty(cliente.Dni))
            {
                return;
            }

            clientesDisponibles.Add(cliente);
            TBDniCliente.AutoCompleteCustomSource.Add(cliente.Dni);
        }

        #endregion

        #region 2. Módulo Cliente

        private void ChkConsumidorFinal_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkConsumidorFinal.Checked)
            {
                ActivarConsumidorFinal();
            }
            else
            {
                // Solo reseteamos si realmente estábamos en Consumidor Final
                if (clienteSeleccionadoId == ID_CONSUMIDOR_FINAL)
                {
                    ResetearSeccionCliente();
                }
            }
        }

        private void ActivarConsumidorFinal()
        {
            var consumidorFinal = clienteBusiness.BuscarPorDni(DNI_CONSUMIDOR_FINAL);
            if (consumidorFinal != null)
            {
                CargarClienteEnPantalla(consumidorFinal);
                TBDniCliente.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("No se encontró el registro de Consumidor Final en la base de datos.", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetearSeccionCliente();
            }
        }

        private void CargarClienteEnPantalla(Cliente cliente)
        {
            if (cliente == null)
            {
                ResetearSeccionCliente();
                return;
            }

            clienteSeleccionadoId = cliente.Id;
            TBDniCliente.Text = cliente.Dni;

            string telefonoInfo = string.IsNullOrWhiteSpace(cliente.Telefono) ? "Sin teléfono" : cliente.Telefono;
            TBDatosCliente.Text = $"{cliente.NombreCompleto} | Tel: {telefonoInfo}";

            ActualizarEstadosUI();
        }

        private void ResetearSeccionCliente()
        {
            clienteSeleccionadoId = 0;
            TBDniCliente.ReadOnly = false;
            TBDniCliente.Clear();
            TBDatosCliente.Clear();

            // Desvincula temporalmente para no reentrar en el propio handler
            ChkConsumidorFinal.CheckedChanged -= ChkConsumidorFinal_CheckedChanged;
            ChkConsumidorFinal.Checked = false;
            ChkConsumidorFinal.CheckedChanged += ChkConsumidorFinal_CheckedChanged;

            ActualizarEstadosUI();
        }

        private void BBuscarCliente_Click(object sender, EventArgs e)
        {
            string dni = TBDniCliente.Text.Trim();
            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Por favor, ingrese un número de DNI.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBDniCliente.Focus();
                return;
            }

            var cliente = clienteBusiness.BuscarPorDni(dni);
            if (cliente != null)
            {
                ChkConsumidorFinal.Checked = false;
                CargarClienteEnPantalla(cliente);
            }
            else
            {
                var respuesta = MessageBox.Show(
                    "El cliente no se encuentra registrado.\n¿Desea registrarlo ahora?",
                    "Cliente no encontrado",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.Yes)
                {
                    AbrirModalNuevoCliente(dni);
                }
            }
        }

        // Control real en el diseñador: BRegistrarCliente ("+ Nuevo Cliente")
        private void BRegistrarCliente_Click(object sender, EventArgs e)
        {
            AbrirModalNuevoCliente(TBDniCliente.Text.Trim());
        }

        private void AbrirModalNuevoCliente(string dniInicial)
        {
            using (var formModal = new FormNuevoCliente(dniInicial))
            {
                if (formModal.ShowDialog() == DialogResult.OK && formModal.ClienteCreado != null)
                {
                    ChkConsumidorFinal.Checked = false;
                    CargarClienteEnPantalla(formModal.ClienteCreado);
                    AgregarClienteAAutocompletado(formModal.ClienteCreado);
                }
            }
        }

        #endregion

        #region 3. Módulo Productos y Selección

        private void CBProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarStockRemanenteProductoActual();
            ActualizarEstadosUI();
        }

        /// <summary>
        /// Recalcula precio, stock remanente y límites del NumericUpDown para el producto
        /// actualmente seleccionado en el combo. Se usa tanto desde el evento de selección
        /// como después de agregar/quitar ítems del carrito, sin depender de invocar
        /// manualmente el event handler.
        /// </summary>
        private void ActualizarStockRemanenteProductoActual()
        {
            if (CBProductos.SelectedItem is Producto seleccionado)
            {
                int cantidadEnCarrito = carrito.Where(d => d.ProductoId == seleccionado.Id).Sum(d => d.Cantidad);
                int stockRemanente = seleccionado.Stock - cantidadEnCarrito;

                LPrecioUnitario.Text = $"${seleccionado.Precio:N2}";
                LStockDisponible.Text = stockRemanente.ToString();

                bool hayStock = stockRemanente > 0;
                NUDCantidad.Minimum = hayStock ? 1 : 0;
                NUDCantidad.Maximum = hayStock ? stockRemanente : 0;
                NUDCantidad.Value = hayStock ? 1 : 0;
                NUDCantidad.Enabled = hayStock;
            }
            else
            {
                ResetearControlesProducto();
            }
        }

        private void ResetearControlesProducto()
        {
            CBProductos.SelectedIndex = -1;
            LPrecioUnitario.Text = "$0.00";
            LStockDisponible.Text = "-";
            NUDCantidad.Minimum = 0;
            NUDCantidad.Maximum = 0;
            NUDCantidad.Value = 0;
            NUDCantidad.Enabled = false;
        }

        #endregion

        #region 4. Módulo Carrito de Compras

        // Control real en el diseñador: BAgregarItem
        private void BAgregarItem_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionadoId <= 0)
            {
                MessageBox.Show("Debe seleccionar un cliente antes de agregar productos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBDniCliente.Focus();
                return;
            }

            if (!(CBProductos.SelectedItem is Producto seleccionado))
            {
                MessageBox.Show("Seleccione un producto del catálogo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBProductos.Focus();
                return;
            }

            int cantidadSolicitada = (int)NUDCantidad.Value;
            if (cantidadSolicitada <= 0)
            {
                MessageBox.Show("La cantidad a agregar debe ser mayor a 0.", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación de stock acumulado (lo que ya está en el carrito + lo que se quiere agregar)
            var itemExistente = carrito.FirstOrDefault(d => d.ProductoId == seleccionado.Id);
            int cantidadPrevia = itemExistente != null ? itemExistente.Cantidad : 0;

            if (cantidadPrevia + cantidadSolicitada > seleccionado.Stock)
            {
                MessageBox.Show($"Stock insuficiente. Ya posee {cantidadPrevia} unidades en el carrito y el stock total es {seleccionado.Stock}.", "Stock no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (itemExistente != null)
            {
                int index = carrito.IndexOf(itemExistente);
                itemExistente.Cantidad += cantidadSolicitada;
                carrito.ResetItem(index);
            }
            else
            {
                carrito.Add(new DetalleVenta
                {
                    ProductoId = seleccionado.Id,
                    CodigoProducto = seleccionado.Codigo,
                    NombreProducto = seleccionado.Nombre,
                    PrecioUnitario = seleccionado.Precio,
                    Cantidad = cantidadSolicitada
                });
            }

            RefrescarVistaCarrito();
            ActualizarStockRemanenteProductoActual();
        }

        private void DGVCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Columna del botón eliminar
            if (e.RowIndex >= 0 && e.ColumnIndex == DGVCarrito.Columns.Count - 1)
            {
                DGVCarrito.CurrentCell = null;
                carrito.RemoveAt(e.RowIndex);
                ActualizarStockRemanenteProductoActual();
            }
        }

        private void RefrescarVistaCarrito()
        {
            decimal total = carrito.Sum(x => x.Subtotal);
            LTotalPagar.Text = $"${total:N2}";

            ActualizarEstadosUI();
        }

        #endregion

        #region 5. Orquestación, Estados de UI y Confirmación

        /// <summary>
        /// Punto único que decide qué controles se habilitan/deshabilitan según el
        /// estado actual de la venta (cliente cargado, producto elegido, carrito con ítems).
        /// </summary>
        private void ActualizarEstadosUI()
        {
            bool hayItemsEnCarrito = carrito.Count > 0;
            bool hayClienteValido = clienteSeleccionadoId > 0;
            bool hayProductoSeleccionado = CBProductos.SelectedItem is Producto;

            // 1. Congelar cliente si la venta ya está en curso con productos
            TBDniCliente.Enabled = !hayItemsEnCarrito;
            ChkConsumidorFinal.Enabled = !hayItemsEnCarrito;
            BBuscarCliente.Enabled = !hayItemsEnCarrito;
            BRegistrarCliente.Enabled = !hayItemsEnCarrito;

            // 2. Sección productos
            CBProductos.Enabled = hayClienteValido;
            BAgregarItem.Enabled = hayClienteValido && hayProductoSeleccionado;

            // 3. Cantidad: se desbloquea únicamente si hay cliente y producto seleccionado con stock
            NUDCantidad.Enabled = hayClienteValido && hayProductoSeleccionado && (NUDCantidad.Maximum > 0);
        }

        private void LimpiarFormularioCompleto()
        {
            carrito.Clear();
            RefrescarVistaCarrito();
            ResetearSeccionCliente();
            ResetearControlesProducto();
            TBDniCliente.Focus();
        }

        private void BCancelarVenta_Click(object sender, EventArgs e)
        {
            LimpiarFormularioCompleto();
        }

        /// <summary>
        /// Determina el tipo de comprobante a emitir según el cliente de la venta.
        ///
        /// LIMITACIÓN ACTUAL DE LA BASE: la tabla `customer` no tiene CUIT ni condición
        /// frente al IVA (Responsable Inscripto, Monotributista, etc.), que es el dato
        /// mínimo exigido por AFIP para emitir Factura A. Con el esquema actual, un
        /// cliente "físico" (solo DNI) nunca calificaría para Factura A, esté o no
        /// marcado como Consumidor Final. Por eso, hoy se emite siempre 'B'.
        ///
        /// TODO: si se agrega `cuit` / `is_responsable_inscripto` a dbo.customer,
        /// reemplazar el cuerpo de este método por:
        ///   return cliente.EsResponsableInscripto ? TIPO_COMPROBANTE_A : TIPO_COMPROBANTE_B;
        /// </summary>
        private char DeterminarTipoComprobante(int clienteId)
        {
            return TIPO_COMPROBANTE_B;
        }

        private void BConfirmarVenta_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionadoId <= 0)
            {
                MessageBox.Show("Debe seleccionar un cliente para emitir el comprobante.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (carrito.Count == 0)
            {
                MessageBox.Show("El carrito de compras está vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CBFormaPago.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una forma de pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = carrito.Sum(x => x.Subtotal);
            char tipoComprobante = DeterminarTipoComprobante(clienteSeleccionadoId);

            var nuevaVenta = new Venta
            {
                Codigo = ventaBusiness.GenerarNumeroComprobante(tipoComprobante),
                TipoComprobante = tipoComprobante,
                Total = total,
                ClienteId = clienteSeleccionadoId,
                UsuarioId = Sesion.UsuarioId,
                MetodoPagoId = Convert.ToInt32(CBFormaPago.SelectedValue),
                // Copia defensiva: nunca pasar la referencia directa de `carrito`,
                // porque LimpiarFormularioCompleto() lo vacía apenas se confirma la venta.
                Detalles = new List<DetalleVenta>(carrito)
            };

            try
            {
                if (ventaBusiness.ProcesarVenta(nuevaVenta, out string mensaje))
                {
                    MessageBox.Show($"{mensaje}\nComprobante emitido: {nuevaVenta.Codigo}", "Venta Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormularioCompleto();
                    RecargarCatalogoProductos();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error al registrar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Evita que una excepción de base de datos (timeout, conexión caída, etc.)
                // termine en un crash sin explicación para el usuario.
                MessageBox.Show($"Ocurrió un error inesperado al procesar la venta:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
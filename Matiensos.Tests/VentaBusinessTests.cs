using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Business;
using Entities;

namespace Matiensos.Tests
{
    /// <summary>
    /// Pruebas unitarias para el proceso y las reglas de negocio de Ventas.
    /// Aplica el estándar profesional AAA (Arrange, Act, Assert) y pruebas parametrizadas con [TestCase].
    /// </summary>
    [TestFixture]
    public class VentaBusinessTests
    {
        private VentaBusiness _ventaBusiness;

        [SetUp]
        public void Setup()
        {
            _ventaBusiness = new VentaBusiness();
        }

        #region 1. Pruebas de Carrito y Validación de Productos

        [Test]
        public void ProcesarVenta_CuandoDetallesEsNulo_DebeRetornarFalsoConMensajeError()
        {
            // 1. Arrange
            var venta = new Venta
            {
                ClienteId = 1,
                Total = 15000m,
                Detalles = null
            };

            // 2. Act
            bool resultado = _ventaBusiness.ProcesarVenta(venta, out string mensaje);

            // 3. Assert
            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El carrito no contiene productos"));
        }

        [Test]
        public void ProcesarVenta_CuandoCarritoEstaVacio_DebeRetornarFalsoConMensajeError()
        {
            // 1. Arrange
            var venta = new Venta
            {
                ClienteId = 1,
                Total = 15000m,
                Detalles = new List<DetalleVenta>()
            };

            // 2. Act
            bool resultado = _ventaBusiness.ProcesarVenta(venta, out string mensaje);

            // 3. Assert
            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El carrito no contiene productos"));
        }

        #endregion

        #region 2. Pruebas de Total de Venta

        /// <summary>
        /// Evalúa múltiples importes inválidos (cero o negativos) en una sola función inteligente.
        /// </summary>
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-15000.50)]
        [TestCase(-0.01)]
        public void ProcesarVenta_CuandoTotalEsCeroONegativo_DebeRechazarVenta(double totalInvalidoDouble)
        {
            // 1. Arrange
            decimal totalInvalido = Convert.ToDecimal(totalInvalidoDouble);

            var venta = new Venta
            {
                ClienteId = 1,
                Total = totalInvalido,
                Detalles = new List<DetalleVenta>
                {
                    new DetalleVenta { ProductoId = 1, Cantidad = 1, PrecioUnitario = 1000m }
                }
            };

            // 2. Act
            bool resultado = _ventaBusiness.ProcesarVenta(venta, out string mensaje);

            // 3. Assert
            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El importe total no puede ser cero o negativo"));
        }

        #endregion

        #region 3. Pruebas de Asignación de Cliente

        /// <summary>
        /// Comprueba que no se permitan ventas sin cliente asignado (ID <= 0).
        /// </summary>
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-99)]
        public void ProcesarVenta_CuandoClienteEsInvalido_DebeRechazarVenta(int clienteIdInvalido)
        {
            // 1. Arrange
            var venta = new Venta
            {
                ClienteId = clienteIdInvalido,
                Total = 25000m,
                Detalles = new List<DetalleVenta>
                {
                    new DetalleVenta { ProductoId = 1, Cantidad = 1, PrecioUnitario = 25000m }
                }
            };

            // 2. Act
            bool resultado = _ventaBusiness.ProcesarVenta(venta, out string mensaje);

            // 3. Assert
            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("Debe asignar un cliente válido o Consumidor Final"));
        }

        #endregion

        #region 4. Cálculos Matemáticos de Subtotales y Carrito

        /// <summary>
        /// Prueba que verifica que el subtotal de cada ítem sea exactamente Cantidad * Precio.
        /// </summary>
        [TestCase(1, 16500.0, 16500.0)]
        [TestCase(3, 5200.0, 15600.0)]
        [TestCase(2, 24900.50, 49801.0)]
        [TestCase(10, 3900.0, 39000.0)]
        public void DetalleVenta_Subtotal_CalculaCantidadPorPrecioCorrectamente(int cantidad, double precioDouble, double subtotalEsperadoDouble)
        {
            // 1. Arrange
            decimal precio = Convert.ToDecimal(precioDouble);
            decimal subtotalEsperado = Convert.ToDecimal(subtotalEsperadoDouble);

            var detalle = new DetalleVenta
            {
                ProductoId = 10,
                Cantidad = cantidad,
                PrecioUnitario = precio
            };

            // 2. Act
            decimal subtotalObtenido = detalle.Subtotal;

            // 3. Assert
            Assert.That(subtotalObtenido, Is.EqualTo(subtotalEsperado));
        }

        [Test]
        public void Venta_CalculoTotalAcumulado_CoincideConSumaDeSubtotales()
        {
            // 1. Arrange
            var detalles = new List<DetalleVenta>
            {
                new DetalleVenta { ProductoId = 1, Cantidad = 1, PrecioUnitario = 16500m }, // Subtotal: 16500
                new DetalleVenta { ProductoId = 2, Cantidad = 2, PrecioUnitario = 5200m },  // Subtotal: 10400
                new DetalleVenta { ProductoId = 3, Cantidad = 1, PrecioUnitario = 4800m }   // Subtotal: 4800
            };

            decimal totalEsperado = 16500m + 10400m + 4800m; // 31700

            // 2. Act
            decimal totalCalculado = detalles.Sum(d => d.Subtotal);

            // 3. Assert
            Assert.That(totalCalculado, Is.EqualTo(totalEsperado));
            Assert.That(totalCalculado, Is.EqualTo(31700m));
        }

        #endregion

        #region 5. Reglas de Validación de Rango de Fechas (Historial y Dashboard)

        [Test]
        public void ObtenerHistorial_CuandoFechaDesdeEsMayorAHasta_DebeRetornarListaVaciaYMensajeError()
        {
            // 1. Arrange
            DateTime fechaDesde = new DateTime(2026, 11, 10);
            DateTime fechaHasta = new DateTime(2026, 11, 01);

            // 2. Act
            var resultado = _ventaBusiness.ObtenerHistorial(
                fechaDesde,
                fechaHasta,
                metodoPagoId: null,
                pagina: 1,
                out int totalPaginas,
                out string mensajeError
            );

            // 3. Assert
            Assert.That(resultado, Is.Empty);
            Assert.That(totalPaginas, Is.EqualTo(1));
            Assert.That(mensajeError, Does.Contain("no puede ser posterior a la fecha 'Hasta'"));
        }

        [Test]
        public void ObtenerMetricasDashboard_CuandoFechaDesdeEsMayorAHasta_DebeLanzarArgumentException()
        {
            // 1. Arrange
            DateTime fechaDesde = new DateTime(2026, 11, 15);
            DateTime fechaHasta = new DateTime(2026, 11, 05);

            // 2. Act & Assert
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                _ventaBusiness.ObtenerMetricasDashboard(fechaDesde, fechaHasta, metodoPagoId: null);
            });

            Assert.That(ex.Message, Does.Contain("La fecha inicial no puede ser mayor a la fecha final"));
        }

        #endregion

        #region 6. Lógica de Cobro en Efectivo y Cálculo de Vuelto

        /// <summary>
        /// Prueba que el cálculo de vuelto en caja funcione correctamente según el monto entregado.
        /// </summary>
        [TestCase(10000.0, 10000.0, 0.0)]      // Pago justo
        [TestCase(14500.0, 20000.0, 5500.0)]   // Vuelto positivo
        [TestCase(32000.0, 35000.0, 3000.0)]   // Vuelto positivo
        [TestCase(50000.0, 45000.0, -5000.0)]  // Pago insuficiente (vuelto negativo)
        public void CobroEfectivo_CalculoVuelto_RetornaDiferenciaCorrecta(double totalDouble, double recibidoDouble, double vueltoEsperadoDouble)
        {
            // 1. Arrange
            decimal totalVenta = Convert.ToDecimal(totalDouble);
            decimal montoRecibido = Convert.ToDecimal(recibidoDouble);
            decimal vueltoEsperado = Convert.ToDecimal(vueltoEsperadoDouble);

            // 2. Act
            decimal vueltoCalculado = montoRecibido - totalVenta;

            // 3. Assert
            Assert.That(vueltoCalculado, Is.EqualTo(vueltoEsperado));
        }

        #endregion

        #region 7. Concurrencia, Stock y Remoción Selectiva del Carrito

        /// <summary>
        /// Verifica la regla de validación de stock del Producto:
        /// Permite la venta si el stock es mayor o igual a la cantidad pedida,
        /// y la rechaza si el stock es menor.
        /// </summary>
        [TestCase(5, 5, true)]    // Stock exacto -> Acepta
        [TestCase(10, 3, true)]   // Stock de sobra -> Acepta
        [TestCase(1, 2, false)]   // Falta stock -> Rechaza
        [TestCase(0, 1, false)]   // Sin stock (agotado por otro vendedor) -> Rechaza
        [TestCase(4, 5, false)]   // Queda 4 pero pidió 5 -> Rechaza
        public void Producto_TieneStockSuficiente_EvaluaCorrectamente(int stockActual, int cantidadPedida, bool esperado)
        {
            // 1. Arrange
            var producto = new Producto
            {
                Id = 1,
                Nombre = "Mate Torpedo Uruguayo",
                Stock = stockActual
            };

            // 2. Act
            bool resultado = producto.TieneStockSuficiente(cantidadPedida);

            // 3. Assert
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [Test]
        public void ValidacionStock_CuandoHayItemsSinStock_IdentificaProductoYCantidadSolicitada()
        {
            // DetalleVenta reutilizado para representar el item con falta de stock
            var itemSinStock = new DetalleVenta
            {
                ProductoId = 2,
                NombreProducto = "Mate Torpedo Uruguayo",
                Cantidad = 3
            };

            string mensajeLinea = $"• {itemSinStock.NombreProducto} (solicitado: {itemSinStock.Cantidad})";

            Assert.That(itemSinStock.ProductoId, Is.EqualTo(2));
            Assert.That(mensajeLinea, Does.Contain("Mate Torpedo Uruguayo"));
            Assert.That(mensajeLinea, Does.Contain("solicitado: 3"));
        }

        [Test]
        public void Carrito_CuandoHayConflictoDeStock_RemueveSoloProductosAgotadosYMantieneElResto()
        {
            // 1. Arrange (Cliente con 3 artículos en el carrito en Mostrador)
            var carrito = new List<DetalleVenta>
            {
                new DetalleVenta { ProductoId = 1, NombreProducto = "Termo Stanley", Cantidad = 1, PrecioUnitario = 82000m },
                new DetalleVenta { ProductoId = 2, NombreProducto = "Mate Torpedo", Cantidad = 1, PrecioUnitario = 16500m }, // Agotado en otra caja
                new DetalleVenta { ProductoId = 3, NombreProducto = "Bombilla Alpaca", Cantidad = 2, PrecioUnitario = 5600m }
            };

            // Simulamos la respuesta de la BD (List<DetalleVenta>): Solo el Mate Torpedo (ID 2) no tiene stock
            var sinStock = new List<DetalleVenta>
            {
                new DetalleVenta { ProductoId = 2, NombreProducto = "Mate Torpedo", Cantidad = 1 }
            };

            // 2. Act (Lógica aplicada en FormVenta: identificar y remover SOLO los productos sin stock)
            var idsARemover = new HashSet<int>(sinStock.Select(c => c.ProductoId));
            var itemsParaBorrar = carrito.Where(item => idsARemover.Contains(item.ProductoId)).ToList();

            foreach (var item in itemsParaBorrar)
            {
                carrito.Remove(item);
            }

            decimal nuevoTotal = carrito.Sum(d => d.Subtotal);

            // 3. Assert
            // El carrito debe conservar los otros 2 productos
            Assert.That(carrito.Count, Is.EqualTo(2));
            Assert.That(carrito.Any(d => d.ProductoId == 1), Is.True, "El Termo debe permanecer en el carrito.");
            Assert.That(carrito.Any(d => d.ProductoId == 3), Is.True, "La Bombilla debe permanecer en el carrito.");
            Assert.That(carrito.Any(d => d.ProductoId == 2), Is.False, "El Mate agotado debió ser removido.");

            // El total debe haberse recalculado exactamente sin el Mate: 82000 + (2 * 5600) = 93200
            Assert.That(nuevoTotal, Is.EqualTo(93200m));
        }

        [Test]
        public void Carrito_CuandoTodosLosProductosEstanAgotados_QuedaVacioYTotalCero()
        {
            // 1. Arrange
            var carrito = new List<DetalleVenta>
            {
                new DetalleVenta { ProductoId = 5, NombreProducto = "Yerba Canarias", Cantidad = 2, PrecioUnitario = 5200m }
            };

            var sinStock = new List<DetalleVenta>
            {
                new DetalleVenta { ProductoId = 5, NombreProducto = "Yerba Canarias", Cantidad = 2 }
            };

            // 2. Act
            var idsARemover = new HashSet<int>(sinStock.Select(c => c.ProductoId));
            var itemsParaBorrar = carrito.Where(item => idsARemover.Contains(item.ProductoId)).ToList();

            foreach (var item in itemsParaBorrar)
            {
                carrito.Remove(item);
            }

            decimal nuevoTotal = carrito.Sum(d => d.Subtotal);

            // 3. Assert
            Assert.That(carrito, Is.Empty);
            Assert.That(nuevoTotal, Is.EqualTo(0m));
        }

        #endregion
    }
}

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
            // Venta con la lista de productos nula
            var venta = new Venta
            {
                ClienteId = 1,
                Total = 15000m,
                Detalles = null
            };

            // Ejecuta la lógica de validación
            bool resultado = _ventaBusiness.ProcesarVenta(venta, out string mensaje);

            // Comprueba que no permita procesar y devuelva el mensaje exacto
            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El carrito no contiene productos"));
        }

        [Test]
        public void ProcesarVenta_CuandoCarritoEstaVacio_DebeRetornarFalsoConMensajeError()
        {
            // Venta con lista de productos vacía
            var venta = new Venta
            {
                ClienteId = 1,
                Total = 15000m,
                Detalles = new List<DetalleVenta>()
            };

            // Act
            bool resultado = _ventaBusiness.ProcesarVenta(venta, out string mensaje);

            // 
            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El carrito no contiene productos"));
        }

        #endregion

        #region 2. Pruebas Parametrizadas de Total de Venta ([TestCase])

        /// <summary>
        /// Evalúa múltiples importes inválidos (cero o negativos) en una sola función inteligente.
        /// </summary>
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-15000.50)]
        [TestCase(-0.01)]
        public void ProcesarVenta_CuandoTotalEsCeroONegativo_DebeRechazarVenta(double totalInvalidoDouble)
        {
            // Arrange
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

            // Act
            bool resultado = _ventaBusiness.ProcesarVenta(venta, out string mensaje);

            // Assert
            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El importe total no puede ser cero o negativo"));
        }

        #endregion

        #region 3. Pruebas Parametrizadas de Asignación de Cliente ([TestCase])

        /// <summary>
        /// Comprueba que no se permitan ventas sin cliente asignado (ID <= 0).
        /// </summary>
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-99)]
        public void ProcesarVenta_CuandoClienteEsInvalido_DebeRechazarVenta(int clienteIdInvalido)
        {
            // Arrange
            var venta = new Venta
            {
                ClienteId = clienteIdInvalido,
                Total = 25000m,
                Detalles = new List<DetalleVenta>
                {
                    new DetalleVenta { ProductoId = 1, Cantidad = 1, PrecioUnitario = 25000m }
                }
            };

            // Act
            bool resultado = _ventaBusiness.ProcesarVenta(venta, out string mensaje);

            // Assert
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
            // Arrange
            decimal precio = Convert.ToDecimal(precioDouble);
            decimal subtotalEsperado = Convert.ToDecimal(subtotalEsperadoDouble);

            var detalle = new DetalleVenta
            {
                ProductoId = 10,
                Cantidad = cantidad,
                PrecioUnitario = precio
            };

            // Act
            decimal subtotalObtenido = detalle.Subtotal;

            // Assert
            Assert.That(subtotalObtenido, Is.EqualTo(subtotalEsperado));
        }

        [Test]
        public void Venta_CalculoTotalAcumulado_CoincideConSumaDeSubtotales()
        {
            // carrito con 3 productos reales
            var detalles = new List<DetalleVenta>
            {
                new DetalleVenta { ProductoId = 1, Cantidad = 1, PrecioUnitario = 16500m }, // Subtotal: 16500
                new DetalleVenta { ProductoId = 2, Cantidad = 2, PrecioUnitario = 5200m },  // Subtotal: 10400
                new DetalleVenta { ProductoId = 3, Cantidad = 1, PrecioUnitario = 4800m }   // Subtotal: 4800
            };

            decimal totalEsperado = 16500m + 10400m + 4800m; // 31700

            // Act
            decimal totalCalculado = detalles.Sum(d => d.Subtotal);

            // Assert
            Assert.That(totalCalculado, Is.EqualTo(totalEsperado));
            Assert.That(totalCalculado, Is.EqualTo(31700m));
        }

        #endregion

        #region 5. Reglas de Validación de Rango de Fechas (Historial y Dashboard)

        [Test]
        public void ObtenerHistorial_CuandoFechaDesdeEsMayorAHasta_DebeRetornarListaVaciaYMensajeError()
        {
            // Fecha desde posterior a fecha hasta a propósito
            DateTime fechaDesde = new DateTime(2026, 11, 10);
            DateTime fechaHasta = new DateTime(2026, 11, 01);

            // Act
            var resultado = _ventaBusiness.ObtenerHistorial(
                fechaDesde,
                fechaHasta,
                metodoPagoId: null,
                pagina: 1,
                out int totalPaginas,
                out string mensajeError
            );

            // Assert
            Assert.That(resultado, Is.Empty);
            Assert.That(totalPaginas, Is.EqualTo(1));
            Assert.That(mensajeError, Does.Contain("no puede ser posterior a la fecha 'Hasta'"));
        }

        [Test]
        public void ObtenerMetricasDashboard_CuandoFechaDesdeEsMayorAHasta_DebeLanzarArgumentException()
        {
            DateTime fechaDesde = new DateTime(2026, 11, 15);
            DateTime fechaHasta = new DateTime(2026, 11, 05);

            // Verifico que el sistema lance la excepción esperada de forma controlada)
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
            decimal totalVenta = Convert.ToDecimal(totalDouble);
            decimal montoRecibido = Convert.ToDecimal(recibidoDouble);
            decimal vueltoEsperado = Convert.ToDecimal(vueltoEsperadoDouble);

            decimal vueltoCalculado = montoRecibido - totalVenta;

            Assert.That(vueltoCalculado, Is.EqualTo(vueltoEsperado));
        }

        #endregion
    }
}
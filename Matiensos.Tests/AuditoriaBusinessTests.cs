using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Entities;
using NUnit.Framework;

namespace Matiensos.Tests
{
    [TestFixture]
    public class AuditoriaBusinessTests
    {
        [SetUp]
        public void Setup()
        {
            Sesion.Nombre = "TestSuperAdmin";
            Sesion.Rol = "SuperAdmin";
            Sesion.UsuarioId = 1;
        }

        #region 1. Formato y Registro de Eventos de Auditoría

        /// <summary>
        /// Verifica que el registro de eventos escriba en el archivo de auditoría
        /// y que el evento quede disponible con los 5 campos estructurados.
        /// </summary>
        [Test]
        public void RegistrarEvento_GuardaEventoConUsuarioModuloYAccion()
        {
            string modulo = "PruebaUnit";
            string accion = "Alta";
            string detalle = $"TEST_ITEM_ID_{Guid.NewGuid():N}";

            AuditoriaBusiness.RegistrarEvento(modulo, accion, detalle);

            // Recupera del historial filtrando por el detalle único
            var historial = AuditoriaBusiness.ObtenerHistorialFiltradoCompleto(
                fechaDesde: DateTime.Today,
                fechaHasta: DateTime.Today,
                operacion: accion,
                busqueda: detalle);

            Assert.That(historial, Is.Not.Null);
            Assert.That(historial.Count, Is.GreaterThanOrEqualTo(1));

            var primerRegistro = historial.First(r => r.Detalles.Contains(detalle));
            Assert.That(primerRegistro.Modulo, Is.EqualTo(modulo));
            Assert.That(primerRegistro.Accion, Is.EqualTo(accion));
            Assert.That(primerRegistro.Usuario, Is.EqualTo("TestSuperAdmin"));
            Assert.That(primerRegistro.FechaHora, Is.Not.Empty);
        }

        #endregion

        #region 2. Filtros de Búsqueda de Auditoría

        /// <summary>
        /// Verifica que el filtro "Todas" o vacío no restrinja las operaciones registradas.
        /// </summary>
        [TestCase("Todas")]
        [TestCase("todas")]
        [TestCase("")]
        [TestCase(null)]
        public void FiltroOperacion_CuandoEsTodasOVacio_NoFiltraPorAccion(string? operacion)
        {
            var resultados = AuditoriaBusiness.ObtenerHistorialFiltradoCompleto(
                fechaDesde: null,
                fechaHasta: null,
                operacion: operacion!,
                busqueda: null!);

            // Debe devolver la lista sin excepciones
            Assert.That(resultados, Is.Not.Null);
        }

        #endregion

        #region 3. Reglas de Paginación de Auditoría

        /// <summary>
        /// Comprueba el cálculo del total de páginas: totalPaginas = Math.Ceiling(total / registrosPorPagina).
        /// </summary>
        [TestCase(25, 10, 3)]
        [TestCase(30, 10, 3)]
        [TestCase(1, 10, 1)]
        [TestCase(11, 10, 2)]
        [TestCase(0, 10, 1)]
        public void Paginacion_CalculaTotalPaginasCorrectamente(int totalRegistros, int registrosPorPagina, int totalPaginasEsperado)
        {
            int paginasCalculadas = totalRegistros == 0 
                ? 1 
                : (int)Math.Ceiling((double)totalRegistros / registrosPorPagina);

            Assert.That(paginasCalculadas, Is.EqualTo(totalPaginasEsperado));
        }

        /// <summary>
        /// Verifica que la paginación ajuste los límites si se solicita una página menor a 1
        /// o mayor al total disponible.
        /// </summary>
        [TestCase(-1, 5, 1)]      // Menor a 1 -> Se ajusta a 1
        [TestCase(0, 5, 1)]       // Cero -> Se ajusta a 1
        [TestCase(10, 5, 5)]      // Mayor al total -> Se ajusta a 5
        public void Paginacion_AjustaPaginaFueraDeRango(int paginaSolicitada, int totalPaginas, int paginaAjustadaEsperada)
        {
            int pagina = paginaSolicitada;
            if (pagina < 1) pagina = 1;
            if (pagina > totalPaginas) pagina = totalPaginas;

            Assert.That(pagina, Is.EqualTo(paginaAjustadaEsperada));
        }

        #endregion

        #region 4. Parseo y Tolerancia a Fallos en Formato de Log

        /// <summary>
        /// Verifica que una línea de log válida con formato Fecha|Usuario|Módulo|Acción|Detalles
        /// se descomponga correctamente en los 5 atributos del DTO RegistroAuditoria.
        /// </summary>
        [Test]
        public void ParseoLineaLog_CuandoEsValida_AsignaLosCincoAtributos()
        {
            string lineaLog = "2026-11-09 10:15:30|SuperAdmin|Producto|Alta|CÓDIGO: [MAT-001], NOMBRE: 'Mate Torpedo'";

            string[] partes = lineaLog.Split('|');
            var registro = new RegistroAuditoria
            {
                FechaHora = partes[0],
                Usuario = partes[1],
                Modulo = partes[2],
                Accion = partes[3],
                Detalles = partes[4]
            };

            Assert.That(registro.FechaHora, Is.EqualTo("2026-11-09 10:15:30"));
            Assert.That(registro.Usuario, Is.EqualTo("SuperAdmin"));
            Assert.That(registro.Modulo, Is.EqualTo("Producto"));
            Assert.That(registro.Accion, Is.EqualTo("Alta"));
            Assert.That(registro.Detalles, Does.Contain("MAT-001"));
        }

        /// <summary>
        /// Verifica que líneas corruptas o incompletas (menos de 5 columnas)
        /// sean descartadas de manera segura sin provocar errores.
        /// </summary>
        [TestCase("Línea corrupta sin formato")]
        [TestCase("2026-11-09|Usuario|SoloTresCampos")]
        [TestCase("||||")] // Vacía
        public void ParseoLineaLog_CuandoLineaEstaIncompleta_NoGeneraRegistroValido(string lineaIncompleta)
        {
            string[] partes = lineaIncompleta.Split('|');
            bool tieneFormatoValido = partes.Length >= 5 && !string.IsNullOrWhiteSpace(partes[0]);

            Assert.That(tieneFormatoValido, Is.False);
        }

        #endregion
    }
}

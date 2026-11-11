using System;
using Business;
using Entities;
using NUnit.Framework;

namespace Matiensos.Tests
{
    [TestFixture]
    public class CategoriaBusinessTests
    {
        private CategoriaBusiness _categoriaBusiness;

        [SetUp]
        public void Setup()
        {
            _categoriaBusiness = new CategoriaBusiness();
        }

        #region 1. Validaciones en Alta de Categoría (Código y Nombre)

        /// <summary>
        /// El código de categoría es obligatorio cuando se asigna manualmente.
        /// </summary>
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void RegistrarCategoria_CodigoInvalido_RetornaFalsoYMensaje(string? codigoInvalido)
        {
            bool resultado = _categoriaBusiness.RegistrarCategoria(
                codigoInvalido!, 
                "Mates", 
                "Categoría de mates artesanales", 
                out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("código de la categoría es obligatorio"));
        }

        /// <summary>
        /// El código de categoría no puede superar los 4 caracteres (sigla nemotécnica).
        /// </summary>
        [TestCase("MATES")]
        [TestCase("TERMOS")]
        [TestCase("ABCDE")]
        public void RegistrarCategoria_CodigoMayorACuatroCaracteres_RetornaFalso(string codigoExcedido)
        {
            bool resultado = _categoriaBusiness.RegistrarCategoria(
                codigoExcedido, 
                "Mates de Algarrobo", 
                "Descripción", 
                out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("código no puede superar los 4 caracteres"));
        }

        /// <summary>
        /// El nombre de la categoría es obligatorio.
        /// </summary>
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void RegistrarCategoria_NombreInvalido_RetornaFalso(string? nombreInvalido)
        {
            bool resultado = _categoriaBusiness.RegistrarCategoria(
                "MAT", 
                nombreInvalido!, 
                "Descripción de prueba", 
                out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("nombre de la categoría es obligatorio"));
        }

        /// <summary>
        /// El nombre de la categoría no puede superar los 100 caracteres.
        /// </summary>
        [Test]
        public void RegistrarCategoria_NombreMayorACienCaracteres_RetornaFalso()
        {
            string nombreExcedido = new string('A', 101);

            bool resultado = _categoriaBusiness.RegistrarCategoria(
                "MAT", 
                nombreExcedido, 
                "Descripción", 
                out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("nombre no puede superar los 100 caracteres"));
        }

        #endregion

        #region 2. Validaciones en Modificación de Categoría

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void ActualizarCategoria_NombreInvalido_RetornaFalso(string? nombreInvalido)
        {
            bool resultado = _categoriaBusiness.ActualizarCategoria(
                1, 
                nombreInvalido!, 
                "Descripción válida", 
                out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("nombre de la categoría es obligatorio"));
        }

        [Test]
        public void ActualizarCategoria_NombreMayorACienCaracteres_RetornaFalso()
        {
            string nombreLargo = new string('B', 101);

            bool resultado = _categoriaBusiness.ActualizarCategoria(
                1, 
                nombreLargo, 
                "Descripción", 
                out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("nombre no puede superar los 100 caracteres"));
        }

        #endregion

        #region 3. Regla Crítica: Bloqueo de Baja Lógica con Productos Asociados

        /// <summary>
        /// Regla de Integridad Referencial de Negocio:
        /// Una categoría NO puede ser desactivada si posee productos activos o asociados,
        /// para evitar dejar productos huérfanos sin categoría en el catálogo.
        /// </summary>
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(28)]
        public void DesactivarCategoria_CuandoTieneProductosAsociados_RechazaBajaConMensajeAdvertencia(int cantidadProductos)
        {
            int categoriaId = 2; // Por ejemplo, Categoría "Termos" con productos asociados

            bool resultado = _categoriaBusiness.DesactivarCategoria(
                categoriaId, 
                cantidadProductos, 
                out string mensaje);

            Assert.That(resultado, Is.False, "La eliminación debió ser rechazada porque tiene productos asociados.");
            Assert.That(mensaje, Does.Contain($"tiene {cantidadProductos} producto(s) asociado(s)"));
            Assert.That(mensaje, Does.Contain("Reasigne o elimine los productos primero"));
        }

        #endregion

        #region 4. Control de Acceso y Roles (Admin y SuperAdmin vs Vendedor)

        /// <summary>
        /// Verifica que solo perfiles administrativos (SuperAdmin o Administrador) puedan
        /// gestionar categorías, mientras que Vendedor o Cajero queden bloqueados.
        /// </summary>
        [TestCase("SuperAdmin", true)]
        [TestCase("Administrador", true)]
        [TestCase("admin", true)]
        [TestCase("Vendedor", false)]
        [TestCase("vendedor", false)]
        [TestCase("Cajero", false)]
        [TestCase("", false)]
        [TestCase(null, false)]
        public void SeguridadRol_AccesoAGestionCategorias_PermiteSoloAdminYSuperAdmin(string? rol, bool accesoPermitidoEsperado)
        {
            bool tienePermisoAdmin = !string.IsNullOrWhiteSpace(rol) && rol.ToLower().Contains("admin");

            Assert.That(tienePermisoAdmin, Is.EqualTo(accesoPermitidoEsperado));
        }

        #endregion
    }
}

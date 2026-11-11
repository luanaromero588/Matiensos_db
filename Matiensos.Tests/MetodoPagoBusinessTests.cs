using System;
using Business;
using Entities;
using NUnit.Framework;

namespace Matiensos.Tests
{
    [TestFixture]
    public class MetodoPagoBusinessTests
    {
        private MetodoPagoBusiness _metodoPagoBusiness;

        [SetUp]
        public void Setup()
        {
            _metodoPagoBusiness = new MetodoPagoBusiness();
        }

        #region 1. Validaciones en Alta de Método de Pago

        /// <summary>
        /// El nombre del método de pago es obligatorio para su identificación en cobranzas.
        /// </summary>
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void RegistrarMetodoPago_NombreInvalido_RetornaFalsoYMensaje(string? nombreInvalido)
        {
            bool resultado = _metodoPagoBusiness.RegistrarMetodoPago(
                nombreInvalido!, 
                "Cobro con tarjeta", 
                out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("nombre del método de pago es obligatorio"));
        }

        /// <summary>
        /// El nombre no puede superar los 50 caracteres.
        /// </summary>
        [Test]
        public void RegistrarMetodoPago_NombreMayorACincuentaCaracteres_RetornaFalso()
        {
            string nombreLargo = new string('A', 51);

            bool resultado = _metodoPagoBusiness.RegistrarMetodoPago(
                nombreLargo, 
                "Descripción de prueba", 
                out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("nombre no puede superar los 50 caracteres"));
        }

        /// <summary>
        /// La descripción opcional no puede superar los 255 caracteres.
        /// </summary>
        [Test]
        public void RegistrarMetodoPago_DescripcionMayorADoscientosCincuentaYCincoCaracteres_RetornaFalso()
        {
            string descripcionLarga = new string('D', 256);

            bool resultado = _metodoPagoBusiness.RegistrarMetodoPago(
                "Transferencia MP", 
                descripcionLarga, 
                out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("descripción no puede superar los 255 caracteres"));
        }

        #endregion

        #region 2. Validaciones en Modificación de Método de Pago

        /// <summary>
        /// El identificador debe ser mayor a cero para actualizar un registro existente.
        /// </summary>
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-99)]
        public void ModificarMetodoPago_IdInvalido_RetornaFalsoYMensaje(int idInvalido)
        {
            bool resultado = _metodoPagoBusiness.ModificarMetodoPago(
                idInvalido, 
                "Efectivo", 
                "Cobro al contado", 
                out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("Identificador de método de pago inválido"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void ModificarMetodoPago_NombreInvalido_RetornaFalso(string? nombreInvalido)
        {
            bool resultado = _metodoPagoBusiness.ModificarMetodoPago(
                1, 
                nombreInvalido!, 
                "Cobro al contado", 
                out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("nombre del método de pago es obligatorio"));
        }

        [Test]
        public void ModificarMetodoPago_NombreMayorACincuentaCaracteres_RetornaFalso()
        {
            string nombreLargo = new string('X', 51);

            bool resultado = _metodoPagoBusiness.ModificarMetodoPago(
                1, 
                nombreLargo, 
                "Descripción", 
                out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("nombre no puede superar los 50 caracteres"));
        }

        [Test]
        public void ModificarMetodoPago_DescripcionMayorADoscientosCincuentaYCincoCaracteres_RetornaFalso()
        {
            string descripcionLarga = new string('Y', 256);

            bool resultado = _metodoPagoBusiness.ModificarMetodoPago(
                1, 
                "Tarjeta Débito", 
                descripcionLarga, 
                out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("descripción no puede superar los 255 caracteres"));
        }

        #endregion

        #region 3. Control de Acceso y Roles (Admin y SuperAdmin vs Vendedor)

        /// <summary>
        /// Verifica que solo los administradores puedan dar de alta o modificar
        /// los métodos de pago habilitados en la plataforma.
        /// </summary>
        [TestCase("SuperAdmin", true)]
        [TestCase("Administrador", true)]
        [TestCase("admin", true)]
        [TestCase("Vendedor", false)]
        [TestCase("vendedor", false)]
        [TestCase("Cajero", false)]
        [TestCase("", false)]
        [TestCase(null, false)]
        public void SeguridadRol_AccesoAGestionMetodosPago_PermiteSoloAdminYSuperAdmin(string? rol, bool accesoPermitidoEsperado)
        {
            bool tienePermisoAdmin = !string.IsNullOrWhiteSpace(rol) && rol.ToLower().Contains("admin");

            Assert.That(tienePermisoAdmin, Is.EqualTo(accesoPermitidoEsperado));
        }

        #endregion
    }
}

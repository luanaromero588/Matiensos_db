using System;
using Business;
using NUnit.Framework;

namespace Matiensos.Tests
{
    [TestFixture]
    public class UsuarioBusinessTests
    {
        private UsuarioBusiness _usuarioBusiness;

        [SetUp]
        public void Setup()
        {
            _usuarioBusiness = new UsuarioBusiness();
        }

        #region 1. Validación de Nombre y Apellido de Usuario

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void ValidarNombre_CuandoEsNuloOVacio_DebeRetornarFalso(string? nombreInvalido)
        {
            bool esValido = _usuarioBusiness.ValidarNombre(nombreInvalido!, out string mensaje);

            Assert.That(esValido, Is.False);
            Assert.That(mensaje, Does.Contain("El nombre es obligatorio"));
        }

        [TestCase("A")]
        [TestCase("x")]
        public void ValidarNombre_CuandoTieneMenosDeDosLetras_DebeRetornarFalso(string nombreCorto)
        {
            bool esValido = _usuarioBusiness.ValidarNombre(nombreCorto, out string mensaje);

            Assert.That(esValido, Is.False);
            Assert.That(mensaje, Does.Contain("al menos 2 letras"));
        }

        [TestCase("Ana")]
        [TestCase("Gonzalo")]
        [TestCase("María José")]
        public void ValidarNombre_CuandoEsValido_DebeRetornarVerdadero(string nombreValido)
        {
            bool esValido = _usuarioBusiness.ValidarNombre(nombreValido, out string mensaje);

            Assert.That(esValido, Is.True);
            Assert.That(mensaje, Is.Empty);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void ValidarApellido_CuandoEsNuloOVacio_DebeRetornarFalso(string? apellidoInvalido)
        {
            bool esValido = _usuarioBusiness.ValidarApellido(apellidoInvalido!, out string mensaje);

            Assert.That(esValido, Is.False);
            Assert.That(mensaje, Does.Contain("El apellido es obligatorio"));
        }

        [TestCase("B")]
        public void ValidarApellido_CuandoTieneMenosDeDosLetras_DebeRetornarFalso(string apellidoCorto)
        {
            bool esValido = _usuarioBusiness.ValidarApellido(apellidoCorto, out string mensaje);

            Assert.That(esValido, Is.False);
            Assert.That(mensaje, Does.Contain("al menos 2 letras"));
        }

        [TestCase("López")]
        [TestCase("Martínez")]
        public void ValidarApellido_CuandoEsValido_DebeRetornarVerdadero(string apellidoValido)
        {
            bool esValido = _usuarioBusiness.ValidarApellido(apellidoValido, out string mensaje);

            Assert.That(esValido, Is.True);
            Assert.That(mensaje, Is.Empty);
        }

        #endregion

        #region 2. Validación de Correo Electrónico

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void ValidarCorreo_CuandoEsNuloOVacio_DebeRetornarFalso(string? emailInvalido)
        {
            bool esValido = _usuarioBusiness.ValidarCorreo(emailInvalido!, out string mensaje);

            Assert.That(esValido, Is.False);
            Assert.That(mensaje, Does.Contain("El correo es obligatorio"));
        }

        [TestCase("correo-sin-arroba.com")]
        [TestCase("usuario@sinpunto")]
        public void ValidarCorreo_CuandoFaltaArrobaOPunto_DebeRetornarFalso(string emailInvalido)
        {
            bool esValido = _usuarioBusiness.ValidarCorreo(emailInvalido, out string mensaje);

            Assert.That(esValido, Is.False);
            Assert.That(mensaje, Does.Contain("Debe contener '@' y un dominio válido"));
        }

        [TestCase("admin@matiensos.com")]
        [TestCase("vendedor.caja1@matiensos.com.ar")]
        public void ValidarCorreo_CuandoFormatoEsCorrecto_DebeRetornarVerdadero(string correoValido)
        {
            bool esValido = _usuarioBusiness.ValidarCorreo(correoValido, out string mensaje);

            Assert.That(esValido, Is.True);
            Assert.That(mensaje, Is.Empty);
        }

        #endregion

        #region 3. Validación de Teléfono

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void ValidarTelefono_CuandoEsNuloOVacio_DebeRetornarFalso(string? telInvalido)
        {
            bool esValido = _usuarioBusiness.ValidarTelefono(telInvalido!, out string mensaje);

            Assert.That(esValido, Is.False);
            Assert.That(mensaje, Does.Contain("El teléfono es obligatorio"));
        }

        [TestCase("12345")] // Menos de 6 caracteres
        [TestCase("123456789012345678901")] // 21 caracteres (más de 20)
        public void ValidarTelefono_CuandoLongitudEsInvalida_DebeRetornarFalso(string telInvalido)
        {
            bool esValido = _usuarioBusiness.ValidarTelefono(telInvalido, out string mensaje);

            Assert.That(esValido, Is.False);
            Assert.That(mensaje, Does.Contain("entre 6 y 20 caracteres"));
        }

        [TestCase("3794-ABCDEF")]
        [TestCase("3794.123456")]
        public void ValidarTelefono_CuandoTieneCaracteresNoPermitidos_DebeRetornarFalso(string telInvalido)
        {
            bool esValido = _usuarioBusiness.ValidarTelefono(telInvalido, out string mensaje);

            Assert.That(esValido, Is.False);
            Assert.That(mensaje, Does.Contain("Solo puede contener números, espacios o guiones"));
        }

        [TestCase("3794123456")]
        [TestCase("0379-445566")]
        [TestCase("11 4455 6677")]
        public void ValidarTelefono_CuandoEsValido_DebeRetornarVerdadero(string telValido)
        {
            bool esValido = _usuarioBusiness.ValidarTelefono(telValido, out string mensaje);

            Assert.That(esValido, Is.True);
            Assert.That(mensaje, Is.Empty);
        }

        #endregion

        #region 4. Validación de Contraseña (Alta vs Edición)

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void ValidarContraseña_CuandoEsNuevoYEstaVacia_DebeRetornarFalso(string? passInvalida)
        {
            bool esValido = _usuarioBusiness.ValidarContraseña(passInvalida!, esEdicion: false, out string mensaje);

            Assert.That(esValido, Is.False);
            Assert.That(mensaje, Does.Contain("obligatoria para nuevos usuarios"));
        }

        [TestCase("1234567")] // 7 caracteres (requiere mínimo 8)
        [TestCase("abc")]
        public void ValidarContraseña_CuandoEsNuevoYEsMenorAOchoCaracteres_DebeRetornarFalso(string passCorta)
        {
            bool esValido = _usuarioBusiness.ValidarContraseña(passCorta, esEdicion: false, out string mensaje);

            Assert.That(esValido, Is.False);
            Assert.That(mensaje, Does.Contain("al menos 8 caracteres"));
        }

        [Test]
        public void ValidarContraseña_CuandoEsEdicionYVacia_DebePermitirConservarContraseñaActual()
        {
            // En edición, si el usuario no ingresa contraseña, se mantiene la existente
            bool esValido = _usuarioBusiness.ValidarContraseña("", esEdicion: true, out string mensaje);

            Assert.That(esValido, Is.True);
            Assert.That(mensaje, Is.Empty);
        }

        [TestCase("1234567")]
        public void ValidarContraseña_CuandoEsEdicionYMenorAOchoCaracteres_DebeRetornarFalso(string passCorta)
        {
            bool esValido = _usuarioBusiness.ValidarContraseña(passCorta, esEdicion: true, out string mensaje);

            Assert.That(esValido, Is.False);
            Assert.That(mensaje, Does.Contain("al menos 8 caracteres"));
        }

        [TestCase("SuperPass2026!")]
        [TestCase("12345678")]
        public void ValidarContraseña_CuandoTieneOchoOMasCaracteres_DebeRetornarVerdadero(string passValida)
        {
            bool esValido = _usuarioBusiness.ValidarContraseña(passValida, esEdicion: false, out string mensaje);

            Assert.That(esValido, Is.True);
            Assert.That(mensaje, Is.Empty);
        }

        #endregion

        #region 5. Validación de Rol

        [TestCase(null)]
        [TestCase(0)]
        [TestCase(-1)]
        public void ValidarRol_CuandoEsInvalido_DebeRetornarFalso(int? rolInvalido)
        {
            bool esValido = _usuarioBusiness.ValidarRol(rolInvalido, out string mensaje);

            Assert.That(esValido, Is.False);
            Assert.That(mensaje, Does.Contain("Debe seleccionar un rol válido"));
        }

        [TestCase(1)] // SuperAdmin
        [TestCase(2)] // Administrador
        [TestCase(3)] // Vendedor
        public void ValidarRol_CuandoEsValido_DebeRetornarVerdadero(int rolValido)
        {
            bool esValido = _usuarioBusiness.ValidarRol(rolValido, out string mensaje);

            Assert.That(esValido, Is.True);
            Assert.That(mensaje, Is.Empty);
        }

        #endregion

        #region 6. Validación Integral (ValidarDatos)

        [Test]
        public void ValidarDatos_CuandoDniEsInvalido_LanzaArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                _usuarioBusiness.ValidarDatos(
                    "Carlos", 
                    "Pérez", 
                    "DNI-INVALIDO", 
                    "carlos@matiensos.com", 
                    "3794123456", 
                    1, 
                    "12345678", 
                    esNuevo: true);
            });

            Assert.That(ex!.Message, Does.Contain("7 u 8 números sin puntos ni espacios"));
        }

        [Test]
        public void ValidarDatos_CuandoTodosLosDatosSonCorrectos_NoLanzaExcepcion()
        {
            Assert.DoesNotThrow(() =>
            {
                _usuarioBusiness.ValidarDatos(
                    "Lautaro", 
                    "Benítez", 
                    "41234567", 
                    "lautaro@matiensos.com", 
                    "3794-556677", 
                    2, 
                    "Password2026", 
                    esNuevo: true);
            });
        }

        #endregion
    }
}

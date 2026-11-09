using System;
using Business;
using Entities;
using NUnit.Framework;

namespace Matiensos.Tests
{
    [TestFixture]
    public class ClienteBusinessTests
    {
        private ClienteBusiness _clienteBusiness;

        [SetUp]
        public void Setup()
        {
            _clienteBusiness = new ClienteBusiness();
        }

        #region 1. Validación de DNI de Cliente (Formato Estricto 7-8 Dígitos Numéricos)

        /// <summary>
        /// El DNI es obligatorio y debe tener exactamente entre 7 y 8 dígitos numéricos,
        /// sin puntos, guiones, espacios ni letras.
        /// </summary>
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase("40.123.456")]     // Con puntos -> Inválido
        [TestCase("40-123456")]      // Con guiones -> Inválido
        [TestCase("4012345A")]       // Con letras -> Inválido
        [TestCase("123456")]         // 6 dígitos (demasiado corto) -> Inválido
        [TestCase("123456789")]      // 9 dígitos (demasiado largo) -> Inválido
        public void RegistrarCliente_DniInvalido_RetornaFalsoYMensajeEsperado(string? dniInvalido)
        {
            var cliente = new Cliente
            {
                Dni = dniInvalido!,
                Nombre = "Martín",
                Apellido = "Fierro",
                Email = "martin.fierro@pampa.com"
            };

            bool resultado = _clienteBusiness.RegistrarCliente(cliente, 1, out int nuevoId, out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(nuevoId, Is.EqualTo(0));
            Assert.That(mensaje, Does.Contain("El DNI debe tener 7 u 8 caracteres estrictamente numéricos"));
        }

        #endregion

        #region 2. Validación de Nombre y Apellido de Cliente

        /// <summary>
        /// El nombre es obligatorio y debe tener al menos 2 caracteres.
        /// </summary>
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase("A")] // 1 sola letra -> Demasiado corto
        public void RegistrarCliente_NombreInvalido_RetornaFalsoYMensajeEsperado(string? nombreInvalido)
        {
            var cliente = new Cliente
            {
                Dni = "38123456",
                Nombre = nombreInvalido!,
                Apellido = "González",
                Email = "gonzalez@correo.com"
            };

            bool resultado = _clienteBusiness.RegistrarCliente(cliente, 1, out int nuevoId, out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El nombre es obligatorio y debe tener al menos 2 caracteres"));
        }

        /// <summary>
        /// El apellido es obligatorio y debe tener al menos 2 caracteres.
        /// </summary>
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase("G")] // 1 sola letra -> Demasiado corto
        public void RegistrarCliente_ApellidoInvalido_RetornaFalsoYMensajeEsperado(string? apellidoInvalido)
        {
            var cliente = new Cliente
            {
                Dni = "38123456",
                Nombre = "Joaquín",
                Apellido = apellidoInvalido!,
                Email = "joaquin@correo.com"
            };

            bool resultado = _clienteBusiness.RegistrarCliente(cliente, 1, out int nuevoId, out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El apellido es obligatorio y debe tener al menos 2 caracteres"));
        }

        #endregion

        #region 3. Validación de Correo Electrónico de Cliente

        /// <summary>
        /// Si se provee un email, debe cumplir con un formato válido estándar.
        /// Formatos con errores tipográficos o incompletos deben ser rechazados.
        /// </summary>
        [TestCase("cliente-sin-arroba.com")]
        [TestCase("cliente@sin-punto")]
        [TestCase("@sin-usuario.com")]
        [TestCase("cliente@dominio.")]
        public void RegistrarCliente_EmailConFormatoInvalido_RetornaFalsoYMensajeEsperado(string emailInvalido)
        {
            var cliente = new Cliente
            {
                Dni = "35987654",
                Nombre = "Florencia",
                Apellido = "Benítez",
                Email = emailInvalido
            };

            bool resultado = _clienteBusiness.RegistrarCliente(cliente, 1, out int nuevoId, out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El formato del correo electrónico ingresado no es válido"));
        }

        #endregion

        #region 4. Validación de Objeto Nulo

        [Test]
        public void RegistrarCliente_ClienteNulo_RetornaFalsoYMensaje()
        {
            bool resultado = _clienteBusiness.RegistrarCliente(null!, 1, out int nuevoId, out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(nuevoId, Is.EqualTo(0));
            Assert.That(mensaje, Does.Contain("Los datos del cliente no fueron provistos"));
        }

        #endregion

        #region 5. Validación en Modificación y Estado de Cliente

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-50)]
        public void ModificarCliente_IdInvalido_RetornaFalsoYMensaje(int idInvalido)
        {
            var cliente = new Cliente
            {
                Id = idInvalido,
                Nombre = "Carlos",
                Apellido = "Vargas"
            };

            bool resultado = _clienteBusiness.ModificarCliente(cliente, out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("Identificador de cliente inválido"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void ModificarCliente_NombreInvalido_RetornaFalso(string? nombreInvalido)
        {
            var cliente = new Cliente
            {
                Id = 1,
                Nombre = nombreInvalido!,
                Apellido = "Vargas"
            };

            bool resultado = _clienteBusiness.ModificarCliente(cliente, out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El nombre es obligatorio"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void ModificarCliente_ApellidoInvalido_RetornaFalso(string? apellidoInvalido)
        {
            var cliente = new Cliente
            {
                Id = 1,
                Nombre = "Carlos",
                Apellido = apellidoInvalido!
            };

            bool resultado = _clienteBusiness.ModificarCliente(cliente, out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El apellido es obligatorio"));
        }

        [TestCase("correo-sin-arroba.com")]
        [TestCase("correo_invalido")]
        public void ModificarCliente_EmailInvalido_RetornaFalso(string emailInvalido)
        {
            var cliente = new Cliente
            {
                Id = 1,
                Nombre = "Carlos",
                Apellido = "Vargas",
                Email = emailInvalido
            };

            bool resultado = _clienteBusiness.ModificarCliente(cliente, out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("El formato del correo electrónico no es válido"));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-99)]
        public void CambiarEstado_IdInvalido_RetornaFalso(int idInvalido)
        {
            bool resultado = _clienteBusiness.CambiarEstado(idInvalido, false, out string mensaje);

            Assert.That(resultado, Is.False);
            Assert.That(mensaje, Does.Contain("Identificador inválido"));
        }

        #endregion
    }
}

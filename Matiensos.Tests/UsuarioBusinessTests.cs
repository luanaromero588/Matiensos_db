using NUnit.Framework;
using Business;

namespace Matiensos.Tests
{
    [TestFixture] // Le indica a Visual Studio que esta clase contiene pruebas
    public class UsuarioBusinessTests
    {
        private UsuarioBusiness _usuarioBusiness;

        [SetUp] // Se ejecuta automáticamente antes de cada test
        public void Setup()
        {
            _usuarioBusiness = new UsuarioBusiness();
        }

        [Test] // Marca que este método específico es un test
        public void ValidarCorreo_CuandoFormatoEsInvalido_DebeRetornarFalso()
        {
            // 1. Arrange (Preparo un correo que está mal a propósito)
            string correoInvalido = "correo-sin-arroba.com";

            // 2. Act (Llamo a la lógica de negocio de tu sistema)
            bool esValido = _usuarioBusiness.ValidarCorreo(correoInvalido, out string mensaje);

            // 3. Assert (Verifico que el sistema no lo deje pasar)
            Assert.That(esValido, Is.False);
            Assert.That(mensaje, Does.Contain("formato válido"));
        }

        [Test]
        public void ValidarCorreo_CuandoFormatoEsCorrecto_DebeRetornarVerdadero()
        {
            // 1. Arrange
            string correoValido = "cajero@matiensos.com";

            // 2. Act
            bool esValido = _usuarioBusiness.ValidarCorreo(correoValido, out string mensaje);

            // 3. Assert
            Assert.That(esValido, Is.True);
            Assert.That(mensaje, Is.Empty);
        }
    }
}
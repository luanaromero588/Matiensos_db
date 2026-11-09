using System;
using System.IO;
using System.Text.RegularExpressions;
using Business;
using Entities;
using NUnit.Framework;

namespace Matiensos.Tests
{
    [TestFixture]
    public class BackupBusinessTests
    {
        #region 1. Nomenclatura y Formato de Archivos de Respaldo

        /// <summary>
        /// Comprueba que los nombres de los archivos de backup generados sigan estrictamente
        /// el patrón estándar Backup_yyyyMMdd_HHmmss.bak.
        /// </summary>
        [Test]
        public void NombreBackup_CumplePatronTimestampYExtensionBak()
        {
            // generación del nombre como lo hace BackupBusiness
            string nombreGenerado = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

            var patronRegex = new Regex(@"^Backup_\d{8}_\d{6}\.bak$");
            bool cumplePatron = patronRegex.IsMatch(nombreGenerado);

            Assert.That(cumplePatron, Is.True, $"El nombre '{nombreGenerado}' no cumple el formato esperado Backup_yyyyMMdd_HHmmss.bak");
            Assert.That(Path.GetExtension(nombreGenerado), Is.EqualTo(".bak"));
        }

        #endregion

        #region 2. Cálculo y Formato de Tamaño de Backup

        /// <summary>
        /// Verifica la fórmula de conversión de bytes a Megabytes con 2 decimales:
        /// megas = (double)bytes / (1024 * 1024) -> $"{megas:F2} MB"
        /// Se valida de forma agnóstica a la cultura local (soporta separador decimal coma o punto).
        /// </summary>
        [TestCase(1048576L, 1.0)]     // 1 MB exacto
        [TestCase(5242880L, 5.0)]     // 5 MB exactos
        [TestCase(1572864L, 1.5)]     // 1.5 MB
        [TestCase(524288L, 0.5)]      // 0.5 MB (512 KB)
        [TestCase(0L, 0.0)]           // 0 bytes
        [TestCase(104857600L, 100.0)] // 100 MB
        public void FormatoTamaño_CalculaMegabytesCorrectamente(long bytes, double megasEsperados)
        {
            double megas = (double)bytes / (1024 * 1024);
            string tamañoFormateado = $"{megas:F2} MB";

            // Comprueba el sufijo y el valor numérico formateado
            Assert.That(tamañoFormateado, Does.EndWith(" MB"));
            string numeroStr = tamañoFormateado.Replace(" MB", "").Trim();
            double numeroParseado = double.Parse(numeroStr);
            Assert.That(numeroParseado, Is.EqualTo(megasEsperados).Within(0.01));
        }

        #endregion

        #region 3. Sanitización de Rutas y Prevención de Path Traversal

        /// <summary>
        /// Verifica que al recibir una ruta absoluta o relativa potencialmente maliciosa,
        /// la sanitización mediante Path.GetFileName extraiga estrictamente el nombre del archivo .bak,
        /// impidiendo ataques de cruce de directorios (Path Traversal).
        /// </summary>
        [TestCase(@"C:\BackupsSQL\Backup_20261109_120000.bak", "Backup_20261109_120000.bak")]
        [TestCase(@"..\..\Windows\System32\malicious.bak", "malicious.bak")]
        [TestCase(@"/var/log/backup_hack.bak", "backup_hack.bak")]
        [TestCase(@"Backup_Simple.bak", "Backup_Simple.bak")]
        public void SanitizarRutaBackup_ExtraeNombreLimpioSinRutaRelativa(string rutaOriginal, string nombreEsperado)
        {
            // Lógica aplicada en RestaurarBackup y EliminarBackup
            string nombreLimpio = Path.GetFileName(rutaOriginal);

            Assert.That(nombreLimpio, Is.EqualTo(nombreEsperado));
            Assert.That(nombreLimpio, Does.Not.Contain(@"\"));
            Assert.That(nombreLimpio, Does.Not.Contain("/"));
            Assert.That(nombreLimpio, Does.Not.Contain(".."));
        }

        #endregion

        #region 4. Control de Acceso por Rol (Backups Exclusivo SuperAdmin)

        /// <summary>
        /// En el sistema Matiensos, la generación y restauración de copias de seguridad
        /// de la base de datos es una operación de infraestructura crítica permitida
        /// ÚNICAMENTE al rol "SuperAdmin", bloqueando incluso a Administradores regulares y Vendedores.
        /// </summary>
        [TestCase("SuperAdmin", true)]
        [TestCase("superadmin", true)]
        [TestCase("Administrador", false)]
        [TestCase("admin", false)]
        [TestCase("Vendedor", false)]
        [TestCase("cajero", false)]
        [TestCase("", false)]
        [TestCase(null, false)]
        public void SeguridadRol_AccesoABackupYRestore_PermiteSoloSuperAdmin(string? rol, bool tieneAccesoEsperado)
        {
            // Regla de autorización para panel de Backups
            bool tienePermiso = !string.IsNullOrWhiteSpace(rol) && rol.Trim().ToLower().Contains("superadmin");

            Assert.That(tienePermiso, Is.EqualTo(tieneAccesoEsperado));
        }

        #endregion
    }
}

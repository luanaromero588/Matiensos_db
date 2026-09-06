using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace Presentation
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // EJECUTAR SEEDER ANTES DE ABRIR PANTALLAS
            try
                {
                    DatabaseSeeder.Seed();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear la base de datos: " + ex.Message);
                }

                Application.Run(new form1());
        }
    }
}

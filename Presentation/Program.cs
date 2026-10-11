using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //Application.Run(new Presentation.GestionVentas.FormNuevoCliente());
            //Application.Run(new Presentation.FormLogin());
            //Application.Run(new Presentation.FormUsuario());
            Application.Run(new Presentation.FormCategorias());
           //Application.Run(new Presentation.FormProductos());
            //Application.Run(new Presentation.FormMetodosPago());
            //Application.Run(new Presentation.FormPanelSuperAdmin());
        }
    }
}
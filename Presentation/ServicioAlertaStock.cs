using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Matiensos
{
    public class ServicioAlertaStock
    {
        private readonly string _cadenaConexion = "Server=127.0.0.1,1433; Database=Matiensos_db; User Id=sa; Password=Matiensos123!; TrustServerCertificate=True;";

        public void EnviarReporteStockBajo()
        {
            StringBuilder filasHtml = new StringBuilder();
            int totalCriticos = 0;

            try
            {
                using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
                using (SqlCommand comando = new SqlCommand("dbo.sp_ObtenerReporteStockCritico", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (!lector.HasRows)
                        {
                            MessageBox.Show("No hay productos con stock crítico en este momento.", "Control de Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        while (lector.Read())
                        {
                            totalCriticos++;
                            string codigo = lector["code"].ToString();
                            string nombre = lector["name"].ToString();
                            int stock = Convert.ToInt32(lector["stock"]);
                            int minimo = Convert.ToInt32(lector["minimum_stock"]);
                            int reponer = Convert.ToInt32(lector["cantidad_a_reponer"]);

                            
                            filasHtml.Append($@"
                            <tr style='border-bottom: 1px solid #f0f0f0;'>
                                <td style='padding: 10px 8px; font-family: monospace; font-size: 13px; color: #666666;'>{codigo}</td>
                                <td style='padding: 10px 8px; font-weight: 500; color: #333333;'>{nombre}</td>
                                <td style='padding: 10px 8px; text-align: center; font-weight: bold; color: {(stock <= 0 ? "#dc3545" : "#333333")};'>{stock}</td>
                                <td style='padding: 10px 8px; text-align: center; color: #777777;'>{minimo}</td>
                                <td style='padding: 10px 8px; text-align: center; font-weight: bold; color: #dc3545;'>+{reponer}</td>
                            </tr>");
                        }
                    }
                }

                if (totalCriticos > 0)
                {
                    DespacharMailtrap(filasHtml.ToString(), totalCriticos);
                    MessageBox.Show($"Reporte enviado con éxito a Mailtrap. Productos críticos: {totalCriticos}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar alerta de stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DespacharMailtrap(string filasTabla, int totalCriticos)
        {

            string urlLogoMatiensos = "https://raw.githubusercontent.com/walterg20/proyecto-bd1-equipo_38/master/docs/assets/logo.png";

            string anioActual = DateTime.Now.Year.ToString();

            string cuerpoHtml = $@"
            <!DOCTYPE html>
            <html lang='es'>
            <head>
                <meta charset='UTF-8'>
            </head>
            <body style='margin: 0; padding: 40px 15px; background-color: #f7f9fa; font-family: -apple-system, BlinkMacSystemFont, ""Segoe UI"", Roboto, Helvetica, Arial, sans-serif;'>
    
                <!-- TARJETA CONTENEDORA -->
                <table align='center' border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 520px; background-color: #ffffff; border-radius: 12px; border: 1px solid #eef0f2; box-shadow: 0 4px 12px rgba(0, 0, 0, 0.05); overflow: hidden;'>
        
                    <!-- CABECERA: LOGO + MARCA -->
                    <tr>
                        <td style='padding: 30px 30px 20px 30px; border-bottom: 1px solid #f2f4f6;'>
                            <table border='0' cellpadding='0' cellspacing='0'>
                                <tr>
                                    <td style='vertical-align: middle; padding-right: 12px;'>
                                        <img src='{urlLogoMatiensos}' alt='Matiensos' width='44' height='44' style='display: block; border-radius: 8px;' onerror=""this.style.display='none'"" />
                                    </td>
                                    <td style='vertical-align: middle;'>
                                        <span style='font-size: 24px; font-weight: 800; color: #2d5a43; letter-spacing: -0.5px;'>
                                            Matiensos
                                        </span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

            <!-- CONTENIDO PRINCIPAL -->
            <tr>
                <td style='padding: 25px 30px 20px 30px;'>
                
                    <h2 style='margin: 0 0 12px 0; font-size: 18px; font-weight: 700; color: #1a202c;'>
                        Alerta de stock crítico
                    </h2>
                
                    <p style='margin: 0 0 20px 0; font-size: 14px; line-height: 1.5; color: #4a5568;'>
                        El sistema detectó que <strong>{totalCriticos}</strong> producto(s) alcanzaron o superaron el nivel mínimo de reposición. A continuación se detalla el faltante actual:
                    </p>

                    <!-- TABLA LIMPIA DE ARTÍCULOS -->
                    <table border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse: collapse; font-size: 13px; margin-bottom: 25px;'>
                        <thead>
                            <tr style='border-bottom: 2px solid #edf2f7; color: #718096; text-transform: uppercase; font-size: 11px; letter-spacing: 0.5px;'>
                                <th style='padding: 8px; text-align: left;'>Cód.</th>
                                <th style='padding: 8px; text-align: left;'>Producto</th>
                                <th style='padding: 8px; text-align: center;'>Stock</th>
                                <th style='padding: 8px; text-align: center;'>Mín.</th>
                                <th style='padding: 8px; text-align: center;'>Falta</th>
                            </tr>
                        </thead>
                        <tbody>
                            {filasTabla}
                        </tbody>
                    </table>

             <!-- BOTÓN PRINCIPAL VERDE -->
                <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                    <tr>
                        <td align='center' style='padding: 5px 0 15px 0;'>
                            <a href='http://matiensos.test/admin/inventory' target='_blank' style='display: inline-block; background-color: #2d5a43; color: #ffffff; text-decoration: none; font-size: 14px; font-weight: 600; padding: 12px 28px; border-radius: 6px; box-shadow: 0 2px 4px rgba(45, 90, 67, 0.2);'>
                                Gestionar inventario
                            </a>
                        </td>
                    </tr>
                </table>

               </td>
             </tr>

            <!-- LÍNEA SEPARADORA INFERIOR -->
            <tr>
                <td style='padding: 0 30px;'>
                    <div style='border-top: 1px solid #f2f4f6;'></div>
                </td>
            </tr>

            <!-- FOOTER DISCRETO -->
            <tr>
                <td style='padding: 20px 30px; text-align: center; font-size: 12px; color: #a0aec0;'>
                    © {anioActual} Matiensos. Todos los derechos reservados.
                </td>
            </tr>

            </table>

            </body>
             </html>";

            using (SmtpClient clienteSmtp = new SmtpClient("sandbox.smtp.mailtrap.io", 2525))
            {
                clienteSmtp.Credentials = new NetworkCredential("5152bf95e3a299", "7aba62863ed54e");
                clienteSmtp.EnableSsl = true;

                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress("alertas@matiensos.com", "Matiensos");
                mensaje.To.Add("superadmin@matiensos.com");
                mensaje.Subject = $"Alerta de stock crítico ({totalCriticos} productos)";
                mensaje.Body = cuerpoHtml;
                mensaje.IsBodyHtml = true;

                clienteSmtp.Send(mensaje);
            }
        }
    }
}
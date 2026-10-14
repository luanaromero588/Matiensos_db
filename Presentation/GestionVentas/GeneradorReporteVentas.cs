using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Entities;

namespace Presentation.GestionVentas
{
    /// <summary>
    /// Clase responsable de generar el documento HTML del reporte de ventas y mostrarlo en el navegador.
    /// </summary>
    public static class GeneradorReporteVentas
    {
        public static void ExportarAWeb(
            List<VentaResumen> ventas, 
            string graficoBase64, 
            string periodo, 
            string filtro, 
            string totalRecaudado, 
            string cantidadTickets, 
            string rubroPrincipal,
            string nombreVendedor,
            bool? esAdmin = null)
        {
            try
            {
                bool esPerfilAdmin = esAdmin ?? (Sesion.Rol != null && !Sesion.Rol.Equals("Vendedor", StringComparison.OrdinalIgnoreCase));
                string etiquetaOperador = esPerfilAdmin ? "Operador" : "Vendedor";

                StringBuilder html = new StringBuilder();
                html.AppendLine("<!DOCTYPE html>");
                html.AppendLine("<html lang='es'><head><meta charset='UTF-8'><title>Reporte de Ventas</title>");
                html.AppendLine("<style>");
                html.AppendLine("body { font-family: 'Segoe UI', Arial, sans-serif; padding: 40px; color: #333; max-width: 950px; margin: auto; }");
                
                html.AppendLine(".company-header { text-align: center; border-bottom: 2px solid #1e3a5f; padding-bottom: 15px; margin-bottom: 20px; }");
                html.AppendLine(".company-header h2 { margin: 0; color: #1e3a5f; font-size: 32px; letter-spacing: 2px; }");
                html.AppendLine(".company-header p { margin: 5px 0 0 0; font-size: 14px; color: #555; }");
                
                html.AppendLine("h1 { text-align: center; color: #1e3a5f; margin-bottom: 20px; font-size: 24px; }");
                html.AppendLine(".header { display: flex; justify-content: space-between; background: #f1f3f5; padding: 10px 15px; border-radius: 5px; margin-bottom: 25px; font-size: 14px; border-left: 4px solid #1e3a5f; }");
                html.AppendLine(".dashboard { display: flex; justify-content: space-between; align-items: center; margin-bottom: 30px; background: #f8f9fa; padding: 15px; border-radius: 8px; border: 1px solid #e9ecef; }");
                html.AppendLine(".metrics p { margin: 10px 0; font-size: 16px; }");
                html.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 10px; }");
                html.AppendLine("th, td { border-bottom: 1px solid #ddd; padding: 10px; text-align: left; font-size: 14px; }");
                html.AppendLine("th { background-color: #1e3a5f; color: white; text-transform: uppercase; }");
                html.AppendLine(".footer { text-align: right; font-size: 20px; font-weight: bold; margin-top: 30px; border-top: 2px solid #1e3a5f; padding-top: 15px; color: #1e3a5f; }");
                
                html.AppendLine("@media print {");
                html.AppendLine("  body { padding: 0; max-width: 100%; }");
                html.AppendLine("  .dashboard { break-inside: avoid; }");
                html.AppendLine("}");
                html.AppendLine("</style></head><body>");

                html.AppendLine("<div class='company-header'>");
                html.AppendLine("  <h2>MATIENSOS S.A.</h2>");
                html.AppendLine("  <p>CUIT: 30-12345678-9 | IVA Responsable Inscripto | Casa Central: Calle Falsa 123</p>");
                html.AppendLine("  <p>Tel: 0800-MATES | Email: administracion@matiensos.com</p>");
                html.AppendLine("</div>");

                html.AppendLine("<h1>REPORTE OPERATIVO DE VENTAS</h1>");
                
                html.AppendLine("<div class='header'>");
                html.AppendLine($"<div><strong>{etiquetaOperador}:</strong> {nombreVendedor}</div>");
                html.AppendLine($"<div><strong>Período:</strong> {periodo}</div>");
                html.AppendLine($"<div><strong>Filtro:</strong> {filtro}</div>");
                html.AppendLine("</div>");

                html.AppendLine("<div class='dashboard'>");
                html.AppendLine("<div class='metrics'>");
                html.AppendLine($"<p><strong>Total Recaudado:</strong> {totalRecaudado}</p>");
                html.AppendLine($"<p><strong>Cantidad de Ventas:</strong> {cantidadTickets}</p>");
                html.AppendLine($"<p><strong>Rubro Principal:</strong> {rubroPrincipal}</p>");
                html.AppendLine("</div>");
                
                html.AppendLine($"<div class='chart'><img src='data:image/png;base64,{graficoBase64}' style='max-height: 260px; margin-left: 20px;' /></div>");
                html.AppendLine("</div>");

                html.AppendLine("<table>");
                if (esPerfilAdmin)
                {
                    html.AppendLine("<thead><tr><th>Código</th><th>Fecha</th><th>Cliente</th><th>Vendedor</th><th>Método</th><th>Total</th></tr></thead>");
                }
                else
                {
                    html.AppendLine("<thead><tr><th>Código</th><th>Fecha</th><th>Cliente</th><th>Método</th><th>Total</th></tr></thead>");
                }
                html.AppendLine("<tbody>");
                
                foreach (var v in ventas)
                {
                    html.AppendLine("<tr>");
                    html.AppendLine($"<td>{v.Codigo}</td>");
                    html.AppendLine($"<td>{v.Fecha:dd/MM/yy HH:mm}</td>");
                    html.AppendLine($"<td>{v.NombreCliente}</td>");
                    if (esPerfilAdmin)
                    {
                        html.AppendLine($"<td>{(string.IsNullOrWhiteSpace(v.NombreVendedor) ? "-" : v.NombreVendedor)}</td>");
                    }
                    html.AppendLine($"<td>{v.NombreMetodoPago}</td>");
                    html.AppendLine($"<td><strong>{v.Total:C2}</strong></td>");
                    html.AppendLine("</tr>");
                }
                
                html.AppendLine("</tbody></table>");
                html.AppendLine($"<div class='footer'>TOTAL GENERAL: {totalRecaudado}</div>");

                html.AppendLine("<script>window.onload = function() { setTimeout(function(){ window.print(); }, 500); }</script>");

                html.AppendLine("</body></html>");

                string archivoTemp = Path.Combine(Path.GetTempPath(), $"Reporte_Ventas_{DateTime.Now:yyyyMMdd_HHmmss}.html");
                File.WriteAllText(archivoTemp, html.ToString());

                Process.Start(new ProcessStartInfo
                {
                    FileName = archivoTemp,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte web: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

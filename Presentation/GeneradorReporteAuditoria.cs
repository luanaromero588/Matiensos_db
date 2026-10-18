using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Entities;

namespace Presentation
{
    /// <summary>
    /// Genera un documento HTML con el reporte de auditoría y trazabilidad para imprimir o guardar como PDF.
    /// </summary>
    public static class GeneradorReporteAuditoria
    {
        public static void ExportarAWeb(
            List<RegistroAuditoria> registros,
            string periodo,
            string operacion,
            string criterioBusqueda,
            string emitidoPor)
        {
            try
            {
                StringBuilder html = new StringBuilder();
                html.AppendLine("<!DOCTYPE html>");
                html.AppendLine("<html lang='es'>");
                html.AppendLine("<head>");
                html.AppendLine("  <meta charset='UTF-8'>");
                html.AppendLine("  <title>Informe de Auditoría y Trazabilidad - Matiensos</title>");
                html.AppendLine("  <style>");
                html.AppendLine("    body { font-family: 'Segoe UI', Arial, sans-serif; padding: 30px; color: #2e3d30; max-width: 1100px; margin: auto; }");
                html.AppendLine("    .company-header { text-align: center; border-bottom: 2px solid #386150; padding-bottom: 12px; margin-bottom: 20px; }");
                html.AppendLine("    .company-header h2 { margin: 0; color: #386150; font-size: 28px; letter-spacing: 2px; }");
                html.AppendLine("    .company-header p { margin: 4px 0 0 0; font-size: 13px; color: #555; }");
                html.AppendLine("    h1 { text-align: center; color: #1f2d26; margin: 15px 0 20px 0; font-size: 22px; text-transform: uppercase; letter-spacing: 1px; }");
                html.AppendLine("    .meta-box { display: grid; grid-template-columns: repeat(2, 1fr); gap: 8px 20px; background: #f4f8f5; border-left: 4px solid #386150; padding: 12px 18px; border-radius: 4px; margin-bottom: 20px; font-size: 13px; }");
                html.AppendLine("    .meta-box div strong { color: #386150; }");
                html.AppendLine("    table { width: 100%; border-collapse: collapse; margin-top: 10px; font-size: 12px; }");
                html.AppendLine("    th, td { border-bottom: 1px solid #d8e2dc; padding: 9px 8px; text-align: left; vertical-align: top; }");
                html.AppendLine("    th { background-color: #386150; color: #ffffff; text-transform: uppercase; font-size: 11px; letter-spacing: 0.5px; }");
                html.AppendLine("    tr:nth-child(even) { background-color: #fcfdfc; }");
                html.AppendLine("    .badge { display: inline-block; padding: 2px 7px; border-radius: 3px; font-weight: bold; font-size: 11px; }");
                html.AppendLine("    .badge-alta { background-color: #e3f2fd; color: #0d47a1; }");
                html.AppendLine("    .badge-modificacion { background-color: #fff3e0; color: #e65100; }");
                html.AppendLine("    .badge-baja { background-color: #ffebee; color: #c62828; }");
                html.AppendLine("    .badge-reactivacion { background-color: #e8f5e9; color: #2e7d32; }");
                html.AppendLine("    .badge-default { background-color: #eceff1; color: #37474f; }");
                html.AppendLine("    .detalles { white-space: pre-wrap; font-family: 'Consolas', monospace; font-size: 11px; color: #333; }");
                html.AppendLine("    .footer { text-align: right; font-size: 13px; font-weight: bold; margin-top: 25px; border-top: 2px solid #386150; padding-top: 12px; color: #386150; }");
                html.AppendLine("    @media print {");
                html.AppendLine("      body { padding: 0; max-width: 100%; }");
                html.AppendLine("      .meta-box { break-inside: avoid; }");
                html.AppendLine("      tr { break-inside: avoid; }");
                html.AppendLine("    }");
                html.AppendLine("  </style>");
                html.AppendLine("</head>");
                html.AppendLine("<body>");

                html.AppendLine("  <div class='company-header'>");
                html.AppendLine("    <h2>MATIENSOS S.A.</h2>");
                html.AppendLine("    <p>CUIT: 30-12345678-9 | IVA Responsable Inscripto | Casa Central: Calle Falsa 123</p>");
                html.AppendLine("    <p>Tel: 0800-MATES | Email: administracion@matiensos.com</p>");
                html.AppendLine("  </div>");

                html.AppendLine("  <h1>INFORME DE AUDITORÍA Y TRAZABILIDAD</h1>");

                html.AppendLine("  <div class='meta-box'>");
                html.AppendLine($"    <div><strong>Período evaluado:</strong> {periodo}</div>");
                html.AppendLine($"    <div><strong>Emitido por:</strong> {emitidoPor}</div>");
                html.AppendLine($"    <div><strong>Operación filtrada:</strong> {operacion}</div>");
                html.AppendLine($"    <div><strong>Fecha y hora de emisión:</strong> {DateTime.Now:dd/MM/yyyy HH:mm:ss}</div>");
                html.AppendLine($"    <div><strong>Criterio de búsqueda:</strong> {(string.IsNullOrWhiteSpace(criterioBusqueda) ? "Todos los registros" : criterioBusqueda)}</div>");
                html.AppendLine($"    <div><strong>Total de eventos:</strong> {registros.Count}</div>");
                html.AppendLine("  </div>");

                html.AppendLine("  <table>");
                html.AppendLine("    <thead>");
                html.AppendLine("      <tr>");
                html.AppendLine("        <th style='width: 140px;'>Fecha / Hora</th>");
                html.AppendLine("        <th style='width: 120px;'>Usuario</th>");
                html.AppendLine("        <th style='width: 120px;'>Módulo</th>");
                html.AppendLine("        <th style='width: 110px;'>Acción</th>");
                html.AppendLine("        <th>Detalle / Resumen de Operación</th>");
                html.AppendLine("      </tr>");
                html.AppendLine("    </thead>");
                html.AppendLine("    <tbody>");

                foreach (var reg in registros)
                {
                    string badgeClass = "badge-default";
                    string accionUpper = (reg.Accion ?? "").ToUpperInvariant();
                    if (accionUpper.Contains("ALTA")) badgeClass = "badge-alta";
                    else if (accionUpper.Contains("MODIFIC")) badgeClass = "badge-modificacion";
                    else if (accionUpper.Contains("BAJA")) badgeClass = "badge-baja";
                    else if (accionUpper.Contains("REACTIV")) badgeClass = "badge-reactivacion";

                    string detallesHtml = System.Net.WebUtility.HtmlEncode(reg.Detalles ?? "")
                        .Replace(", ", "<br/>")
                        .Replace(" - ", "<br/>");

                    html.AppendLine("      <tr>");
                    html.AppendLine($"        <td>{reg.FechaHora}</td>");
                    html.AppendLine($"        <td><strong>{System.Net.WebUtility.HtmlEncode(reg.Usuario)}</strong></td>");
                    html.AppendLine($"        <td>{System.Net.WebUtility.HtmlEncode(reg.Modulo)}</td>");
                    html.AppendLine($"        <td><span class='badge {badgeClass}'>{System.Net.WebUtility.HtmlEncode(reg.Accion)}</span></td>");
                    html.AppendLine($"        <td class='detalles'>{detallesHtml}</td>");
                    html.AppendLine("      </tr>");
                }

                html.AppendLine("    </tbody>");
                html.AppendLine("  </table>");

                html.AppendLine($"  <div class='footer'>TOTAL DE SUCESOS AUDITADOS: {registros.Count}</div>");

                html.AppendLine("  <script>");
                html.AppendLine("    window.onload = function() {");
                html.AppendLine("      setTimeout(function() { window.print(); }, 500);");
                html.AppendLine("    };");
                html.AppendLine("  </script>");

                html.AppendLine("</body>");
                html.AppendLine("</html>");

                string archivoTemp = Path.Combine(Path.GetTempPath(), $"Reporte_Auditoria_{DateTime.Now:yyyyMMdd_HHmmss}.html");
                File.WriteAllText(archivoTemp, html.ToString(), Encoding.UTF8);

                Process.Start(new ProcessStartInfo
                {
                    FileName = archivoTemp,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte de auditoría: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

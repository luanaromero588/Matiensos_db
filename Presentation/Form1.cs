using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // --- PRUEBA DIRECTA DE CONEXIÓN ---
            try
            {
                RolBusiness rolBusiness = new RolBusiness();
                List<Rol> listaRoles = rolBusiness.ObtenerRoles();

                if (listaRoles.Count > 0)
                {
                    MessageBox.Show($"¡Conexión exitosa! Rol obtenido: {listaRoles[0].Nombre}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Conectó a la base de datos, pero no hay filas en la tabla 'rol'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Instanciamos la capa Business
                RolBusiness rolBusiness = new RolBusiness();

                // 2. Pedimos los roles (esto viaja por Business -> Data -> Docker SQL Server)
                List<Rol> listaRoles = rolBusiness.ObtenerRoles();

                // 3. Mostramos un mensaje de confirmación
                if (listaRoles.Count > 0)
                {
                    MessageBox.Show($"¡Conexión exitosa! Se cargó el rol: {listaRoles[0].Nombre}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La base de datos conectó pero la tabla 'rol' está vacía.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

      
    }
}

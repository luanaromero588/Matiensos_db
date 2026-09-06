using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UsuarioBusiness
    {
        
        private UsuarioData usuarioData = new UsuarioData();

        
        public void GuardarUsuario(string nombre, string apellido, string dni, string email, string telefono, int? rolId, string password, int? personaId, int? usuarioId)
        {
            bool esNuevo = (usuarioId == null);

            
            ValidarDatos(nombre, apellido, dni, email, telefono, rolId, password, esNuevo);

            
            if (esNuevo)
            {
                usuarioData.InsertarUsuarioCompleto(
                    nombre.Trim(),
                    apellido.Trim(),
                    dni.Trim(),
                    email,
                    telefono,
                    rolId.Value,
                    password.Trim()
                );
            }
            else
            {
                usuarioData.ModificarUsuarioCompleto(
                    personaId.Value,
                    usuarioId.Value,
                    nombre.Trim(),
                    apellido.Trim(),
                    dni.Trim(),
                    email,
                    telefono,
                    rolId.Value,
                    password?.Trim()
                );
            }
        }

        //  Método de validaciones
        public void ValidarDatos(string nombre, string apellido, string dni, string email, string telefono, int? rolId, string password, bool esNuevo)
        {
            // Validaciones para campos obligatorios
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(dni))
                throw new ArgumentException("El DNI es obligatorio.");

            // Validación de formato de DNI (solo números, 8 dígitos)
            string dniLimpio = dni.Trim();
            if (dniLimpio.Length != 8 || !int.TryParse(dniLimpio, out int numeroDni) || numeroDni <= 0)
            {
                throw new ArgumentException("El DNI debe contener exactamente 8 números sin puntos ni espacios.");
            }

            // Validación de Rol obligatorio
            if (!rolId.HasValue || rolId.Value <= 0)
                throw new ArgumentException("Debe seleccionar un rol válido.");

            // Validación de Correo
            if (!string.IsNullOrWhiteSpace(email))
            {
                string correo = email.Trim();

                if (!correo.Contains("@") || !correo.Contains("."))
                {
                    throw new ArgumentException("El correo electrónico debe contener '@' y un dominio válido (ej. .com).");
                }

                try
                {
                    var dir = new System.Net.Mail.MailAddress(correo);
                }
                catch
                {
                    throw new ArgumentException("El formato del correo electrónico no es válido.");
                }
            }

            // Validación de Teléfono
            if (!string.IsNullOrWhiteSpace(telefono))
            {
                string tel = telefono.Trim();

                if (tel.Length < 6 || tel.Length > 20)
                {
                    throw new ArgumentException("El teléfono debe tener entre 6 y 20 caracteres.");
                }

                foreach (char c in tel)
                {
                    if (!char.IsDigit(c) && c != '-' && c != ' ')
                    {
                        throw new ArgumentException("El teléfono solo puede contener números, espacios o guiones.");
                    }
                }
            }

            // Reglas de Contraseña
            if (esNuevo)
            {
                if (string.IsNullOrWhiteSpace(password))
                    throw new ArgumentException("La contraseña es obligatoria para usuarios nuevos.");

                if (password.Length < 8)
                    throw new ArgumentException("La contraseña debe tener al menos 8 caracteres.");
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(password) && password.Length < 8)
                    throw new ArgumentException("La nueva contraseña debe tener al menos 8 caracteres.");
            }
        }

        public DataTable BuscarUsuariosPorDni(string dni)
        {
            string filtro = string.IsNullOrWhiteSpace(dni) ? null : dni.Trim();
            return usuarioData.ObtenerUsuarios(filtro);
        }

        public void EliminarUsuario(int usuarioId, string rol)
        {
            if (rol == "Superadmin" || rol == "SuperAdmin")
            {
                throw new InvalidOperationException("No se puede eliminar al usuario Superadmin.");
            }

            usuarioData.EliminarUsuario(usuarioId);
        }
    }

}
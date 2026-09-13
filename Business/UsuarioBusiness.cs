using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UsuarioBusiness
    {
        // Instancia interna: UsuarioBusiness coordina con PersonaBusiness
        private readonly PersonaBusiness personaBusiness = new PersonaBusiness();
        private UsuarioData usuarioData = new UsuarioData();

        // Validaciones en tiempo real de campos del form
        public bool ExisteDni(string dni, int? personaIdExcluir, out string mensajeError)
        {
            return personaBusiness.ExisteDni(dni, personaIdExcluir, out mensajeError);
        }

        public bool ValidarNombre(string nombre, out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                mensaje = "El nombre es obligatorio.";
                return false;
            }
            if (nombre.Trim().Length < 2)
            {
                mensaje = "El nombre debe tener al menos 2 letras.";
                return false;
            }
            return true;
        }

        public bool ValidarApellido(string apellido, out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrWhiteSpace(apellido))
            {
                mensaje = "El apellido es obligatorio.";
                return false;
            }
            if (apellido.Trim().Length < 2)
            {
                mensaje = "El apellido debe tener al menos 2 letras.";
                return false;
            }
            return true;
        }

        public bool ValidarCorreo(string email, out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrWhiteSpace(email))
            {
                mensaje = "El correo es obligatorio.";
                return false;
            }

            string correo = email.Trim();
            if (!correo.Contains("@") || !correo.Contains("."))
            {
                mensaje = "Debe contener '@' y un dominio válido (ej. .com).";
                return false;
            }

            try
            {
                var dir = new System.Net.Mail.MailAddress(correo);
            }
            catch
            {
                mensaje = "El formato del correo electrónico no es válido.";
                return false;
            }

            return true;

        }

        public bool ValidarTelefono(string telefono, out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrWhiteSpace(telefono))
            {
                mensaje = "El teléfono es obligatorio.";
                return false;
            }

            string tel = telefono.Trim();
            if (tel.Length < 6 || tel.Length > 20)
            {
                mensaje = "Debe tener entre 6 y 20 caracteres.";
                return false;
            }

            foreach (char c in tel)
            {
                if (!char.IsDigit(c) && c != '-' && c != ' ')
                {
                    mensaje = "Solo puede contener números, espacios o guiones.";
                    return false;
                }
            }

            return true;
        }

        public bool ValidarContraseña(string password, bool esEdicion, out string mensaje)
        {
            mensaje = string.Empty;

            if (!esEdicion)
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    mensaje = "La contraseña es obligatoria para nuevos usuarios.";
                    return false;
                }
                if (password.Length < 8)
                {
                    mensaje = "La contraseña debe tener al menos 8 caracteres.";
                    return false;
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(password) && password.Length < 8)
                {
                    mensaje = "La nueva contraseña debe tener al menos 8 caracteres.";
                    return false;
                }
            }

            return true;
        }

        public bool ValidarRol(int? rolId, out string mensaje)
        {
            mensaje = string.Empty;
            if (!rolId.HasValue || rolId.Value <= 0)
            {
                mensaje = "Debe seleccionar un rol válido.";
                return false;
            }
            return true;
        }

        //validaciones generales antes de guardar o modificar un usuario
        public void ValidarDatos(string nombre, string apellido, string dni, string email, string telefono, int? rolId, string password, bool esNuevo)
        {
            if (!ValidarNombre(nombre, out string errNom))
                throw new ArgumentException(errNom);

            if (!ValidarApellido(apellido, out string errApe))
                throw new ArgumentException(errApe);

            if (string.IsNullOrWhiteSpace(dni))
                throw new ArgumentException("El DNI es obligatorio.");

            string dniLimpio = dni.Trim();
            if (dniLimpio.Length < 7 || dniLimpio.Length > 8 || !int.TryParse(dniLimpio, out int numeroDni) || numeroDni <= 0)
                throw new ArgumentException("El DNI debe contener 7 u 8 números sin puntos ni espacios.");

            if (!ValidarCorreo(email, out string errCor))
                throw new ArgumentException(errCor);

            if (!ValidarTelefono(telefono, out string errTel))
                throw new ArgumentException(errTel);

            if (!ValidarRol(rolId, out string errRol))
                throw new ArgumentException(errRol);

            if (!ValidarContraseña(password, !esNuevo, out string errPass))
                throw new ArgumentException(errPass);
        }

        public void GuardarUsuario(string nombre, string apellido, string dni, string email, string telefono, int? rolId, string password, int? personaId, int? usuarioId, int idUsuarioActual)
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
                    password.Trim(),
                    idUsuarioActual
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
                    password?.Trim(),
                    idUsuarioActual
                );
            }
        }

        public DataTable BuscarUsuariosPorDni(string dni)
        {
            string filtro = string.IsNullOrWhiteSpace(dni) ? null : dni.Trim();
            return usuarioData.ObtenerUsuarios(filtro);
        }

        public void SuspenderUsuario(int usuarioId, string rol, int idUsuarioActual)
        {
            if (rol != null && rol.Equals("SuperAdmin", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("No se puede suspender al SuperAdmin.");

            usuarioData.SuspenderUsuario(usuarioId, false, idUsuarioActual);
        }

        public void ReactivarUsuario(int usuarioId, int idUsuarioActual)
        {
            usuarioData.SuspenderUsuario(usuarioId, true, idUsuarioActual);
        }
    }
}

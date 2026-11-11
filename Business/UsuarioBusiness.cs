using Entities;
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
        private readonly PersonaBusiness personaBusiness = new PersonaBusiness();
        private UsuarioData usuarioData = new UsuarioData();

        /// <summary>
        /// Validaciones en tiempo real de campos del form.
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="personaIdExcluir"></param>
        /// <param name="mensajeError"></param>
        /// <returns></returns>
        public bool ExisteDni(string dni, int? personaIdExcluir, out string mensajeError)
        {
            return personaBusiness.ExisteDni(dni, personaIdExcluir, out mensajeError);
        }

        /// <summary>
        /// Valida que la entrada del nombre sea correcta.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Valida que la entrada del apellido sea correcta.
        /// </summary>
        /// <param name="apellido"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Valida que el correo ingresado tenga el formato correcto.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Valida que el numero de telefono ingresado sea correcto.
        /// </summary>
        /// <param name="telefono"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Valida que la contraseña cumpla con las reglas establecidas.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="esEdicion"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Valida que se haya seleccionado un rol.
        /// </summary>
        /// <param name="rolId"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Validaciones generales antes de guardar o modificar un usuario.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="email"></param>
        /// <param name="telefono"></param>
        /// <param name="rolId"></param>
        /// <param name="password"></param>
        /// <param name="esNuevo"></param>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Registra un nuevo usuario (vendedor/admin).
        /// Audita la accion si es correcta.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="email"></param>
        /// <param name="telefono"></param>
        /// <param name="rolId"></param>
        /// <param name="password"></param>
        /// <param name="personaId"></param>
        /// <param name="usuarioId"></param>
        /// <param name="idUsuarioActual"></param>
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

                string rolNombre = usuarioData.ObtenerNombreRolPorId(rolId.Value);

                AuditoriaBusiness.RegistrarEvento(
                    "Usuario",
                    "Alta",
                    $"DNI: [{dni.Trim()}], NOMBRE: '{nombre.Trim()} {apellido.Trim()}', ROL: '{rolNombre}', EMAIL: '{email}', TEL: '{telefono}'"
                );
            }
            else
            {
                DataTable dtViejo = usuarioData.ObtenerUsuarioPorId(usuarioId.Value);

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

                if (dtViejo != null && dtViejo.Rows.Count > 0)
                {
                    DataRow viejo = dtViejo.Rows[0];
                    List<string> cambios = new List<string>();

                    string nombreViejo = $"{viejo["first_name"]} {viejo["last_name"]}".Trim();
                    string nombreNuevo = $"{nombre.Trim()} {apellido.Trim()}".Trim();
                    if (!nombreViejo.Equals(nombreNuevo, StringComparison.OrdinalIgnoreCase))
                        cambios.Add($"NOMBRE: '{nombreViejo}' → '{nombreNuevo}'");

                    string dniViejo = viejo["dni"]?.ToString();
                    if (dniViejo != dni.Trim())
                        cambios.Add($"DNI: '{dniViejo}' → '{dni.Trim()}'");

                    string emailViejo = viejo["email"]?.ToString();
                    if (emailViejo != email)
                        cambios.Add($"EMAIL: '{emailViejo}' → '{email}'");

                    string telViejo = viejo["phone"]?.ToString();
                    if (telViejo != telefono)
                        cambios.Add($"TEL: '{telViejo}' → '{telefono}'");

                    int rolViejoId = Convert.ToInt32(viejo["role_id"]);
                    if (rolViejoId != rolId.Value)
                    {
                        string rolViejoNombre = viejo["role_name"]?.ToString();
                        string rolNuevoNombre = usuarioData.ObtenerNombreRolPorId(rolId.Value);
                        cambios.Add($"ROL: '{rolViejoNombre}' → '{rolNuevoNombre}'");
                    }

                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        cambios.Add("CONTRASEÑA: [Actualizada]");
                    }

                    if (cambios.Count > 0)
                    {
                        string detalleCambios = string.Join(", ", cambios);
                        AuditoriaBusiness.RegistrarEvento(
                            "Usuario",
                            "Modificación",
                            $"DNI: [{dni.Trim()}], {detalleCambios}"
                        );
                    }
                }
            }
        }

        /// <summary>
        /// Busca usuario por dni.
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public DataTable BuscarUsuariosPorDni(string dni)
        {
            string filtro = string.IsNullOrWhiteSpace(dni) ? null : dni.Trim();
            return usuarioData.ObtenerUsuarios(filtro);
        }

        /// <summary>
        /// Baja logica de un usuario. Cambia su estado a inactivo.
        /// Audita la accion si es correcta.
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="rol"></param>
        /// <param name="idUsuarioActual"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void SuspenderUsuario(int usuarioId, string rol, int idUsuarioActual)
        {
            if (rol != null && rol.Equals("SuperAdmin", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("No se puede suspender al SuperAdmin.");

            DataTable dtViejo = usuarioData.ObtenerUsuarioPorId(usuarioId);
            string nombreCompleto = "";
            string dni = "";
            string nombreRol = rol ?? "Usuario";
            if (dtViejo != null && dtViejo.Rows.Count > 0)
            {
                DataRow r = dtViejo.Rows[0];
                nombreCompleto = $"{r["first_name"]} {r["last_name"]}".Trim();
                dni = r["dni"]?.ToString();
                if (r["role_name"] != DBNull.Value && !string.IsNullOrWhiteSpace(r["role_name"].ToString()))
                {
                    nombreRol = r["role_name"].ToString();
                }
            }

            usuarioData.SuspenderUsuario(usuarioId, false, idUsuarioActual);

            AuditoriaBusiness.RegistrarEvento(
                "Usuario",
                "Baja Lógica",
                $"DNI: [{dni}], NOMBRE: '{nombreCompleto}', ROL: '{nombreRol}'"
            );
        }

        /// <summary>
        /// Reactiva un usuario. Cambia su estado a activo.
        /// Audita la accion si es correcta.
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="idUsuarioActual"></param>
        public void ReactivarUsuario(int usuarioId, int idUsuarioActual)
        {
            DataTable dtViejo = usuarioData.ObtenerUsuarioPorId(usuarioId);
            string nombreCompleto = "";
            string dni = "";
            string nombreRol = "Usuario";
            if (dtViejo != null && dtViejo.Rows.Count > 0)
            {
                DataRow r = dtViejo.Rows[0];
                nombreCompleto = $"{r["first_name"]} {r["last_name"]}".Trim();
                dni = r["dni"]?.ToString();
                if (r["role_name"] != DBNull.Value && !string.IsNullOrWhiteSpace(r["role_name"].ToString()))
                {
                    nombreRol = r["role_name"].ToString();
                }
            }

            usuarioData.SuspenderUsuario(usuarioId, true, idUsuarioActual);

            AuditoriaBusiness.RegistrarEvento(
                "Usuario",
                "Reactivación",
                $"DNI: [{dni}], NOMBRE: '{nombreCompleto}', ROL: '{nombreRol}'"
            );
        }

        //cards
        public (int TotalActivos, int AdminsActivos, int VendedoresActivos) ObtenerResumenCards()
        {
            return usuarioData.ObtenerResumenCards();
        }

        /// <summary>
        /// Verifica si los datos ingresados en el formulario de inicio de sesion es correcto.
        /// Da o niega el acceso al sistema.
        /// Audita la accion si es correcta.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public DataTable IniciarSesion(string email, string password, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                mensaje = "Por favor, complete todos los campos.";
                return null;
            }

            UsuarioData data = new UsuarioData();
            DataTable dt = data.ObtenerPorEmail(email.Trim());

            if (dt == null || dt.Rows.Count == 0)
            {
                mensaje = "Usuario o contraseña incorrectos.";
                return null;
            }

            DataRow fila = dt.Rows[0];

            if (fila["password"].ToString() != password.Trim())
            {
                mensaje = "Usuario o contraseña incorrectos.";
                return null;
            }

            bool activo = Convert.ToBoolean(fila["is_active"]);
            if (!activo)
            {
                mensaje = "El usuario se encuentra suspendido.";
                return null;
            }

            string nombreCompleto = $"{fila["first_name"]} {fila["last_name"]}".Trim();
            string rol = fila["rol"]?.ToString();

            Sesion.UsuarioId = Convert.ToInt32(fila["user_id"]);
            Sesion.Nombre = nombreCompleto;
            Sesion.Rol = rol;

            AuditoriaBusiness.RegistrarEvento(
                "Seguridad",
                "Login",
                $"INICIO DE SESIÓN: '{nombreCompleto}', ROL: '{rol}', EMAIL: '{email.Trim()}'"
            );

            return dt;
        }

        /// <summary>
        /// Cierra la sesion del usuario.
        /// Audita la acción.
        /// </summary>
        public void CerrarSesion()
        {
            string nombreUsuario = Sesion.Nombre ?? "Usuario Desconocido";

            AuditoriaBusiness.RegistrarEvento(
                "Seguridad",
                "Logout",
                $"CIERRE DE SESIÓN: '{nombreUsuario}'"
            );

            Sesion.UsuarioId = 0;
            Sesion.Nombre = null;
            Sesion.Rol = null;
        }

        public bool ValidarClavePorId(int userId, string password)
        {
            if (userId <= 0 || string.IsNullOrWhiteSpace(password))
                return false;

            UsuarioData data = new UsuarioData();
            return data.ValidarClavePorId(userId, password.Trim());
        }

        /// <summary>
        /// Valida que la clave ingresada pertenezca al super administrador.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidarClaveSuperAdmin(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            UsuarioData data = new UsuarioData();
            return data.ValidarClaveSuperAdmin(password.Trim());
        }

        /// <summary>
        /// Valida que la clave pertenezca a algun administrador.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidarClaveCualquierAdmin(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            return usuarioData.ValidarClaveCualquierAdmin(password);
        }
    }

}

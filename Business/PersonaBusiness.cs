using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class PersonaBusiness
    {
        private readonly PersonaRepository personaRepo = new PersonaRepository();

        public bool ExisteDni(string dni, int? personaIdExcluir, out string mensajeError)
        {
            mensajeError = string.Empty;

            // Validación de negocio básica antes de tocar la base de datos
            if (string.IsNullOrWhiteSpace(dni))
            {
                mensajeError = "El campo DNI no puede estar vacío.";
                return false;
            }

            if (dni.Length < 7 || dni.Length > 8)
            {
                mensajeError = "El DNI debe tener entre 7 y 8 dígitos numéricos.";
                return false;
            }


            // Consulta a la capa de datos
            bool yaExiste = personaRepo.ExisteDni(dni);

            if (yaExiste)
            {
                mensajeError = "Este DNI ya está registrado en el sistema.";
                return true;
            }

            return false; // DNI disponible
        }
    }
}

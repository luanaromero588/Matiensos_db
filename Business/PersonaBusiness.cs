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

        /// <summary>
        /// Verifica si el dni existe.
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="personaIdExcluir"></param>
        /// <param name="mensajeError"></param>
        /// <returns></returns>
        public bool ExisteDni(string dni, int? personaIdExcluir, out string mensajeError)
        {
            mensajeError = string.Empty;

            //Verif. entrada de datos
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
            bool yaExiste = personaRepo.ExisteDni(dni, personaIdExcluir);

            if (yaExiste)
            {
                mensajeError = "Este DNI ya está registrado en el sistema.";
                return true;
            }

            return false;
        }
    }
}

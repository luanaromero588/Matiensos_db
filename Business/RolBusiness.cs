using System.Collections.Generic;
using Data;
using Entities;

namespace Business
{
    public class RolBusiness
    {
        private readonly RolData _rolData = new RolData();

        /// <summary>
        /// Lista los roles que se pueden asignar.
        /// </summary>
        /// <returns></returns>
        public List<Rol> ObtenerRoles()
        {
            return _rolData.ListarRoles();
        }
    }
}
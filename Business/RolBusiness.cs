using System.Collections.Generic;
using Data;
using Entities;

namespace Business
{
    public class RolBusiness
    {
        private readonly RolData _rolData = new RolData();

        // Método que solicita la lista de roles a la capa Data
        public List<Rol> ObtenerRoles()
        {
            // Aquí se pueden agregar validaciones o reglas de negocio futuras
            return _rolData.ListarRoles();
        }
    }
}
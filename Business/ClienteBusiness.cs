using Data;
using Entities;

namespace Business
{
    public class ClienteBusiness
    {
        private readonly ClienteData clienteData = new ClienteData();

        public Cliente BuscarPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return null;
            return clienteData.ObtenerPorDni(dni);
        }
    }
}
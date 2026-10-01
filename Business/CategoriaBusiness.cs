using Data;
using Entities;
using System.Collections.Generic;

namespace Business
{
    public class CategoriaBusiness
    {
        private readonly CategoriaData categoriaData = new CategoriaData();

        public List<Categoria> ObtenerCategoriasActivas()
        {
            return categoriaData.ListarActivas();
        }
    }
}
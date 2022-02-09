using Lanches.MVC.Context;
using Lanches.MVC.Models;
using Lanches.MVC.Repositories.Interfaces;

namespace Lanches.MVC.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}

using VhBurguer.Contexts;
using VhBurguer.Domains;

namespace VhBurguer.Repositories
{
    public class CategoriaRepository
    {
        private readonly VhBurguerDbContext _context;

        public CategoriaRepository(VhBurguerDbContext context)
        {
            _context = context;
        }

        public List<Categoria> Listar()
        {
            return _context.Categoria.ToList();
        }

        public Categoria ObterPorId(int id)
        {
            Categoria categoria = _context.Categoria.FirstOrDefault(c => c.CategoriaId == id);
            return categoria;
        }

        public bool NomeExiste(string nome, int? categoriaIdAtual = null)
        {
            var consulta = _context.Categoria.AsQueryable();
            if (categoriaIdAtual.HasValue)
            {
                consulta = consulta.Where(c => c.CategoriaId != categoriaIdAtual.Value);
            }
            return consulta.Any(c => c.Nome == nome);
        }

        public void adicionar(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            _context.SaveChanges();
        }

        public void Atualizar(Categoria categoria)
        {
            Categoria categoriaBanco = _context.Categoria.FirstOrDefault(c => c.CategoriaId == categoria.CategoriaId);

            if (categoriaBanco == null)
            {
                return;
            }

            categoriaBanco.Nome = categoria.Nome;
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            Categoria categoriaBanco = _context.Categoria.FirstOrDefault(c => c.CategoriaId == id);
            if (categoriaBanco == null)
            {
                return;
            }
            _context.Categoria.Remove(categoriaBanco);
            _context.SaveChanges();
        }
    }
}

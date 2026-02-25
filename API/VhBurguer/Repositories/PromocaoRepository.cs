using VhBurguer.Domains;
using VhBurguer.Interfaces;
using VhBurguer.Contexts;

namespace VhBurguer.Repositories
{
    public class PromocaoRepository : IPromocaoRepository
    {

        private readonly VhBurguerDbContext _context;

        public PromocaoRepository(VhBurguerDbContext context)
        {
            _context = context;
        }

        public List<Promocao> Listar()
        {
            return _context.Promocao.ToList();
        }

        public Promocao ObterPorId(int id)
        {
            Promocao? promocao = _context.Promocao.FirstOrDefault(promocaoQuery => promocaoQuery.PromocaoId == id);

            return promocao;
        }

        public bool NomeExiste(string nome, int? promocaoIdAtual = null)
        {
            var consulta = _context.Promocao.AsQueryable();

            if (promocaoIdAtual.HasValue)
            {
                consulta = consulta.Where(promocaoQuery => promocaoQuery.PromocaoId != promocaoIdAtual.Value);
            }

            return consulta.Any(p => p.Nome == nome);

        }

        public void Adicionar(Promocao promocao)
        {
            _context.Promocao.Add(promocao);
            _context.SaveChanges();

        }

        public void Atualizar(Promocao promocao)
        {
            Promocao? promocaoBanco = _context.Promocao.FirstOrDefault(p => p.PromocaoId == p.PromocaoId);
            if (promocao == null)
            {
                return;
            }

            promocaoBanco.Nome = promocao.Nome;
            promocaoBanco.DataExpiracao = promocao.DataExpiracao;
            promocaoBanco.StatusPromocao = promocao.StatusPromocao;
        }

        public void Remover(int id)
        {
            Promocao? promocao = _context.Promocao.FirstOrDefault(p => p.PromocaoId == id);

            if (promocao == null)
                return;

            _context.Promocao.Remove(promocao);
            _context.SaveChanges();
        }



    }
}
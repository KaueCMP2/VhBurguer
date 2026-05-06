using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using VhBurguer.Contexts;
using VhBurguer.Domains;
using VhBurguer.Interfaces;

namespace VhBurguer.Repositories
{
    public class LogAlteracaoProdutoRepository : ILogAlteracaoProdutoRepository
    {
        private readonly VhBurguerDbContext _context;

        public LogAlteracaoProdutoRepository(VhBurguerDbContext context)
        {
            _context = context;
        }

        public List<Log_AlteracaoProduto> Listar()
        {
            List<Log_AlteracaoProduto> log = _context.Log_AlteracaoProduto.OrderByDescending(l => l.DataAlteracao).ToList();

            return log;
        }

        public List<Log_AlteracaoProduto> ListarPorIdProduto(int id)
        {
            List<Log_AlteracaoProduto> alteracaoProduto = _context.Log_AlteracaoProduto.Where(log => log.ProdutoId == id)
                .OrderByDescending(log => log.DataAlteracao).ToList();

            return alteracaoProduto;
        }
    }
}

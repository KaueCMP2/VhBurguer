using VhBurguer.Domains;

namespace VhBurguer.Interfaces
{
    public interface ILogAlteracaoProdutoRepository
    {
        List<Log_AlteracaoProduto> Listar();
        List<Log_AlteracaoProduto> ListarPorProduto(int produotId);
    }
}

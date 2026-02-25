using VhBurguer.Domains;
using VhBurguer.DTOs.LogAlteracaoProdutoDTO;
using VhBurguer.DTOs.ProdutoDto;
using VhBurguer.Interfaces;

namespace VhBurguer.Aplications.Services
{
    public class LogAlteracaoProdutoService
    {
        private readonly ILogAlteracaoProdutoRepository _repository;

        public LogAlteracaoProdutoService(ILogAlteracaoProdutoRepository repository)
        {
            _repository = repository;
        }

        public List<LerLogProdutoDTO> Listar()
        {
            List<Log_AlteracaoProduto> logs = _repository.Listar();

            List<LerLogProdutoDTO> listaLogProduto = logs.Select(log => new LerLogProdutoDTO
            {
                LogId = log.Log_AltercaoProdutoId,
                ProdutoId = log.ProdutoId,
                NomeAnterior = log.NomeAnterior,
                PrecoAnterior = log.PrecoAnterior,
                DataAlteracao = log.DataAlteracao
            }).ToList();

            return listaLogProduto;
        }

        public List<LerLogProdutoDTO> ListarPorProduto(int ProdutoId)
        {
            List<Log_AlteracaoProduto> logs = _repository.ListarPorProduto(ProdutoId);
            
            List<LerLogProdutoDTO> listaLogProduto = logs.Select(log => new LerLogProdutoDTO
            {
                LogId = log.Log_AltercaoProdutoId,
                ProdutoId = log.ProdutoId,
                NomeAnterior = log.NomeAnterior,
                PrecoAnterior = log.PrecoAnterior,
                DataAlteracao = log.DataAlteracao
            }).ToList();

            return listaLogProduto;
        }
    }
}

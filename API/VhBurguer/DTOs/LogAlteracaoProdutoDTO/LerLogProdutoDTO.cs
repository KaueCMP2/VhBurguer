namespace VhBurguer.DTOs.LogAlteracaoProdutoDTO
{
    public class LerLogProdutoDTO
    {
        public int LogId { get; set; }
        public int ProdutoId { get; set; }
        public string? NomeAnterior { get; set; } = null!;
        public decimal PrecoAnterior { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}

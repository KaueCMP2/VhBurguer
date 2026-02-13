namespace VhBurguer.DTOs.ProdutosDTO
{
    public class CriarProdutoDTO
    {
        public string Nome { get; set; } = null!;
        public decimal Preco { get; set; }
        public string Desceicao { get; set; } = null!;
        public IFormFile Imagem { get; set; } = null!;
        public List<int> CategoriasIds { get; set; } = new();
    }
}

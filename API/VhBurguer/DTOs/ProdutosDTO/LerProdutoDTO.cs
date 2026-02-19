namespace VhBurguer.DTOs.ProdutosDTO
{
    public class LerProdutoDTO
    {
        public int ProdutoId { get; set; }

        public string Nome { get; set; } = null!;

        public decimal? Preco { get; set; }

        public string Descricao { get; set; } = null!;

        public bool? StatusProduto { get; set; }

        public int UsuarioId { get; set; }

        // categorias 
        public List<int> CategoriaIds { get; set; }
        public List<string> Categorias { get; set; }

        //Usuario que cadastrou o produto
        public int? UsuarioID { get; set; }
        public string? UsuarioNome { get; set; }
        public string? UsuarioEmail { get; set; }
    }
}

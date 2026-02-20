using VhBurguer.Domains;
using VhBurguer.DTOs.ProdutosDTO;
using VHBurguer.DTOs.ProdutoDto;

namespace VhBurguer.Aplications.Conversoes
{
    public class ProdutoParaDTO
    {
        public static LerProdutoDTO ConverterParaDTO(Produto produto)
        {
            return new LerProdutoDTO()
            {
                ProdutoID = produto.ProdutoId,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Descricao = produto.Descricao,
                StatusProduto = produto.StatusProduto,

                CategoriaIds = produto.Categoria.Select(categoria => categoria.CategoriaId).ToList(),
                Categorias = produto.Categoria.Select(categoria => categoria.Nome).ToList(),

                UsuarioID = produto.UsuarioId,
                UsuarioNome = produto.Usuario.Nome,
                UsuarioEmail = produto.Usuario.Email
            };
        }
    }
}
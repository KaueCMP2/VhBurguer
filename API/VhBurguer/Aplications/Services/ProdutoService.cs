using Microsoft.IdentityModel.Abstractions;
using VhBurguer.Aplications.Conversoes;
using VhBurguer.Aplications.Regras;
using VhBurguer.Domains;
using VhBurguer.DTOs.ProdutosDTO;
using VhBurguer.Exceptions;
using VHBurguer.DTOs.ProdutoDto;
using VHBurguer.Interfaces;

namespace VHBurguer.Applications.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        // Para cada produto que veio do banco
        // Crie um DTO só com o que a requisição/front precisa.
        public List<LerProdutoDTO> Listar()
        {
            List<Produto> produtos = _repository.Listar();

            // SELECT percorre cada Produto e transforma em DTO -> LerProdutoDto
            List<LerProdutoDTO> produtosDto =
                produtos.Select(ProdutoParaDTO.ConverterParaDTO).ToList();

            return produtosDto;
        }

        public LerProdutoDTO ObterPorId(int id)
        {
            Produto produto = _repository.ObterPorId(id);

            if (produto == null)
            {
                throw new DomainException("Produto não encontrado");
            }

            // converte o produto encontrado para DTO e devolve
            return ProdutoParaDTO.ConverterParaDTO(produto);
        }

        private static void ValidarCadastro(CriarProdutoDTO produtoDto)
        {
            if (string.IsNullOrWhiteSpace(produtoDto.Nome))
            {
                throw new DomainException("Nome é obrigatório.");
            }

            if (produtoDto.Preco < 0)
            {
                throw new DomainException("Preço deve ser maior que zero.");
            }

            if (string.IsNullOrWhiteSpace(produtoDto.Descricao))
            {
                throw new DomainException("Descrição é obrigatória.");
            }

            if (produtoDto.Imagem == null || produtoDto.Imagem.Length == 0)
            {
                throw new DomainException("Imagem é obrigatória.");
            }

            if (produtoDto.CategoriaIds == null || produtoDto.CategoriaIds.Count == 0)
            {
                throw new DomainException("Produto deve ter ao menos uma categoria.");
            }
        }

        public byte[] ObterImagem(int id)
        {
            byte[] imagem = _repository.ObterImagem(id);

            if (imagem == null || imagem.Length == 0)
            {
                throw new DomainException("Imagem não encontrada");
            }

            return imagem;
        }

        public LerProdutoDTO Adicionar(CriarProdutoDTO produtoDto, int usuarioId)
        {
            ValidarCadastro(produtoDto);

            if (_repository.NomeExiste(produtoDto.Nome))
            {
                throw new DomainException("Produto já existente");
            }

            Produto produto = new Produto
            {
                Nome = produtoDto.Nome,
                Preco = produtoDto.Preco,
                Descricao = produtoDto.Descricao,
                Imagem = ImagemParaBytes.ConverterImagem(produtoDto.Imagem),
                StatusProduto = true,
                UsuarioId = usuarioId
            };

            _repository.Adicionar(produto, produtoDto.CategoriaIds);

            return ProdutoParaDTO.ConverterParaDTO(produto);
        }

        public LerProdutoDTO Atualizar(int id, AtuallizarProdutoDTO produtoDto)
        {
            HorarioAlteracaoProduto.ValidarHorario();

            Produto produtoBanco = _repository.ObterPorId(id);

            if (produtoBanco == null)
            {
                throw new DomainException("Produto não encontrado.");
            }

            // produtoIdAtual: -> dois pontos serve para passar o valor do parametro
            if (_repository.NomeExiste(produtoDto.Nome, produtoIdAtual: id))
            {
                throw new DomainException("Já existe outro produto com esse nome.");
            }

            if (produtoDto.CategoriaIds == null || produtoDto.CategoriaIds.Count == 0)
            {
                throw new DomainException("Produto deve ter ao menos uma categoria.");
            }

            if (produtoDto.Preco < 0)
            {
                throw new DomainException("Preço deve ser maior que zero.");
            }

            produtoBanco.Nome = produtoDto.Nome;
            produtoBanco.Preco = produtoDto.Preco;
            produtoBanco.Descricao = produtoDto.Descricao;

            if (produtoDto.Imagem != null && produtoDto.Imagem.Length > 0)
            {
                produtoBanco.Imagem = ImagemParaBytes.ConverterImagem(produtoDto.Imagem);
            }

            if (produtoDto.StatusProduto.HasValue)
            {
                produtoBanco.StatusProduto = produtoDto.StatusProduto.Value;
            }

            _repository.Atualizar(produtoBanco, produtoDto.CategoriaIds);

            return ProdutoParaDTO.ConverterParaDTO(produtoBanco);

        }

        public void Deletar(int id)
        {
            HorarioAlteracaoProduto.ValidarHorario();

            Produto produto = _repository.ObterPorId(id);

            if (produto == null)
            {
                throw new DomainException("Produto não encontrado.");
            }

            _repository.Deletar(id);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using VhBurguer.Contexts;
using VhBurguer.Domains;
using VhBurguer.Interfaces;

namespace VhBurguer.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly VhBurguerDbContext _ctx;

        public ProdutoRepository(VhBurguerDbContext context)
        {
            _ctx = context;
        }

        public List<Produto> Listar()
        {
            List<Produto> produtos = _ctx.Produto
                .Include(p => p.Categoria)
                .Include(p => p.UsuarioId)
                .ToList();

            return produtos;
        }

        public Produto ObterPorId(int Id)
        {
            Produto? produto = _ctx.Produto
                .Include(p => p.Categoria)
                .Include(p => p.UsuarioId)
                .FirstOrDefault(p => p.ProdutoId == Id);

            return produto;
        }

        public bool NomeExiste(string nome, int? ProdutoIdAtual = null)
        {
            var produtoConsultado = _ctx.Produto.AsQueryable();

            if (ProdutoIdAtual.HasValue)
            {
                produtoConsultado = produtoConsultado.Where(p => p.ProdutoId != ProdutoIdAtual.Value);
            }

            return produtoConsultado.Any();
        }

        public byte[] ObterImagem(int Id)
        {
            var produto = _ctx.Produto
                .Where(p => p.ProdutoId == Id)
                .Select(p => p.Imagem)
                .FirstOrDefault();

            return produto;
        }

        public void Adicionar(Produto produto, List<int> CategoriasIds)
        {
            List<Categoria> categorias = _ctx.Categoria
                .Where(c => CategoriasIds.Contains(c.CategoriaId))
                .ToList();

            produto.Categoria = categorias;
            _ctx.Produto.Add(produto);
            _ctx.SaveChanges();
        }

        public bool NomeExiste(string nome, int ProdutoIdAtual)
        {
            return _ctx.Produto.Any(p => p.Nome == nome && p.ProdutoId != ProdutoIdAtual);
        }

        public void Atualizar(Produto produto, List<int> CategoriasIds)
        {
            Produto? produtoBanco = _ctx.Produto
                .Include(p => p.Categoria)
                .FirstOrDefault(p => p.ProdutoId == produto.ProdutoId);
            if (produtoBanco == null)
            {
                return;
            }

            produtoBanco.Nome = produto.Nome;
            produtoBanco.Descricao = produto.Descricao;
            produtoBanco.Preco = produto.Preco;

            if (produtoBanco.Imagem != null || produto.Imagem.Length > 0)
            {
                produtoBanco.Imagem = produto.Imagem;
            }
            if (produto.StatusProduto.HasValue)
            {
                produtoBanco.StatusProduto = produto.StatusProduto;
            }

            List<Categoria> categorias = _ctx.Categoria
                .Where(c => CategoriasIds.Contains(c.CategoriaId))
                .ToList();
            produtoBanco.Categoria.Clear();

            foreach (var c in categorias)
            {
                produtoBanco.Categoria.Add(c);
            }
            _ctx.Produto.Update(produtoBanco);
            _ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            Produto? produto = _ctx.Produto.FirstOrDefault(p => p.ProdutoId == Id);
            if (produto == null)
            {
                return;
            }
            _ctx.Produto.Remove(produto);
            _ctx.SaveChanges();
        }
    }
}

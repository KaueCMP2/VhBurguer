using VhBurguer.Domains;
using VhBurguer.DTOs.CategoriaDTO;

namespace VhBurguer.Interfaces
{
    public interface ICategoriaRepositorycs
    {
        List<Categoria> Listar();
        Categoria ObterPorId(int id);

        bool NomeExiste(string nome, int? categoriaIdAtual = null);
        void Adicionar(Categoria categoria);
        void Atualizar(Categoria categoria);
        void Remover(int id);
    }
}

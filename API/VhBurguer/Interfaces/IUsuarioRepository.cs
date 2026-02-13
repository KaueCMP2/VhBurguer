using VhBurguer.Domains;

namespace VhBurguer.Controller
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario? ObterPorId(int Id);

        Usuario? ObterPorEmail(string email);

        bool EmailExiste (string email);

        void Adicionar (Usuario usuario);

        void Atualizar (Usuario usuario);

        void Deletar (int Id);
    }
}

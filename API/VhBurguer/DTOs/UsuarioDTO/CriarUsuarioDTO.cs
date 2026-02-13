using VhBurguer.Domains;

namespace VhBurguer.DTOs.UsuarioDTO
{
    public class CriarUsuarioDTO
    {
        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Senha { get; set; } = null!;
    }
}

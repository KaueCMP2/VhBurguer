using VhBurguer.Domains;

namespace VhBurguer.DTOs
{
    public class CriarUsuarioDTO
    {
        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public byte[] Senha { get; set; } = null!;
    }
}

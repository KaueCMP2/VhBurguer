using System.Security.Cryptography;
using System.Text;
using VhBurguer.Controller;
using VhBurguer.Domains;
using VhBurguer.DTOs;
using VhBurguer.Exceptions;

namespace VhBurguer.Aplications.Services
{
    public class UsuarioServices
    {
        // Repository é o canal para acessarmos os dados.
        private readonly IUsuarioRepository _repository;


        // Injeção de dependência do repository para o serviço.
        // O serviço depende do repository para realizar as operações de negócio.
        public UsuarioServices(IUsuarioRepository _UsuarioRepository)
        {
            _repository = _UsuarioRepository;
        }

        private static LerUsuarioDTO LerDTO(Usuario usuario)
        {
            LerUsuarioDTO lerUsuario = new LerUsuarioDTO
            {
                UsuarioId = usuario.UsuarioId,
                Nome = usuario.Nome,
                Email = usuario.Email,
                StatusUsuario = usuario.StatusUsuario
            };
            return lerUsuario;
        }
        public List<LerUsuarioDTO> Listar()
        {
            List<Usuario> usuarios = _repository.Listar();

            List<LerUsuarioDTO> usuarioDTOs = usuarios
                .Select(UsuarioBanco => LerDTO(UsuarioBanco)).ToList();
            return usuarioDTOs;
        }

        private static void ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                throw new DomainException("Email invalido!");
            }
        }
        private static byte[] HashSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                throw new DomainException("A senha é obrigatória!");
            }

            using var sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
        }

        public LerUsuarioDTO ObterPorId (int id)
        {
            Usuario? usuario = _repository.ObterPorId(id);
            if (usuario == null)
            {
                throw new DomainException("Usuario não encontrado!");
            }
            return LerDTO(usuario);
        }
        public LerUsuarioDTO ObterPorEmail (string email)
        {
            Usuario? usuario = _repository.ObterPorEmail(email);
            if (usuario == null)
            {
                throw new DomainException("Usuario não encontrado!");
            }
            return LerDTO(usuario);
        }
    }
}

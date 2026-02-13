using System.Security.Cryptography;
using System.Text;
using VhBurguer.Controller;
using VhBurguer.Domains;
using VhBurguer.DTOs.UsuarioDTO;
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

        private static void ValIdarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                throw new DomainException("Email invalIdo!");
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

        public LerUsuarioDTO ObterPorId(int Id)
        {
            Usuario? usuario = _repository.ObterPorId(Id);
            if (usuario == null)
            {
                throw new DomainException("Usuario não encontrado!");
            }
            return LerDTO(usuario);
        }
        public LerUsuarioDTO ObterPorEmail(string email)
        {
            Usuario? usuario = _repository.ObterPorEmail(email);
            if (usuario == null)
            {
                throw new DomainException("Usuario não encontrado!");
            }
            return LerDTO(usuario);
        }

        public LerUsuarioDTO Adicionar(CriarUsuarioDTO usuarioDto)
        {
            ValIdarEmail(usuarioDto.Email);

            if (_repository.EmailExiste(usuarioDto.Email))
            {
                throw new DomainException("Já existe um usuário com este e-mail");
            }

            Usuario usuario = new Usuario // criando entIdade usuario
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Senha = HashSenha(usuarioDto.Senha),
                StatusUsuario = true
            };

            _repository.Adicionar(usuario);

            return LerDTO(usuario); // retorna LerDto para não retornar o objeto com a senha.

        }


        public LerUsuarioDTO Atualizar(int Id, CriarUsuarioDTO usuarioDto)
        {

            Usuario usuarioBanco = _repository.ObterPorId(Id);

            if (usuarioBanco == null)
            {
                throw new DomainException("Usuário não encontrado.");
            }

            ValIdarEmail(usuarioDto.Email);

            Usuario usuarioComMesmoEmail = _repository.ObterPorEmail(usuarioDto.Email);

            if (usuarioComMesmoEmail != null && usuarioComMesmoEmail.UsuarioId != Id)
            {
                throw new DomainException("Já existe um usuário com este e-mail.");
            }

            //Substitui as informações do banco (usuarioBanco)
            //Inserindo as alterações que estão vindo de usuarioDto.
            usuarioBanco.Nome = usuarioDto.Nome;
            usuarioBanco.Email = usuarioDto.Email;
            usuarioBanco.Senha = HashSenha(usuarioDto.Senha);

            _repository.Atualizar(usuarioBanco);

            return LerDTO(usuarioBanco);
        }
        public void Remover(int Id)
        {
            Usuario usuario = _repository.ObterPorId(Id);

            if (usuario == null)
            {
                throw new DomainException("Usuário não encontrado.");
            }

            _repository.Deletar(Id);
        }
    }
}
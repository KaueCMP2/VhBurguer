using VhBurguer.Contexts;
using VhBurguer.Controller;
using VhBurguer.Domains;
using VhBurguer.DTOs;

namespace VhBurguer.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly VhBurguerDbContext _ctx;

        public UsuarioRepository(VhBurguerDbContext context)
        {
            _ctx = context;
        }

        public List<Usuario> Listar()
        {
            return _ctx.Usuario.ToList();
        }

        public Usuario? ObterPorId(int Id)
        {
            return _ctx.Usuario.Find(Id);
        }

        public Usuario? ObterPorEmail(string email)
        {
            return _ctx.Usuario.FirstOrDefault(u => u.Email == email);
        }

        public bool EmailExiste(string email)
        {
            return _ctx.Usuario.Any(u => u.Email == email);
        }

        public void Adicionar(Usuario usuario)
        {
            _ctx.Usuario.Add(usuario);
            _ctx.SaveChanges();
        }

        public void Atualizar(Usuario usuario)
        {
            Usuario? usuarioBanco = _ctx.Usuario.FirstOrDefault(u => u.UsuarioId == usuario.UsuarioId);
            if (usuarioBanco == null)
            {
                return;
            }
            usuarioBanco.Nome = usuario.Nome;
            usuarioBanco.Email = usuario.Email;
            usuarioBanco.Senha = usuario.Senha;

            _ctx.Usuario.Update(usuario);
            _ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            var usuario = _ctx.Usuario.FirstOrDefault(u => u.UsuarioId == Id);
            if (usuario == null)
            {
                return;
            }
            _ctx.Usuario.Remove(usuario);
            _ctx.SaveChanges();
        }
    }
}

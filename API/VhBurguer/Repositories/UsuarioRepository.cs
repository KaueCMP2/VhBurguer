using VhBurguer.Contexts;
using VhBurguer.Controller;
using VhBurguer.Domains;
using VhBurguer.DTOs;

namespace VhBurguer.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly VhBurguerDbContext ctx;

        public UsuarioRepository(VhBurguerDbContext context)
        {
            ctx = context;
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }

        public Usuario? ObterPorId(int id)
        {
            return ctx.Usuario.Find(id);
        }

        public Usuario? ObterPorEmail(string email)
        {
            return ctx.Usuario.FirstOrDefault(u => u.Email == email);
        }

        public bool EmailExiste(string email)
        {
            return ctx.Usuario.Any(u => u.Email == email);
        }

        public void adicionar(Usuario usuario)
        {
            ctx.Usuario.Add(usuario);
            ctx.SaveChanges();
        }

        public void Atualizar(Usuario usuario)
        {
            Usuario? usuarioBanco = ctx.Usuario.FirstOrDefault(u => u.UsuarioId == usuario.UsuarioId);
            if (usuarioBanco == null)
            {
                return;
            }
            usuarioBanco.Nome = usuario.Nome;
            usuarioBanco.Email = usuario.Email;
            usuarioBanco.Senha = usuario.Senha;

            ctx.Usuario.Update(usuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            var usuario = ctx.Usuario.FirstOrDefault(u => u.UsuarioId == id);
            if (usuario == null)
            {
                return;
            }
            ctx.Usuario.Remove(usuario);
            ctx.SaveChanges();
        }
    }
}

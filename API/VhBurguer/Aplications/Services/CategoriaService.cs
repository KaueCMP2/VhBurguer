using VhBurguer.Domains;
using VhBurguer.DTOs.CategoriaDTO;
using VhBurguer.Exceptions;
using VhBurguer.Interfaces;
using VhBurguer.Repositories;

namespace VhBurguer.Aplications.Services
{
    public class CategoriaService
    {
        private readonly ICategoriaRepository _repository;
        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public List<LerCategoriaDTO> Listar()
        {
            List<Categoria> categorias = _repository.Listar();
            List<LerCategoriaDTO> categoriaDTO = categorias.Select(Categoria => new LerCategoriaDTO
            {
                CategoriaId = Categoria.CategoriaId,
                Nome = Categoria.Nome
            }).ToList();

            return categoriaDTO;
        }

        public LerCategoriaDTO ObterPorId(int id)
        {
            Categoria categoria = _repository.ObterPorId(id);
            if (categoria == null)
            {
                throw new DomainException("Categoria nâo encontrada");
            }

            LerCategoriaDTO categoriaDTO = new LerCategoriaDTO
            {
                CategoriaId = categoria.CategoriaId,
                Nome = categoria.Nome
            };
            return categoriaDTO;
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("O nome da categoria é obrigatório");
            }
        }

        public void Adicionar(CriarCategoriaDTO criarDTO)
        {
            ValidarNome(criarDTO.Nome);
            if (_repository.NomeExiste(criarDTO.Nome))
            {
                throw new DomainException("Já existe uma categoria com esse nome");
            }
            Categoria categoria = new Categoria
            {
                Nome = criarDTO.Nome
            };
            _repository.Adicionar(categoria);
        }

        public void Atualizar(int id, CriarCategoriaDTO criarDTO)
        {
            ValidarNome(criarDTO.Nome);
            Categoria categoriaBanco = _repository.ObterPorId(id);
            if (categoriaBanco == null)
            {
                throw new DomainException("Categoria nâo encontrada");
            }

            if (_repository.NomeExiste(criarDTO.Nome, id))
            {
                throw new DomainException("Já existe uma categoria com esse nome");
            }

            categoriaBanco.Nome = criarDTO.Nome;
            _repository.Atualizar(categoriaBanco);
        }

        public void Remover(int id)
        {
            Categoria categoriaBanco = _repository.ObterPorId(id);
            if (categoriaBanco == null)
            {
                throw new DomainException("Categoria nâo encontrada");
            }
            _repository.Remover(id);
        }
    }
}
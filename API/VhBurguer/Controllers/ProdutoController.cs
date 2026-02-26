using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Security.Claims;
using VhBurguer.DTOs.ProdutosDTO;
using VhBurguer.Exceptions;
using VhBurguer.Applications.Services;
using VhBurguer.DTOs.ProdutoDto;

namespace VhBurguer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _service;

        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }

        // autenticação do usuário
        private int ObterUsuarioIdLogado()
        {
            // busca no token/claims o valor armazenado como id do usuário
            // ClaimTypes.NameIdentifier geralmente guarda o ID do usuário no JWT
            string? idTexto = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrWhiteSpace(idTexto))
            {
                throw new DomainException("Usuário não autenticado");
            }

            // Converte o ID que veio como texto para inteiro
            // nosso UsuarioID no sistema está como int
            // as Claims (informações do usuário dentro do token) sempre são armazenadas como texto.
            return int.Parse(idTexto);
        }


        [HttpGet]
        public ActionResult<List<LerProdutoDTO>> Listar()
        {
            List<LerProdutoDTO> produtos = _service.Listar();

            //return StatusCode(200, produtos);
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public ActionResult<LerProdutoDTO> ObterPorId(int id)
        {
            LerProdutoDTO produto = _service.ObterPorId(id);

            if (produto == null)
            {
                //return StatusCode(404);
                return NotFound();
            }

            return Ok(produto);
        }
        [HttpPost]
        [Consumes("Multipart/Form-Data")] // Indica que recebe dados no formato multpart/from-data
        [Authorize] // exige login para adicionar produtos
        public IActionResult Adicionar([FromForm] CriarProdutoDTO produtoDTO)
        {
            try
            {
                int usuarioId = ObterUsuarioIdLogado();

                // cadastro fica associado ao usuario logado
                _service.Adicionar(produtoDTO, usuarioId);

                return StatusCode(201);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }   
        }

        [HttpPut("(id)")]
        [Authorize]
        public IActionResult Atualizar(int id, [FromForm] AtuallizarProdutoDTO produtoDTO)
        {
            try
            {
                _service.Atualizar(id, produtoDTO);
                return NoContent();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
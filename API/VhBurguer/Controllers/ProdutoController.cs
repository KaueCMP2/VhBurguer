using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using VhBurguer.DTOs.ProdutosDTO;
using VHBurguer.Applications.Services;

namespace VHBurguer.Controllers
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
        }
    }
}
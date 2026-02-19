using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

    }
}
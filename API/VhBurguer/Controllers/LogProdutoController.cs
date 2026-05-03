using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VhBurguer.Aplications.Services;
using VhBurguer.Repositories;

namespace VhBurguer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogProdutoController : ControllerBase
    {
        private readonly LogAlteracaoProdutoService _service;

        public LogProdutoController(LogAlteracaoProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("produto/{Id}")]
        public IActionResult ListarPorProduto(int produtoId)
        {
            return Ok(_service.ListarPorProduto(produtoId));
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VhBurguer.Applications.Services;
using VhBurguer.DTOs.PromocaoDto;

namespace VhBurguer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocaoController : ControllerBase
    {
        private readonly PromocaoService _service;

        public PromocaoController(PromocaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerPromocaoDTO>> Listar()
        {
            List<LerPromocaoDTO> promocoes = _service.Listar();
            return Ok(promocoes);
        }

        [HttpGet("{id}")]
        public ActionResult<LerPromocaoDTO> ObterPorId(int id)
        {
            LerPromocaoDTO promocao = _service.ObterPorId(id);
            if (promocao == null)
                return NotFound();

            return Ok(promocao);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Adicionar(CriarPromocaoDTO criarDTO)
        {
            try
            {
                _service.Adicionar(criarDTO);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Atualizar(int id, CriarPromocaoDTO atualizarDTO)
        {
            try
            {
                _service.Atualizar(id, atualizarDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

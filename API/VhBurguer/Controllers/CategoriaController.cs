using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VhBurguer.Aplications.Services;
using VhBurguer.DTOs.CategoriaDTO;
using VhBurguer.Exceptions;

namespace VhBurguer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _service;

        public CategoriaController(CategoriaService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerCategoriaDTO>> Listar()
        {
            List<LerCategoriaDTO> categorias = _service.Listar();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public ActionResult<LerCategoriaDTO> ObterPorId(int id)
        {
            LerCategoriaDTO categoria = _service.ObterPorId(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Adicionar(CriarCategoriaDTO criarDTO)
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
        public ActionResult Atualizar(int id, CriarCategoriaDTO atualizarDTO)
        {
            try
            {
                _service.Atualizar(id, atualizarDTO);
                return NoContent();
            }
            catch (DomainException ex)
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
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
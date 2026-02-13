using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VhBurguer.Aplications.Services;
using VhBurguer.DTOs.UsuarioDTO;
using VhBurguer.Exceptions;


namespace VHBurguer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioServices _service;

        public UsuarioController(UsuarioServices service)
        {
            _service = service;
        }

        // GET -> lista informações
        [HttpGet]
        public ActionResult<List<LerUsuarioDTO>> Listar()
        {
            List<LerUsuarioDTO> usuarios = _service.Listar();

            // retorna a lista de usuários, a partir da DTO de Services
            return Ok(usuarios); // OK - 200 - DEU CERTO
        }

        [HttpGet("{Id}")]
        public ActionResult<LerUsuarioDTO> ObterPorId(int Id)
        {
            LerUsuarioDTO usuario = _service.ObterPorId(Id);

            if (usuario == null)
            {
                return NotFound(); // NÃO ENCONTRADO - StatusCode 404
            }

            return Ok(usuario);
        }

        [HttpGet("email/{email}")]
        public ActionResult<LerUsuarioDTO> ObterPorEmail(string email)
        {
            LerUsuarioDTO usuario = _service.ObterPorEmail(email);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // POST - Envia dados 
        [HttpPost]
        public ActionResult<LerUsuarioDTO> Adicionar(CriarUsuarioDTO usuarioDto)
        {
            try
            {
                LerUsuarioDTO usuarioCriado = _service.Adicionar(usuarioDto);

                return StatusCode(201, usuarioCriado);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Realiza alterações de todos os dados
        [HttpPut("{Id}")]
        public ActionResult<LerUsuarioDTO> Atualizar(int Id, CriarUsuarioDTO usuarioDto)
        {
            try
            {
                LerUsuarioDTO usuarioAtualizado = _service.Atualizar(Id, usuarioDto);

                return StatusCode(200, usuarioAtualizado);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Remove os dados
        // no nosso banco o delete vai inativar o usuário
        // por conta da trigger (processo chamado de soft delete)
        [HttpDelete("{Id}")]
        public ActionResult Remover(int Id)
        {
            try
            {
                _service.Remover(Id);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
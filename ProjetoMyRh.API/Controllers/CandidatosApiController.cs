using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoMyRh.API.Models.Entities;
using ProjetoMyRh.API.Services;

namespace ProjetoMyRh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatosApiController : ControllerBase
    {
        private readonly CandidatosService candidatosService;
        public CandidatosApiController(CandidatosService candidatosService)
        {
            this.candidatosService = candidatosService;
        }

        [HttpGet]
        public IActionResult ListarCandidatos()
        {
            return Ok(candidatosService.Listar());
        }

        [HttpPost]
        public IActionResult IncluirCandidato(Candidato candidato)
        {
            candidatosService.Incluir(candidato);
            return Created("/api/candidatoapi", candidato);
        }

        [HttpPut]
        public IActionResult AlterarCandidato(Candidato candidato)
        {
            try
            {
                candidatosService.Alterar(candidato);
                return NoContent();
            }
            catch (Exception e)
            {
                var erro = new
                {
                    status = 403,
                    message = e.Message
                };
                return BadRequest(erro);
            } 
            
        }

        [HttpDelete]
        public IActionResult RemoverCandidato(Candidato candidato)
        {
            try
            {
                candidatosService.Remover(candidato);
                return NoContent();
            }
            catch (Exception e)
            {

                var erro = new
                {
                    status = 403,
                    message = e.Message,
                };

                return BadRequest(erro);
            }
        }
        [HttpDelete("remover/{cpf}")]
        public IActionResult RemoverCandidato(string cpf)
        {
            try
            {
                var candidato = candidatosService.Buscar(cpf);
                if (candidato == null)
                {
                    throw new Exception("CPF não encontrado.");
                }
                candidatosService.Remover(candidato);
                return NoContent();
            }
            catch (Exception e)
            {
                var erro = new
                {
                    status = 403,
                    message = e.Message,
                };
                return BadRequest(erro);
            }
        }
    }
}

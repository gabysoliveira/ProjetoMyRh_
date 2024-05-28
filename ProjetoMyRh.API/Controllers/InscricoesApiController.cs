using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoMyRh.API.Services;

namespace ProjetoMyRh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricoesApiController : ControllerBase
    {
        private readonly InscricoesService inscricoesService;

        public InscricoesApiController(InscricoesService inscricoesService)
        {
            this.inscricoesService = inscricoesService;
        }

        [HttpGet]
        public ActionResult ListarInscricoes()
        {
            return Ok(inscricoesService.ListarInscricoes());
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ProjetoMyRh.ClienteAPI.Models;
using ProjetoMyRh.ClienteAPI.Services;

namespace ProjetoMyRh.ClienteAPI.Controllers
{
    public class CandidatosController : Controller
    {
        private readonly CandidatosService candidatosService;

        public CandidatosController(CandidatosService candidatosService)
        {
            this.candidatosService = candidatosService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarCandidatos()
        {
            try
            {
                var candidatos = await candidatosService.ListarCAndidatosAsync();
                return View(candidatos);
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }

        [HttpGet]
        public IActionResult IncluirCandidato()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IncluirCandidato(Candidato candidato)
        {
            try
            {
                await candidatosService.IncluirCandidatoAsync(candidato);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                return View("_Erro", e);
            }
        }
    }
}

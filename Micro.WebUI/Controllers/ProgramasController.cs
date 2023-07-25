using Micro.Aplicacao.DTOs;
using Micro.Aplicacao.Interfaces;
using Micro.Aplicacao.Servicos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Micro.WebUI.Controllers
{
    [Authorize]
    public class ProgramasController : Controller
    {
        private readonly IProgramaServico _programatService;


        public ProgramasController(IProgramaServico programatService)
        {
            _programatService = programatService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var programas = await _programatService.GetProgramas();
            return View(programas);
        }

        [HttpGet]
        public async Task<IActionResult> Criar()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Criar(ProgramaDTO programaDTO)
        {
            if (ModelState.IsValid)
            { 
                var resultado  = await _programatService.GetVerificaAquecimentoIgual(programaDTO.Aquece, 0);
                if (resultado == null)
                {
                    await _programatService.Add(programaDTO);
                    return RedirectToAction(nameof(Index));
                }
            
            }
            ModelState.AddModelError("Error", "Simbolo Aquece já existente");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {

            if (id == null) return NotFound();
            var programaDTO = await _programatService.GetById(id);

            if (programaDTO == null) return NotFound();

            return View(programaDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ProgramaDTO programaDTO)
        {
            var resultado = await _programatService.GetVerificaAquecimentoIgual(programaDTO.Aquece, programaDTO.Id);//nao existir mesmo simbolo sem ser do mesmo produto
            if (resultado == null)
            {
                if (ModelState.IsValid)
                {
                    await _programatService.Update(programaDTO);
                    return RedirectToAction(nameof(Index));
                }
                return View(programaDTO);
            }

            ModelState.AddModelError("Error", "Simbolo Aquece já existente");

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
                return NotFound();

            var programaDTO = await _programatService.GetById(id);

            if (programaDTO == null) return NotFound();

            return View(programaDTO);
        }

        [HttpPost(), ActionName("Deletar")]
        public async Task<IActionResult> ConfirmarDelecao(int id)
        {
            await _programatService.Remove(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null) return NotFound();
            var programaDTO = await _programatService.GetById(id);

            if (programaDTO == null) return NotFound();

            return View(programaDTO);
        }
    }
}

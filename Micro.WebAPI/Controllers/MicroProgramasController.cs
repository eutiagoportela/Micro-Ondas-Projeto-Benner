using Micro.Aplicacao.DTOs;
using Micro.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Micro.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MicroProgramasController : ControllerBase
    {
        private readonly IProgramaServico _programaService;
        private readonly ILogger<MicroProgramasController> _logger;
        private readonly ILoggerFactory _loggerFactory;

        public MicroProgramasController(IProgramaServico programaService, ILogger<MicroProgramasController> logger, ILoggerFactory loggerFactory)
        {
            _programaService = programaService;
            _logger = logger; 
            _loggerFactory = loggerFactory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramaDTO>>> Get()
        {
            _logger.LogInformation("#### GetProgramas -> Obtendo todos os programas");

            var programas = await _programaService.GetProgramas();
            if (programas == null)
            {
                throw new KeyNotFoundException("Programa não encontrado");
                //  return NotFound("Programas não encontrado");
            }

            return Ok(programas);
        }


        [HttpGet("{id}", Name = "GetProgramas")]
        public async Task<ActionResult<ProgramaDTO>> Get(int id)
        {
            _logger.LogInformation("#### GetPrograma -> Obtendo programa por ID");

            var programa = await _programaService.GetById(id);
            if (programa == null)
            {
                throw new KeyNotFoundException("Programa não encontrado");
             //   return NotFound("Programa não encontrado");
            }
            return Ok(programa);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProgramaDTO programaDTO)
        {
            _logger.LogInformation("#### Post Programa -> Adicionando Programa");

            var resultado = await _programaService.GetVerificaAquecimentoIgual(programaDTO.Aquece, 0);

            if (resultado == null)
            {
                if (programaDTO == null)
                    throw new KeyNotFoundException("Dados inválidos");
                //  return BadRequest("Dados inválidos");

                await _programaService.Add(programaDTO);

                return new CreatedAtRouteResult("GetProgramas",
                    new { id = programaDTO.Id }, programaDTO);
            }
            else
                throw new KeyNotFoundException("Icone de aquecimento já cadastrado em outro Programa");
            // return BadRequest("Icone de aquecimento já cadastrado em outro Programa");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProgramaDTO programaDTO)
        {
            _logger.LogInformation("#### Put Programa -> Alterando Programa");

            if (programaDTO.Id > 5)
            {
                if (id != programaDTO.Id)
                {
                    throw new KeyNotFoundException("Dados inválidos, Id diferente");
                    // return BadRequest("Dados inválidos");
                }

                if (programaDTO == null)
                    throw new KeyNotFoundException("Dados inválidos");
                // return BadRequest("Dados inválidos");

                await _programaService.Update(programaDTO);
                return Ok(programaDTO);
            }
            else
                throw new KeyNotFoundException("Não é possível alterar os 5 pré cadastros");
            // return BadRequest("Não é possível alterar os 5 pré cadastros");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProgramaDTO>> Delete(int id)
        {
            _logger.LogInformation("#### Delete Programa -> Deletando Programa");

            if (id > 5)
            {
                var programaDTO = await _programaService.GetById(id);

                if (programaDTO == null)
                {
                    throw new KeyNotFoundException("Programa não encontrado");
                 //   return NotFound("Programa não encontrado");
                }

                await _programaService.Remove(id);

                return Ok(programaDTO);
            }
            else
                throw new KeyNotFoundException("Não é possível excluir os 5 pré cadastros");
            // return BadRequest("Não é possível excluir os 5 pré cadastros");
        }

        [HttpPost("{id}", Name = "GetProgramasIconeAquecerIgual")]
        public async Task<ActionResult<ProgramaDTO>> GetProgramasIconeAquecerIgual(int id, [FromBody] string? aquecerIcone)
        {
            _logger.LogInformation("#### Post Programa -> Verificando Icone Programa");

            var programaDTO = await _programaService.GetVerificaAquecimentoIgual(aquecerIcone,id);

            if (programaDTO == null)
            {
                throw new KeyNotFoundException("Não existe produto com este icone de aquecimento");
                // return NotFound("Não existe produto com este icone de aquecimento");
            }

            await _programaService.Remove(id);

            return Ok(programaDTO);
        }
    }
}

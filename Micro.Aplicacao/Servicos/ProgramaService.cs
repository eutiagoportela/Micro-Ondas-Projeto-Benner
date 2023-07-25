
using AutoMapper;
using Micro.Aplicacao.DTOs;
using Micro.Aplicacao.Interfaces;
using Micro.Dominio.Entidades;
using Micro.Dominio.Interfaces;

namespace Micro.Aplicacao.Servicos;

public class ProgramaService : IProgramaServico
{
    private IProgramasRepositorio _programasRepositorio;

    private readonly IMapper _mapper;
    public ProgramaService(IMapper mapper, IProgramasRepositorio programasRepositorio)
    {
        _programasRepositorio = programasRepositorio;

        _mapper = mapper;
    }

    public async Task<ProgramaDTO> GetById(int? id)
    {
        var programaEntidade = await _programasRepositorio.GetById(id);
        return _mapper.Map<ProgramaDTO>(programaEntidade);
    }

    public async Task Add(ProgramaDTO programaDTO)
    {
        var programaEntidade = _mapper.Map<Programas>(programaDTO);
        await _programasRepositorio.CriaraAsync(programaEntidade);
    }

    public async Task Update(ProgramaDTO programaDTO)
    {
        var programaEntidade = _mapper.Map<Programas>(programaDTO);
        await _programasRepositorio.AtualizarAsync(programaEntidade);
    }

    public async Task Remove(int? id)
    {
        var programaEntidade = await _programasRepositorio.GetById(id);
        await _programasRepositorio.RemoverAsync(programaEntidade);
    }

    public async Task<IEnumerable<ProgramaDTO>> GetProgramas()
    {
        var programaEntidade = await _programasRepositorio.GetProgramasAsync();
        return _mapper.Map<IEnumerable<ProgramaDTO>>(programaEntidade);
    }

    public async Task<List<ProgramaDTO>> GetProgramasLista()
    {
        var programaEntidade = await _programasRepositorio.GetProgramasAsyncList(); 
        return _mapper.Map<List<ProgramaDTO>>(programaEntidade);
    }

    public async Task<ProgramaDTO> GetVerificaAquecimentoIgual(string aquece,int id)
    {
        var programaEntidade = await _programasRepositorio.GetVerificaSimboloAqueceIgual(aquece,id);
        return _mapper.Map<ProgramaDTO>(programaEntidade);
    }
}


using Micro.Aplicacao.DTOs;

namespace Micro.Aplicacao.Interfaces;

public  interface IProgramaServico
{
    Task<ProgramaDTO> GetById(int? id);

    Task Add(ProgramaDTO productDto);
    Task Update(ProgramaDTO productDto);
    Task Remove(int? id);
    Task<IEnumerable<ProgramaDTO>> GetProgramas();
    Task <List<ProgramaDTO>> GetProgramasLista();
    Task<ProgramaDTO> GetVerificaAquecimentoIgual(string aquece,int id);
}

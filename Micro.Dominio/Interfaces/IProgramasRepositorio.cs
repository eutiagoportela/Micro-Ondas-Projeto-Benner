

using Micro.Dominio.Entidades;

namespace Micro.Dominio.Interfaces;

public interface IProgramasRepositorio
{
    Task<Programas> GetById(int? id);
    Task<Programas> CriaraAsync(Programas programas);
    Task<Programas> AtualizarAsync(Programas programas);
    Task<Programas> RemoverAsync(Programas programas);
    Task<IEnumerable<Programas>> GetProgramasAsync();
    Task<List<Programas>> GetProgramasAsyncList();
    Task<Programas> GetVerificaSimboloAqueceIgual(string aquece,int id);
}

using Micro.Dominio.Entidades;
using Micro.Dominio.Interfaces;
using Micro.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;


namespace Micro.Infra.Data.Repositorios;

public class ProgramasRepositorio : IProgramasRepositorio
{
    ApplicationDbContext _programasContexto;

    public ProgramasRepositorio(ApplicationDbContext context)
    {
        _programasContexto = context;
    }

    public async Task<Programas> AtualizarAsync(Programas programas)
    {
        _programasContexto.ChangeTracker.Clear();
        _programasContexto.Update(programas);
        await _programasContexto.SaveChangesAsync();
        return programas;
    }

    public async Task<Programas> CriaraAsync(Programas programas)
    {
        _programasContexto.Add(programas);
        await _programasContexto.SaveChangesAsync();
        return programas;
    }

    public async Task<Programas> GetById(int? id)
    {
        return await _programasContexto.Programas.FindAsync(id);
    }

    public async Task<IEnumerable<Programas>> GetProgramasAsync()
    {
        return await _programasContexto.Programas.ToListAsync();
    }

    public async Task<List<Programas>> GetProgramasAsyncList()
    {
        return await _programasContexto.Programas.ToListAsync(); 
    }

    public async Task<Programas> GetVerificaSimboloAqueceIgual(string aquece,int id)
    {
        if(id == 0)
          return await _programasContexto.Programas.SingleOrDefaultAsync(p => p.Aquece == aquece);
        else
            return await _programasContexto.Programas.SingleOrDefaultAsync(p => p.Aquece == aquece && p.Id != id);
    }

    public async Task<Programas> RemoverAsync(Programas programas)
    {
        _programasContexto.Remove(programas);
        await _programasContexto.SaveChangesAsync();
        return programas;
    }
}

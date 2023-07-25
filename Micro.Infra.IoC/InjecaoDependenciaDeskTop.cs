using Micro.Aplicacao.Interfaces;
using Micro.Aplicacao.Servicos;
using Micro.Dominio.Interfaces;
using Micro.Infra.Data.Contexto;
using Micro.Infra.Data.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Micro.Infra.IoC;

public static class InjecaoDependenciaDeskTop
{
    public static IServiceCollection AddInfrasctrutureDesktop(this IServiceCollection services,
       IConfiguration configuration)
    {
     services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
         b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IProgramasRepositorio, ProgramasRepositorio>();

        services.AddScoped<IProgramaServico, ProgramaService>();
        services.AddAutoMapper(typeof(DominioToDTOPerfilMapeamento));

        return services;
    }

}
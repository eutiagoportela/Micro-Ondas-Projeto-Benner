using Micro.Aplicacao.Interfaces;
using Micro.Aplicacao.Servicos;
using Micro.Dominio.Account;
using Micro.Dominio.Interfaces;
using Micro.Infra.Data.Contexto;
using Micro.Infra.Data.Identity;
using Micro.Infra.Data.Repositorios;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Micro.Infra.IoC;

public static class InjecaoDependenciaWebAPI 
{
    public static IServiceCollection AddInfrasctrutureAPI(this IServiceCollection services,
       IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        //definicao Usuario
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        services.AddScoped<IAutenticacao, AuthenticateService>();
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();


        services.AddScoped<IProgramasRepositorio, ProgramasRepositorio>();
        services.AddScoped<IProgramaServico, ProgramaService>();
        services.AddAutoMapper(typeof(DominioToDTOPerfilMapeamento));


        return services;
    }
}

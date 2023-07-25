using Microsoft.Extensions.DependencyInjection;
using Micro.Infra.IoC;
using Microsoft.Extensions.Hosting;

namespace Micro.FrontDesktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build();
            Application.Run(host.Services.GetRequiredService<F_Principal>());
        }
        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddInfrasctrutureDesktop(context.Configuration);
                    services.AddTransient<F_Principal>();
                });
    }
}
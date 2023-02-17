using CalculatorTest.Infrastructure;
using CalculatorTest.Infrastructure.Repositories;
using CalculatorTest.Infrastructure.Repositories.Interfaces;
using CalculatorTest.Services.Services;
using CalculatorTest.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using System;
using System.Threading.Tasks;

namespace CalculatorConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            var calculatorUI = host.Services.GetService<ICalculatorUI>();
            await calculatorUI.RenderAsync();

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, serviceProvider) =>
                {
                    serviceProvider.AddScoped<ICalculatorUI, CalculatorUI>();

                    serviceProvider.AddDbContext<CalculatorDBContext>(options => options.UseSqlServer(context.Configuration.GetConnectionString("CalculatorDB")));

                    // repositories
                    serviceProvider.AddScoped<ILogRepository, LogRepository>();
                    //serviceProvider.AddScoped<ILogRepository, LogRepositorySP>();

                    // services
                    serviceProvider.AddScoped<ISimpleCalculator, SimpleCalculator>();
                    //serviceProvider.AddScoped<IDiagnostics, DiagnosticsConsole>();
                    serviceProvider.AddScoped<IDiagnostics, DiagnosticsPersist>();

                    serviceProvider.AddRefitClient<ICalculatorClient>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(
                        context.Configuration.GetValue<string>($"CalculatorApi:BaseUri")
                    ));

                    serviceProvider.BuildServiceProvider();
                });
        }
    }
}

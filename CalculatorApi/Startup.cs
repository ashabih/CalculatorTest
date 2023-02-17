using CalculatorTest.Infrastructure;
using CalculatorTest.Infrastructure.Repositories;
using CalculatorTest.Infrastructure.Repositories.Interfaces;
using CalculatorTest.Services.Services;
using CalculatorTest.Services.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CalculatorApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CalculatorApi", Version = "v1" });
            });

            var connectionString = Configuration.GetConnectionString("CalculatorDB");
            services.AddDbContext<CalculatorDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CalculatorDB")));

            // repositories
            services.AddScoped<ILogRepository, LogRepository>();
            //services.AddScoped<ILogRepository, LogRepositorySP>();

            // services
            services.AddScoped<ISimpleCalculator, SimpleCalculator>();
            //services.AddScoped<IDiagnostics, DiagnosticsConsole>();
            services.AddScoped<IDiagnostics, DiagnosticsPersist>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CalculatorApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

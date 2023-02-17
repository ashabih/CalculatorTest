using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using Microsoft.Extensions.Configuration;

namespace CalculatorTest.Infrastructure
{
    public class CampContextFactory : IDesignTimeDbContextFactory<CalculatorDBContext>
    {
        CalculatorDBContext IDesignTimeDbContextFactory<CalculatorDBContext>.CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\CalculatorConsole")
              .AddJsonFile("appsettings.json")
              .Build();

            return new CalculatorDBContext(new DbContextOptionsBuilder<CalculatorDBContext>().Options, config);
        }
    }
}

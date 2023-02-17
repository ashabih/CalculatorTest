using CalculatorTest.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CalculatorTest.Infrastructure
{
    public class CalculatorDBContext : DbContext
    {
        private readonly IConfiguration _config;
        public DbSet<Log> Logs { get; set; }

        public CalculatorDBContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("CalculatorDB"));
        }
    }
}

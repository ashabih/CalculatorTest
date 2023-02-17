using CalculatorTest.Infrastructure.Models;
using CalculatorTest.Infrastructure.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace CalculatorTest.Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly CalculatorDBContext _calculatorDBContext;

        public LogRepository(CalculatorDBContext calculatorDBContext)
        {
            _calculatorDBContext = calculatorDBContext ?? throw new ArgumentNullException(nameof(calculatorDBContext));
        }

        public async Task AddLog(Log log)
        {
            if (log == null)
            {
                throw new ArgumentNullException(nameof(log));
            }

            if (string.IsNullOrEmpty(log.Message))
            {
                throw new ArgumentNullException(nameof(log.Message));
            }

            _calculatorDBContext.Logs.Add(log);
            await _calculatorDBContext.SaveChangesAsync();
        }
    }
}

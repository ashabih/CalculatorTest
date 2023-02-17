using CalculatorTest.Infrastructure.Models;
using CalculatorTest.Infrastructure.Repositories.Interfaces;
using CalculatorTest.Services.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace CalculatorTest.Services.Services
{
    public class DiagnosticsPersist : IDiagnostics
    {
        private readonly ILogRepository _logRepository;

        public DiagnosticsPersist(ILogRepository logRepository)
        {
            _logRepository = logRepository ?? throw new ArgumentNullException(nameof(logRepository));
        }

        public async Task LogMessageAsync(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            await _logRepository.AddLog(new Log() { Message = message, CreatedDate = DateTime.Now });
        }
    }
}

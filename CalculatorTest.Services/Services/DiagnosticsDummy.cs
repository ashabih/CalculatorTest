using CalculatorTest.Services.Services.Interfaces;
using System.Threading.Tasks;

namespace CalculatorTest.Services.Services
{
    public class DiagnosticsDummy : IDiagnostics
    {
        public Task LogMessageAsync(string message)
        {
            return Task.CompletedTask;
        }
    }
}

using CalculatorTest.Services.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace CalculatorTest.Services.Services
{
    public class DiagnosticsConsole : IDiagnostics
    {
        public Task LogMessageAsync(string message)
        {
            Console.WriteLine(message);
            return Task.CompletedTask;
        }
    }
}

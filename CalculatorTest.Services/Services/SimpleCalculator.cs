using CalculatorTest.Services.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace CalculatorTest.Services.Services
{
    public class SimpleCalculator : ISimpleCalculator
    {
        private readonly IDiagnostics _diagnostics;

        public SimpleCalculator(IDiagnostics diagnostics)
        {
            _diagnostics = diagnostics ?? throw new ArgumentNullException(nameof(diagnostics));
        }
        public async Task<int> Add(int start, int amount)
        {
            var result = checked(start + amount);
            await _diagnostics.LogMessageAsync($"{nameof(Add)} result of numbers {start}, {amount}: {result}");
            return result;
        }

        public async Task<int> Subtract(int start, int amount)
        {
            var result = checked(start - amount);
            await _diagnostics.LogMessageAsync($"{nameof(Subtract)} result of numbers {start}, {amount}: {result}");
            return result;
        }

        public async Task<int> Multiply(int start, int by)
        {
            var result = checked(start * by);
            await _diagnostics.LogMessageAsync($"{nameof(Multiply)} result of numbers {start}, {by}: {result}");
            return result;
        }

        public async Task<int> Divide(int start, int by)
        {
            var result = checked(start / by);
            await _diagnostics.LogMessageAsync($"{nameof(Divide)} result of numbers {start}, {by}: {result}");
            return result;

        }
    }
}

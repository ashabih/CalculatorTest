using System.Threading.Tasks;

namespace CalculatorTest.Services.Services.Interfaces
{
    public interface IDiagnostics
    {
        Task LogMessageAsync(string message);
    }
}

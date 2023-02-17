using System.Threading.Tasks;

namespace CalculatorTest.Services.Services.Interfaces
{
    public interface ISimpleCalculator
    {
        Task<int> Add(int start, int amount);
        Task<int> Subtract(int start, int amount);
        Task<int> Multiply(int start, int by);
        Task<int> Divide(int start, int by);

    }
}

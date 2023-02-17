using Refit;
using System.Threading.Tasks;

namespace CalculatorConsole
{
    public interface ICalculatorClient
    {
        [Get("/calculator/add?number1={number1}&number2={number2}")]
        Task<int> Add(int number1, int number2);

        [Get("/calculator/subtract?number1={number1}&number2={number2}")]
        Task<int> Subtract(int number1, int number2);

        [Get("/calculator/divide?number1={number1}&number2={number2}")]
        Task<int> Divide(int number1, int number2);

        [Get("/calculator/multiply?number1={number1}&number2={number2}")]
        Task<int> Multiply(int number1, int number2);
    }
}

using CalculatorTest.Infrastructure.Models;
using System.Threading.Tasks;

namespace CalculatorTest.Infrastructure.Repositories.Interfaces
{
    public interface ILogRepository
    {
        Task AddLog(Log log);
    }
}

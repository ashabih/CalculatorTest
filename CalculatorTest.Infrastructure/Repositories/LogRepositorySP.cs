using CalculatorTest.Infrastructure.Models;
using CalculatorTest.Infrastructure.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CalculatorTest.Infrastructure.Repositories
{
    public class LogRepositorySP : ILogRepository
    {
        private readonly IConfiguration _config;

        public LogRepositorySP(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task AddLog(Log log)
        {
            using (SqlConnection sql = new SqlConnection(_config.GetConnectionString("CalculatorDB")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_AddLog", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@message", log.Message));
                    cmd.Parameters.Add(new SqlParameter("@createdDate", log.CreatedDate));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
    }
}

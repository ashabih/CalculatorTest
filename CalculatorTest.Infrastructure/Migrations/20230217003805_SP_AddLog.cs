using Microsoft.EntityFrameworkCore.Migrations;

namespace CalculatorTest.Infrastructure.Migrations
{
    public partial class SP_AddLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createProcSql = @"CREATE OR ALTER PROC sp_AddLog(@message NVARCHAR(255), @createdDate DATETIME) AS INSERT INTO dbo.Logs(Message, CreatedDate) VALUES(@message, @createdDate)";
            migrationBuilder.Sql(createProcSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropProcSql = "DROP PROC sp_AddLog";
            migrationBuilder.Sql(dropProcSql);
        }
    }
}

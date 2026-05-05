using AspnetCoreMvcFull.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AspnetCoreMvcFull.Repositories
{
  public class MetricsRepository(IConfiguration config)
  {
    private readonly string? _connectionString = config.GetConnectionString("DefaultConnection");

    public async Task<IEnumerable<Metric>> GetByDate(DateTime date)
    {
      await using var connection = new SqlConnection(_connectionString);

      const string sql =
        """
                    SELECT
                        ad_id AS AdId,
                        report_date AS ReportDate,
                        total_orders AS TotalOrders,
                        total_revenue AS TotalRevenue,
                        total_spend AS TotalSpend,
                        profit AS Profit
                    FROM metrics
                    WHERE report_date = @date

        """;

      return await connection.QueryAsync<Metric>(sql, new { date });
    }
  }
}

using AspnetCoreMvcFull.Models;
using Dapper;
using System.Data.SqlClient;

namespace AspnetCoreMvcFull.Repositories
{
  public class MetricsRepository
  {
    private readonly string _connectionString;

    public MetricsRepository(IConfiguration config)
    {
      _connectionString = config.GetConnectionString("Default");
    }

    public async Task<IEnumerable<Metric>> GetByDate(DateTime date)
    {
      using var connection = new SqlConnection(_connectionString);

      var sql = @"
            SELECT 
                ad_id AS AdId,
                report_date AS ReportDate,
                total_orders AS TotalOrders,
                total_revenue AS TotalRevenue,
                total_spend AS TotalSpend,
                profit AS Profit
            FROM metrics
            WHERE report_date = @date
        ";

      return await connection.QueryAsync<Metric>(sql, new { date });
    }
  }
}

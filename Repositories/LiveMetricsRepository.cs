using AspnetCoreMvcFull.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AspnetCoreMvcFull.Repositories
{
  public class LiveMetricsRepository(IConfiguration config)
  {
    private readonly string? _connectionString = config.GetConnectionString("DefaultConnection");

    public async Task<IEnumerable<LiveMetric>> GetMetrics()
    {
      await using var connection = new SqlConnection(_connectionString);

      return await connection.QueryAsync<LiveMetric>(
        "sp_calculate_live_metrics",
        commandType: CommandType.StoredProcedure
      );
    }
  }
}

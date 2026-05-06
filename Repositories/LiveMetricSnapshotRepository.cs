using AspnetCoreMvcFull.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AspnetCoreMvcFull.Repositories
{
  public class LiveMetricSnapshotRepository(IConfiguration config)
  {
    private SqlConnection GetConnection()
    {
      return new SqlConnection(config.GetConnectionString("DefaultConnection"));
    }

    public async Task<LiveMetricSnapshot?>GetLatest(long liveConfigId)
    {
      await using var conn = GetConnection();

      return await conn.QueryFirstOrDefaultAsync<LiveMetricSnapshot>(
        """
        SELECT TOP 1
            id AS Id,
            live_config_id AS LiveConfigId,
            total_revenue AS TotalRevenue,
            total_spend AS TotalSpend,
            profit AS Profit,
            created_at AS CreatedAt
        FROM live_metric_snapshots
        WHERE live_config_id = @liveConfigId
        ORDER BY id DESC
        """,
        new { liveConfigId }
      );
    }

    public async Task Create(LiveMetricSnapshot model)
    {
      await using var conn = GetConnection();

      await conn.ExecuteAsync(
        """
        INSERT INTO live_metric_snapshots
        (
            live_config_id,
            total_revenue,
            total_spend,
            profit
        )
        VALUES
        (
            @LiveConfigId,
            @TotalRevenue,
            @TotalSpend,
            @Profit
        )
        """,
        model
      );
    }
  }
}

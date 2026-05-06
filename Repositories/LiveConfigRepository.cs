using AspnetCoreMvcFull.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AspnetCoreMvcFull.Repositories
{
  public class LiveConfigRepository(IConfiguration config)
  {
    private SqlConnection GetConnection()
    {
      return new SqlConnection(
        config.GetConnectionString("DefaultConnection")
      );
    }

    public async Task<IEnumerable<LiveConfig>> GetAll()
    {
      await using var conn = GetConnection();

      return await conn.QueryAsync<LiveConfig>(
        """
        SELECT
            id AS Id,
            project_name AS ProjectName,
            page_id AS PageId,
            post_id AS PostId,
            close_rate AS CloseRate,
            delivery_rate AS DeliveryRate,
            import_cost_rate AS ImportCostRate,
            shipping_cost_rate AS ShippingCostRate,
            catse_cost AS CatseCost,
            is_active AS IsActive,
            is_reporting AS IsReporting
        FROM live_configs
        ORDER BY id DESC
        """
      );
    }

    public async Task Create(LiveConfig model)
    {
      await using var conn = GetConnection();

      await conn.ExecuteAsync(
        """
        INSERT INTO live_configs
        (
            project_name,
            page_id,
            post_id,

            close_rate,
            delivery_rate,

            import_cost_rate,
            shipping_cost_rate,

            catse_cost,

            is_active,
            is_reporting
        )
        VALUES
        (
            @ProjectName,
            @PageId,
            @PostId,

            @CloseRate,
            @DeliveryRate,

            @ImportCostRate,
            @ShippingCostRate,

            @CatseCost,

            @IsActive,
            @IsReporting
        )
        """,
        model
      );
    }
  }
}

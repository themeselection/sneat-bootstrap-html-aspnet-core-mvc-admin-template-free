using AspnetCoreMvcFull.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AspnetCoreMvcFull.Repositories
{
  public class LiveAdRepository(IConfiguration config)
  {
    private SqlConnection GetConnection()
    {
      return new SqlConnection(config.GetConnectionString("DefaultConnection"));
    }

    public async Task Create(LiveAd model)
    {
      await using var conn = GetConnection();

      await conn.ExecuteAsync(
        """
        INSERT INTO live_ads
        (
            live_config_id,
            ad_id
        )
        VALUES
        (
            @LiveConfigId,
            @AdId
        )
        """,
        model
      );
    }

    public async Task<IEnumerable<LiveAd>> GetByLiveId(long liveId)
    {
      await using var conn = GetConnection();

      return await conn.QueryAsync<LiveAd>(
        """
        SELECT
            id AS Id,
            live_config_id AS LiveConfigId,
            ad_id AS AdId
        FROM live_ads
        WHERE live_config_id = @liveId
        """,
        new { liveId }
      );
    }
  }
}

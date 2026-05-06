using AspnetCoreMvcFull.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AspnetCoreMvcFull.Repositories
{
  public class ReportLogRepository(IConfiguration config)
  {
    private SqlConnection GetConnection()
    {
      return new SqlConnection(config.GetConnectionString("DefaultConnection"));
    }

    public async Task<IEnumerable<ReportLog>>GetAll()
    {
      await using var conn = GetConnection();

      return await conn.QueryAsync<ReportLog>(
        """
        SELECT
            id AS Id,
            live_config_id AS LiveConfigId,
            message AS Message,
            is_success AS IsSuccess,
            error_message AS ErrorMessage,
            created_at AS CreatedAt
        FROM report_logs
        ORDER BY id DESC
        """
      );
    }

    public async Task Create(ReportLog model)
    {
      await using var conn = GetConnection();

      await conn.ExecuteAsync(
        """
        INSERT INTO report_logs
        (
            live_config_id,
            message,
            is_success,
            error_message
        )
        VALUES
        (
            @LiveConfigId,
            @Message,
            @IsSuccess,
            @ErrorMessage
        )
        """,
        model
      );
    }
  }
}

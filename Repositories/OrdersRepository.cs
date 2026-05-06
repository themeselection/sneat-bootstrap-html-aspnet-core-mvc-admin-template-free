using Dapper;
using Microsoft.Data.SqlClient;

namespace AspnetCoreMvcFull.Repositories
{
  public class OrdersRepository(IConfiguration config)
  {
    private SqlConnection GetConnection()
    {
      return new SqlConnection(config.GetConnectionString("DefaultConnection"));
    }

    public async Task Insert(
      string pageId,
      string postId,
      string adId,
      decimal revenue)
    {
      await using var conn = GetConnection();

      await conn.ExecuteAsync(
        """
        INSERT INTO orders
        (
            page_id,
            post_id,
            ad_id,
            revenue
        )
        VALUES
        (
            @pageId,
            @postId,
            @adId,
            @revenue
        )
        """,
        new
        {
          pageId,
          postId,
          adId,
          revenue
        }
      );
    }
  }
}

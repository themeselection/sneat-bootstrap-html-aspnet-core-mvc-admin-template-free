namespace AspnetCoreMvcFull.Models
{
  public class LiveMetricSnapshot
  {
    public long Id { get; set; }

    public long LiveConfigId { get; set; }

    public decimal TotalRevenue { get; set; }

    public decimal TotalSpend { get; set; }

    public decimal Profit { get; set; }

    public DateTime CreatedAt { get; set; }
  }
}

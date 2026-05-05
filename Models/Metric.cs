namespace AspnetCoreMvcFull.Models
{
  public class Metric
  {
    public required string AdId { get; set; }
    public DateTime ReportDate { get; set; }
    public int TotalOrders { get; set; }
    public decimal TotalRevenue { get; set; }
    public decimal TotalSpend { get; set; }
    public decimal Profit { get; set; }
  }
}

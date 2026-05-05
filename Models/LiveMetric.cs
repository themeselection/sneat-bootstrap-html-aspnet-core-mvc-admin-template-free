namespace AspnetCoreMvcFull.Models
{
  public class LiveMetric
  {
    public long Id { get; set; }

    public required string ProjectName { get; set; }

    public required string PostId { get; set; }

    public int TotalOrders { get; set; }

    public decimal TotalRevenue { get; set; }

    public decimal TotalSpend { get; set; }

    public decimal CloseRate { get; set; }

    public decimal DeliveryRate { get; set; }

    public decimal ImportCostRate { get; set; }

    public decimal ShippingCostRate { get; set; }

    public decimal CatseCost { get; set; }
  }
}

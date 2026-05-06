namespace AspnetCoreMvcFull.Models
{
  public class LiveConfig
  {
    public long Id { get; set; }

    public string ProjectName { get; set; } = "";

    public string PageId { get; set; } = "";

    public string PostId { get; set; } = "";

    public decimal CloseRate { get; set; }

    public decimal DeliveryRate { get; set; }

    public decimal ImportCostRate { get; set; }

    public decimal ShippingCostRate { get; set; }

    public decimal CatseCost { get; set; }

    public bool IsActive { get; set; }

    public bool IsReporting { get; set; }
  }
}

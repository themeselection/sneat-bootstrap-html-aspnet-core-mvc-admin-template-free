using AspnetCoreMvcFull.Models;

namespace AspnetCoreMvcFull.Services
{
  public class ReportBuilderService
  {
    public string Build(LiveMetric m)
    {
      var actualRevenue =
        m.TotalRevenue
        * (m.CloseRate / 100)
        * (m.DeliveryRate / 100);

      var importCost =
        actualRevenue
        * (m.ImportCostRate / 100);

      var shippingCost =
        actualRevenue
        * (m.ShippingCostRate / 100);

      var profit =
        actualRevenue
        - m.TotalSpend
        - importCost
        - shippingCost
        - m.CatseCost;

      return
        $"""
                 {m.ProjectName}
                 ----------------
                 Post Id: {m.PostId}
                 Lợi nhuận: {profit:N0}
                 Tổng chi tiêu: {m.TotalSpend:N0}
                 Doanh số: {m.TotalRevenue:N0}
                 Doanh thu thực: {actualRevenue:N0}
                 Tiền catse: {m.CatseCost:N0}
         """;
    }
  }
}

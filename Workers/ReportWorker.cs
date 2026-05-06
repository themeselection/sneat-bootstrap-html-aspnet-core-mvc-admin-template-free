using AspnetCoreMvcFull.Models;
using AspnetCoreMvcFull.Repositories;
using AspnetCoreMvcFull.Services;

namespace AspnetCoreMvcFull.Workers
{
  public class ReportWorker(
    IServiceProvider serviceProvider,
    ILogger<ReportWorker> logger
  ) : BackgroundService
  {
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      while (!stoppingToken.IsCancellationRequested)
      {
        try
        {
          logger.LogInformation("START LOOP");

          using var scope = serviceProvider.CreateScope();

          var repo = scope.ServiceProvider
            .GetRequiredService<LiveMetricsRepository>();
          var builder = scope.ServiceProvider
            .GetRequiredService<ReportBuilderService>();
          var lark = scope.ServiceProvider
            .GetRequiredService<LarkService>();
          var reportLogRepo = scope.ServiceProvider
            .GetRequiredService<ReportLogRepository>();
          var snapshotRepo = scope.ServiceProvider
            .GetRequiredService<LiveMetricSnapshotRepository>();

          var metrics = await repo.GetMetrics();

          foreach (var item in metrics)
          {
            var message = builder.Build(item);

            try
            {
              var actualRevenue =
                item.TotalRevenue
                * (item.CloseRate / 100)
                * (item.DeliveryRate / 100);

              var importCost =
                actualRevenue
                * (item.ImportCostRate / 100);

              var shippingCost =
                actualRevenue
                * (item.ShippingCostRate / 100);

              var profit =
                actualRevenue
                - item.TotalSpend
                - importCost
                - shippingCost
                - item.CatseCost;

              var latest = await snapshotRepo.GetLatest(item.Id);

              var changed =
                latest == null
                || latest.TotalRevenue != item.TotalRevenue
                || latest.TotalSpend != item.TotalSpend
                || latest.Profit != profit;

              if (!changed)
              {
                continue;
              }

              await lark.Send(message);

              await reportLogRepo.Create(
                new ReportLog
                {
                  LiveConfigId = item.Id,
                  Message = message,
                  IsSuccess = true
                }
              );

              await snapshotRepo.Create(
                new LiveMetricSnapshot
                {
                  LiveConfigId = item.Id,
                  TotalRevenue = item.TotalRevenue,
                  TotalSpend = item.TotalSpend,
                  Profit = profit
                }
              );
            }
            catch (Exception ex)
            {
              await reportLogRepo.Create(
                new ReportLog
                {
                  LiveConfigId = item.Id,
                  Message = message,
                  IsSuccess = false,
                  ErrorMessage = ex.Message
                }
              );
            }
          }
        }
        catch (Exception ex)
        {
          logger.LogError(ex, "WORKER ERROR");
        }

        await Task.Delay(
          TimeSpan.FromMinutes(5),
          stoppingToken
        );
      }
    }
  }
}

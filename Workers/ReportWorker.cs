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
      logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
      while (!stoppingToken.IsCancellationRequested)
      {
        using var scope = serviceProvider.CreateScope();
        var repo = scope.ServiceProvider
          .GetRequiredService<LiveMetricsRepository>();
        var builder = scope.ServiceProvider
          .GetRequiredService<ReportBuilderService>();
        var lark = scope.ServiceProvider
          .GetRequiredService<LarkService>();
        var metrics = await repo.GetMetrics();

        foreach (var item in metrics)
        {
          var message = builder.Build(item);
          await lark.Send(message);
        }

        await Task.Delay(
          // TimeSpan.FromMinutes(5),
          TimeSpan.FromSeconds(10),
          stoppingToken
        );
      }
    }
  }
}

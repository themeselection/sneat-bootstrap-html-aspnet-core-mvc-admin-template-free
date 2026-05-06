using AspnetCoreMvcFull.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcFull.Controllers;

public class DashboardsController(LiveMetricsRepository repo) : Controller
{
  public IActionResult Index() => View();

  public async Task<IActionResult> Live()
  {
    var data = await repo.GetMetrics();

    return View(data);
  }
}

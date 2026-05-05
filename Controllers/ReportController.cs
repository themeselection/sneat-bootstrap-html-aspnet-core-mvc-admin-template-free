using AspnetCoreMvcFull.Repositories;
using AspnetCoreMvcFull.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcFull.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ReportController(
    LiveMetricsRepository repo,
    ReportBuilderService builder)
    : ControllerBase
  {
    [HttpGet("test")]
    public async Task<IActionResult> Test()
    {
      var metrics = await repo.GetMetrics();

      var messages = metrics
        .Select(builder.Build);

      return Ok(messages);
    }
  }
}

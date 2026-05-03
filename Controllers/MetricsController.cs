using AspnetCoreMvcFull.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcFull.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MetricsController(MetricsRepository repo) : ControllerBase
  {
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] DateTime date)
    {
      var data = await repo.GetByDate(date);
      return Ok(data);
    }
  }
}

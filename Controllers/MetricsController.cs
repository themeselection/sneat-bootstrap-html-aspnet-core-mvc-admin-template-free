using AspnetCoreMvcFull.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcFull.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MetricsController : ControllerBase
  {
    private readonly MetricsRepository _repo;

    public MetricsController(MetricsRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] DateTime date)
    {
      var data = await _repo.GetByDate(date);
      return Ok(data);
    }
  }
}

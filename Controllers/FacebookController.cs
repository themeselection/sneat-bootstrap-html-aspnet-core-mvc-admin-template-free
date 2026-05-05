using AspnetCoreMvcFull.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcFull.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FacebookController(FacebookAdsService service) : ControllerBase
  {
    [HttpGet("insights")]
    public async Task<IActionResult> GetInsights()
    {
      var result = await service.GetInsights();

      return Ok(result);
    }
  }
}

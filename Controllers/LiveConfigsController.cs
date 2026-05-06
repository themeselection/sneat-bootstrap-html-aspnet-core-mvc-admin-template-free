using AspnetCoreMvcFull.Models;
using AspnetCoreMvcFull.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcFull.Controllers
{
  public class LiveConfigsController(
    LiveConfigRepository repo,
    LiveAdRepository liveAdRepo
  ) : Controller
  {
    public async Task<IActionResult> Index()
    {
      var data = await repo.GetAll();

      return View(data);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(LiveConfig model)
    {
      await repo.Create(model);

      return RedirectToAction(nameof(Index));
    }

    public IActionResult AddAd(long id)
    {
      var model = new LiveAd
      {
        LiveConfigId = id
      };

      return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddAd(
      LiveAd model)
    {
      await liveAdRepo.Create(model);

      return RedirectToAction(nameof(Index));
    }
  }
}

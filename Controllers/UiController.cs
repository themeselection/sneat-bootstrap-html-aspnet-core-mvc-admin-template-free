using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;

namespace AspnetCoreMvcFull.Controllers;

public class UiController : Controller
{
  public IActionResult Accordion() => View();
  public IActionResult Alerts() => View();
  public IActionResult Badges() => View();
  public IActionResult Buttons() => View();
  public IActionResult Carousel() => View();
  public IActionResult Collapse() => View();
  public IActionResult Dropdowns() => View();
  public IActionResult Footer() => View();
  public IActionResult ListGroups() => View();
  public IActionResult Modals() => View();
  public IActionResult Navbar() => View();
  public IActionResult Offcanvas() => View();
  public IActionResult PaginationBreadcrumbs() => View();
  public IActionResult Progress() => View();
  public IActionResult Spinners() => View();
  public IActionResult TabsPills() => View();
  public IActionResult Toasts() => View();
  public IActionResult TooltipsPopovers() => View();
  public IActionResult Typography() => View();
}

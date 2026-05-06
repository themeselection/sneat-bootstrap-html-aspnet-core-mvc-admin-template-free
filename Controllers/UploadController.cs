using AspnetCoreMvcFull.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcFull.Controllers
{
  public class UploadController(ExcelImportService excel) : Controller
  {
    public IActionResult Orders()
    {
      return View();
    }

    [HttpPost]
    [Obsolete("Obsolete")]
    public async Task<IActionResult> Orders(IFormFile? file)
    {
      if (file == null || file.Length == 0)
      {
        ViewBag.Error = "File không hợp lệ";

        return View();
      }

      await excel.ImportOrders(file);

      ViewBag.Success = "Import thành công";

      return View();
    }
  }
}

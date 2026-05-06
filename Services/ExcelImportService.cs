using AspnetCoreMvcFull.Repositories;
using OfficeOpenXml;

namespace AspnetCoreMvcFull.Services
{
  public class ExcelImportService(OrdersRepository repo)
  {
    [Obsolete("Obsolete")]
    public async Task ImportOrders(IFormFile file)
    {
      ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

      using var stream = new MemoryStream();

      await file.CopyToAsync(stream);

      using var package = new ExcelPackage(stream);

      var sheet = package.Workbook.Worksheets[0];
      var rowCount = sheet.Dimension.Rows;

      for (var row = 2; row <= rowCount; row++)
      {
        var pageId = sheet.Cells[row, 1].Text;
        var postId = sheet.Cells[row, 2].Text;
        var adId = sheet.Cells[row, 3].Text;
        var revenue = decimal.Parse(sheet.Cells[row, 5].Text);

        await repo.Insert(
          pageId,
          postId,
          adId,
          revenue
        );
      }
    }
  }
}

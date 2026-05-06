namespace AspnetCoreMvcFull.Models
{
  public class ReportLog
  {
    public long Id { get; set; }

    public long LiveConfigId { get; set; }

    public string Message { get; set; } = "";

    public bool IsSuccess { get; set; }

    public string? ErrorMessage { get; set; }

    public DateTime CreatedAt { get; set; }
  }
}

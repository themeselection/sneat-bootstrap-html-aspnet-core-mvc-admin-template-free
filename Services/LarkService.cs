namespace AspnetCoreMvcFull.Services
{
  public class LarkService(
    HttpClient httpClient,
    IConfiguration config)
  {
    public async Task Send(string message)
    {
      var webhook = config["Lark:Webhook"];

      var payload = new
      {
        msg_type = "text",
        content = new
        {
          text = message
        }
      };

      var response =
        await httpClient.PostAsJsonAsync(
          webhook,
          payload
        );

      response.EnsureSuccessStatusCode();
    }
  }
}

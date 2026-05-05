namespace AspnetCoreMvcFull.Services
{
  public class FacebookAdsService(
    IConfiguration config,
    HttpClient httpClient)
  {
    public async Task<string> GetInsights()
    {
      var token = config["FacebookAds:AccessToken"];
      var accountId = config["FacebookAds:AdAccountId"];

      var url =
        $"https://graph.facebook.com/v23.0/act_{accountId}/insights" +
        $"?fields=ad_id,spend,clicks,impressions" +
        $"&access_token={token}";

      var response = await httpClient.GetAsync(url);

      response.EnsureSuccessStatusCode();

      return await response.Content.ReadAsStringAsync();
    }
  }
}

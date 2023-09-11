public class BaseApiClient
{
    protected readonly HttpClient _httpClient;

    public BaseApiClient()
    {
        _httpClient = new HttpClient();
    }

    protected async Task<string> GetAsync(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}


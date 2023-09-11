using System.Text.Json;
using System.Text.Json.Serialization;
public class Weather : BaseApiClient
{
    private const string BaseUrl = "https://api.openweathermap.org/data/3/onecall/";

    private const string API_KEY = "0a7e7cf6d1ca358d5e25e0727a75d2d9";

    public async Task<String> GetWheaterOfCity(string? city)
    {
        var response = await GetAsync($"{BaseUrl}weather?q={city}&appid={API_KEY}");
        // Implement later cuz key not active
        return null;
    }
}

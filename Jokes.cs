using System.Text.Json;
using System.Text.Json.Serialization;
public class Jokes : BaseApiClient
{
    private const string BaseUrl = "https://official-joke-api.appspot.com/";

    public async Task<JokeResponse[]> GetRandomProgrammingJokeAsync()
    {
        var response = await GetAsync($"{BaseUrl}jokes/programming/random");
        var jsonResponse = JsonSerializer.Deserialize<JokeResponse[]>(response);
        return jsonResponse ?? new JokeResponse[0];
    }

    
}
public class JokeResponse
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("setup")]
    public string? Setup { get; set; }

    [JsonPropertyName("punchline")]
    public string? Punchline { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}

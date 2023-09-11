class Program
{
    static async Task Main(string[] args){
        var jokeApiClient = new Jokes();

        Console.WriteLine("\nFetching a programming joke...");
        try
        {
            JokeResponse[] joke = await jokeApiClient.GetRandomProgrammingJokeAsync();
            Console.WriteLine($"JokeSetup: {joke[0].Setup} \nJokePunchline: {joke[0].Punchline}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        var weatherClient = new Weather();
        Console.WriteLine("\nFetching weather");
        try
        {
            String weather = await weatherClient.GetWheaterOfCity();
            Console.WriteLine(weather);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }
}
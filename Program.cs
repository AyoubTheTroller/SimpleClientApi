// Jokes And Weather Apis
/*
JokesAndWeatherApis start = new JokesAndWeatherApis();
await start.JokesAndWeather();
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// Test asyncronous operation, the readfile will take a lot of time because the file is 200mb so meanwhile we call /readfile we can call /api too and still be able to use it.
app.MapGet("/api", async () => 
{
    using HttpClient client = new HttpClient();
    return await client.GetStringAsync("https://official-joke-api.appspot.com/jokes/programming/random");
});

app.MapGet("/readfile", async () => 
{
    return await File.ReadAllTextAsync("TestData/repeated_phrase_200mb.txt");
});

app.Run();
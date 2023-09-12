// Jokes And Weather Apis
/*
JokesAndWeatherApis start = new JokesAndWeatherApis();
await start.JokesAndWeather();
*/
using System.Net;

string api = "https://official-joke-api.appspot.com/jokes/programming/random";
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

ServicePointManager.DefaultConnectionLimit = 10; // Aumentato il limite delle connessioni a 10


// Test asyncronous operation, the readfile will take a lot of time because the file is 200mb so meanwhile we call /readfile we can call /api too and still be able to use it.
app.MapGet("/api", async () => 
{
    using HttpClient client = new HttpClient();
    return await client.GetStringAsync(api);
});

app.MapGet("/readfile", async () => 
{
    return await File.ReadAllTextAsync("TestData/repeated_phrase_200mb.txt");
});

app.MapGet("/readfile60mb", async () => 
{
    return await File.ReadAllTextAsync("TestData/repeated_phrase.txt");
});

// Testing CPU Bound operations
app.MapGet("/compute", async () => 
{
    var (result, threadId) = await Task.Run(() => SomeCpuIntensiveOperation());
    return Results.Ok(new { Result = result, ThreadId = threadId });
});


//Here Cpu will take 3/4 seconds 
(int result, int threadId) SomeCpuIntensiveOperation()
{
    double sum = 0;
    for (int i = 1; i <= 2000000000; i++)
    {
        sum += i;
    }
    return ((int)sum, Thread.CurrentThread.ManagedThreadId); // Here we retunr the thread id that was used from the threadpool
}



// Multiple services, here we call /compute to start an intensive CPU task that will take 2 sconds each.
// Then thanks to Task.WhenAll(task1, task2, task3) we can aggregate the result when all tasks have finished
app.MapGet("/aggregate", async () => 
{
    string api2 = "http://localhost:5255/compute";
    var task1 = FetchDataFromAPIAsync(api2);
    var task2 = FetchDataFromAPIAsync(api2);
    var task3 = FetchDataFromAPIAsync(api2);

    await Task.WhenAll(task1, task2, task3);

    return Results.Ok(new 
    {
        DataFromApi1 = task1.Result,
        DataFromApi2 = task2.Result,
        DataFromApi3 = task3.Result
    });
});

async Task<string> FetchDataFromAPIAsync(string url)
{
    using HttpClient client = new HttpClient();
    return await client.GetStringAsync(url);
}



app.Run();
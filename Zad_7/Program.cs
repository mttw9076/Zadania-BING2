using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string apiKey = "YOUR_API_KEY_HERE";
        string lat = "EXAMPLE_LATITUDE";
        string lon = "EXAMPLE_LONGITUDE";

        using var client = new HttpClient();
        string url = $"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&exclude=minutely,hourly&appid={apiKey}&units=metric&lang=pl";

        var response = await client.GetStringAsync(url);

        using var doc = JsonDocument.Parse(response);
        var root = doc.RootElement;

        double temp = root.GetProperty("main").GetProperty("temp").GetDouble();
        string description = root.GetProperty("weather")[0].GetProperty("description").GetString();

        Console.WriteLine($"🌡️ Temperatura: {temp}°C");
        Console.WriteLine($"☁️ Pogoda: {description}");
    }
}

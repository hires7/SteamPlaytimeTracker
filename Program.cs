using System.Net.Http;
using System.Net.Http.Json;
using SteamTracker.Models;


string apiKey = File.ReadAllText("apikey.txt").Trim();
string steamId = "76561198302195526";

string url = $"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={apiKey}&steamid={steamId}&format=json";

using HttpClient client = new HttpClient();

System.Console.WriteLine("Pripajanie na API");

try 
{
    // //GET poziadavka
    // HttpResponseMessage response = await client.GetAsync(url);

    // //overenie ci je status 200, ak nie hodi chybu
    // response.EnsureSuccessStatusCode();

    // //precita json odpovede
    // string responseBody = await client.GetStringAsync(url);

    // System.Console.WriteLine("Data uspesne stiahnute");

    // int charCount = Math.Min(responseBody.Length, 1000);
    // System.Console.WriteLine(responseBody.Substring(0, charCount));

    var data = await client.GetFromJsonAsync<SteamApiResponse>(url);

    if (data?.Response?.Games != null)
    {
        System.Console.WriteLine($"Naslo sa {data.Response.GameCount} hier.");
        System.Console.WriteLine("Napr:");

        foreach (var game in data.Response.Games)
        {
            int hodiny = game.PlaytimeForever / 60;
            Console.WriteLine($"- Hra (ID: {game.AppId}): Nahratých {game.PlaytimeForever} minút (cca {hodiny} hodín).");
        }
    }

}
catch (Exception e)
{
    System.Console.WriteLine($"Chyba: {e.Message}");
}
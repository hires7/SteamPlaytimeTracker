using System.Net.Http.Json;
using SteamTracker.Models;
using SteamTracker.Data;
using System.IO;
using System.Data;


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

        using (var db = new SteamDbContext())
        {
            db.Database.EnsureCreated();

            int savedGamesCount = 0;
            DateTime today = DateTime.UtcNow.Date;

            foreach (var game in data.Response.Games)
            {
                if (game.PlaytimeForever == 0) continue;

                var record = new DailyRecord
                {
                    Date = today,
                    AppId = game.AppId,
                    PlaytimeForever = game.PlaytimeForever
                };
                db.DailyRecords.Add(record);

                savedGamesCount++;
            }

            db.SaveChanges();

            System.Console.WriteLine($"Ulozenych {savedGamesCount} zaznamov pre ({today:yyyy-MM-dd}).");
        }
    }
    else
    {
        System.Console.WriteLine("Daco se pokazilo");
    }

}
catch (Exception e)
{
    System.Console.WriteLine($"Chyba: {e.Message}");
}
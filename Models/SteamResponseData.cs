namespace SteamTracker.Models;

using System.Text.Json.Serialization;

public class SteamResponseData
{
    [JsonPropertyName("game_count")]
    public int GameCount { get; set; }

    [JsonPropertyName("games")]
    public List<SteamGame>? Games { get; set; }
}
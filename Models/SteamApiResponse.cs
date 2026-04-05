namespace SteamTracker.Models;

using System.Text.Json.Serialization;

public class SteamApiResponse
{
    [JsonPropertyName("response")]
    public SteamResponseData? Response { get; set; }
}
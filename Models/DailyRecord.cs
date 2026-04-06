namespace SteamTracker.Models;

public class DailyRecord
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int AppId { get; set; }
    public int PlaytimeForever { get; set; }
}
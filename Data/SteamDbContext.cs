using Microsoft.EntityFrameworkCore;
using SteamTracker.Models;

namespace SteamTracker.Data;

public class SteamDbContext : DbContext
{
    //vytvori v db tabulku DailyRecords
    public DbSet<DailyRecord> DailyRecords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=steamdata.db");
    }
}
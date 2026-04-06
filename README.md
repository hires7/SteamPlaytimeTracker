# Steam Playtime Tracker

A backend service written in C# and .NET to log daily playtime for Steam games. 

Since the official Steam Web API only provides the total playtime for each game, this application runs to fetch the current data, filters out unplayed games, and stores the records in a local database. This builds the foundation for calculating daily playtime differences.

## Tech Stack
* C# / .NET 8
* Steam Web API
* SQLite & Entity Framework Core
* Blazor Web UI (Planned)

## Current Status
- [x] Connect to Steam API and fetch user games
- [x] Deserialize JSON responses into C# objects
- [x] Hide API key from source code
- [x] Implement SQLite database and EF Core migrations to store daily records
- [ ] Automate daily data fetching
- [ ] Calculate daily playtime differences

## How to Run
1. Create a file named `apikey.txt` in the root directory and paste your Steam Web API key inside.
2. Update the code with your public 64-bit Steam ID.
3. Apply the database migrations to create the local SQLite file:
    ```bash
    dotnet ef database update
    ```
4. Run the application:
    ```bash
    dotnet run
    ```
# Steam Playtime Tracker

A backend service written in C# and .NET to log daily playtime for Steam games. 



## Tech Stack
* C# / .NET 8
* Steam Web API
* SQLite & Entity Framework Core (Planned)
* Blazor Web UI (Planned)

## Current Status
- [x] Connect to Steam API and fetch user games
- [x] Deserialize JSON responses into C# objects
- [x] Hide API key from source code
- [ ] Implement SQLite database to store daily records
- [ ] Automate daily data fetching

## How to Run
1. Get a Steam Web API key and set it as an environment variable named `STEAM_API_KEY`.
2. Update the code with your public 64-bit Steam ID.
3. Run the application:

    ```bash
    dotnet build
    dotnet run
    ```
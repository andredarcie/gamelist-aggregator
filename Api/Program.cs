using community.Services;
using community.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = Environment.GetEnvironmentVariable("PGSQL_CONNECTION");

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString), ServiceLifetime.Transient);

builder.Services.AddSingleton<GameService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/api/games", (GameService gameService) =>
{
    var (games, _) = gameService.GetGames();
    return Results.Ok(games);
});

app.Run();

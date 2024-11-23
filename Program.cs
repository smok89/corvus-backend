using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using corvus_backend;
using corvus_backend.Services;
using DotNetEnv;
using corvus_backend.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file
Env.Load();

// Register the CorvusDbContext with the dependency injection container
builder.Services.AddDbContext<CorvusDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the CoinGeckoApiService with the dependency injection container
builder.Services.AddSingleton<CoinGeckoApiService>();

// Register HttpClient
builder.Services.AddHttpClient();

// Add response caching services
builder.Services.AddOutputCache();

// Add System.Text.Json formatter
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseOutputCache();

app.MapGet("/coins/list", async (CoinGeckoApiService coinGeckoApiService, CorvusDbContext dbContext) =>
{
    var coinIds = await coinGeckoApiService.GetCoinIdsAsync();

    foreach (var coinId in coinIds)
    {
        if (!await dbContext.Coin.AnyAsync(c => c.StrId == coinId))
        {
            dbContext.Coin.Add(new Coin { StrId = coinId });
        }
    }

    await dbContext.SaveChangesAsync();

    return Results.Ok(coinIds);
})
.CacheOutput(policy => policy.Expire(TimeSpan.FromMinutes(10)))
.WithName("GetCoinIds")
.WithOpenApi();

app.MapGet("/coin-data/{coinId}", async (string coinId, CoinGeckoApiService coinGeckoApiService, CorvusDbContext dbContext) =>
{
    var coinData = await coinGeckoApiService.GetCoinDataAsync(coinId);
    if (coinData == null)
    {
        return Results.NotFound($"No data found for coin ID: {coinId}");
    }

    // Log the coin data being returned
    Console.WriteLine("Returning coin data for ID: " + coinId);

    // Serialize the coin data using System.Text.Json
    var serializedCoinData = JsonSerializer.Serialize(coinData, new JsonSerializerOptions { WriteIndented = true });

    // Return the serialized data as a JSON response
    return Results.Json(coinData);
})
.WithName("GetCoinData")
.WithOpenApi();

app.Run();
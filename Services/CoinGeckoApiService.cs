using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

namespace corvus_backend.Services
{
    public class CoinGeckoApiService
    {
        private readonly string? _apiKey;
        private readonly HttpClient _httpClient;

        public CoinGeckoApiService(HttpClient httpClient)
        {
            _apiKey = Environment.GetEnvironmentVariable("COINGECKO_API_KEY");
            _httpClient = httpClient;
        }

        public async Task<List<string>> GetCoinIdsAsync()
        {
            var url = "https://api.coingecko.com/api/v3/coins/list";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var coins = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(content);
                var coinIds = new List<string>();

                if (coins != null)
                {
                    foreach (var coin in coins)
                    {
                        if (coin.TryGetValue("id", out var coinId) && coinId is JsonElement idElement && idElement.ValueKind == JsonValueKind.String)
                        {
                            var id = idElement.GetString();
                            if (id != null)
                            {
                                coinIds.Add(id);
                            }
                        }
                    }
                }

                return coinIds;
            }
            else
            {
                Console.WriteLine($"Failed to fetch data: {response.StatusCode}");
                return new List<string>();
            }
        }

        public async Task<Dictionary<string, object>?> GetCoinDataAsync(string coinId)
        {
            var url = $"https://api.coingecko.com/api/v3/coins/{coinId}?localization=false&tickers=false&market_data=true&community_data=false&developer_data=false&sparkline=false";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var coinData = JsonSerializer.Deserialize<Dictionary<string, object>>(content);
                return coinData;
            }
            else
            {
                Console.WriteLine($"Failed to fetch data: {response.StatusCode}");
                return null;
            }
        }
    }
}
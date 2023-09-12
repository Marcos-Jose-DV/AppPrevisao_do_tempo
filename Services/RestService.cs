using AppPrevisaoDoTempo.Models;
using System.Text.Json;

namespace AppPrevisaoDoTempo.Services;

public class RestService : IRestService
{
    HttpClient _client;
    JsonSerializerOptions _jsonOptions;

    public RestService()
    {
        _client = new HttpClient();
        _jsonOptions = new JsonSerializerOptions() 
        {
            PropertyNameCaseInsensitive = true,
        };
    }

    public async Task<WeatherData> GetWeatherData(string query)
    {
        WeatherData data = null;
        try
        {
            var response = await _client.GetAsync(query);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                data = await JsonSerializer.DeserializeAsync<WeatherData>(responseStream, _jsonOptions);
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }

        return data;
    }
}

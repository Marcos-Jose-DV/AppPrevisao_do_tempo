
using AppPrevisaoDoTempo.Models;

namespace AppPrevisaoDoTempo.Services;

public interface IRestService
{
    Task<WeatherData> GetWeatherData(string query);
}

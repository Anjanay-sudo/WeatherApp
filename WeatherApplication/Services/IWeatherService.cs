using WeatherApp.Models;

namespace WeatherApplication.Services
{
    public interface IWeatherService
    {
        List<WeatherForecast> GetWeatherByCity(string city);
        Task UpdateWeatherAsync(WeatherForecast weather);
    }
}

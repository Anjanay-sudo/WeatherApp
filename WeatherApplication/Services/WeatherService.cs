using Microsoft.EntityFrameworkCore;
using WeatherApp.Data;
using WeatherApp.Models;

namespace WeatherApplication.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherDbContext _context;

        public WeatherService(WeatherDbContext context)
        {
            _context = context;
        }

        public List<WeatherForecast> GetWeatherByCity(string city)
        {
            var cityId = _context.City.Where(x => x.Name.Equals(city)).FirstOrDefault()?.Id;

            var weather = _context.WeatherForecast
                .Where(w => w.CityId.Equals(cityId)).ToList();

            if (weather != null && weather.Any())
            {
                _context.SearchLog.Add(new SearchLog { Id = Random.Shared.Next(), City = city, SearchDate = DateTime.Now });
                _context.SaveChanges();
            }

            return weather;
        }

        public async Task UpdateWeatherAsync(WeatherForecast weather)
        {
            //_context.Weathers.Update(weather);
            await _context.SaveChangesAsync();
        }


    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;
using WeatherApplication.Services;

namespace WeatherApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeatherByCity(string city)
        {
            var weather = _weatherService.GetWeatherByCity(city);
            if (weather == null)
            {
                return NotFound();
            }

            return Ok(weather);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateWeather([FromBody] WeatherForecast weather)
        {
            await _weatherService.UpdateWeatherAsync(weather);
            return NoContent();
        }
    }
}

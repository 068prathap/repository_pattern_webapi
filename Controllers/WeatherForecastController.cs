using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWebAPI.Services.WeatherForecastService;

namespace RepositoryPatternWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _WeatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService WeatherForecastService)
        {
            _logger = logger;
            _WeatherForecastService = WeatherForecastService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _WeatherForecastService.Get();
        }
    }
}
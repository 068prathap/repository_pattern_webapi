namespace RepositoryPatternWebAPI.Services.WeatherForecastService
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}
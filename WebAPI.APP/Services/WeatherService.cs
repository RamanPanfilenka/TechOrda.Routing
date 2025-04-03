namespace WebAPI.APP.Services
{
    public class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private IInnerService _innerService;

        public WeatherService(IInnerService innerService, IEnumerable<IInnerService> innerServices) 
        {
            _innerService = innerService;
        }

        public IEnumerable<WeatherForecast> GetWeatherForecasts() 
        {
            var number = _innerService.DoSomething();
            return Enumerable.Range(1, number).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
        }
    }
}

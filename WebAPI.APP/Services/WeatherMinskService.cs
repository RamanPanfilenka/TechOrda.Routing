namespace WebAPI.APP.Services
{
    public class WeatherMinskService : IWeatherService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private IInnerService _innerService;

        public WeatherMinskService(IInnerService innerService, IEnumerable<IInnerService> innerServices) 
        {
            _innerService = innerService;
        }

        public IEnumerable<WeatherForecast> GetWeatherForecasts() 
        {
            var number = _innerService.DoSomething();
            return Enumerable.Range(1, number).Select(index => new WeatherForecast
            {
                Location = "Minsk",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
        }
    }
}

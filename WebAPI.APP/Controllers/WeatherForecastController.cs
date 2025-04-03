using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WebAPI.APP.Services;
using WebAPI.APP.Setup;

namespace WebAPI.APP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IInnerService _innerService;
        private readonly IServiceProvider _serviceProvider;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IInnerService innerService,
            IServiceProvider serviceProvider, IOptions<QuizOptions> options)
        {
            _logger = logger;
            _innerService = innerService;
            _serviceProvider = serviceProvider;
        }

        [HttpGet("GetWeatherForecast", Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get([FromKeyedServices("common")] IWeatherService weatherService)
        {
            return weatherService.GetWeatherForecasts();
        }

        [EndpointDescription("Get forecast for Minsk")]
        [HttpGet("GetMinskWeatherForecasts/{key}", Name = "GetMinskWeatherForecasts")]
        public IEnumerable<WeatherForecast> GetMinskWeatherForecasts(string key)
        {
            var service = _serviceProvider.GetKeyedService<IWeatherService>(key);
            return service.GetWeatherForecasts();
        }
    }
}

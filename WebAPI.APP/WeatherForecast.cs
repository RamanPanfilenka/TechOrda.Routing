namespace WebAPI.APP
{
    public class WeatherForecast
    {
        public string Location { get; set; } = "Common";
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}

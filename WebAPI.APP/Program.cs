using Microsoft.Extensions.DependencyInjection;
using WebAPI.APP.Constrait;
using WebAPI.APP.Services;
using WebAPI.APP.Setup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => {
    options.ConstraintMap.Add("temperature", typeof(TemperatureRouteConstraint));
});
builder.Services.AddSingleton<IInnerService, InnerService>((service) => new InnerService(1));
builder.Services.AddKeyedTransient<IWeatherService, WeatherService>("common");
builder.Services.AddKeyedTransient<IWeatherService, WeatherMinskService>("minsk");

builder.Services.Configure<QuizOptions>(builder.Configuration.GetSection(QuizOptions.SectionName));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Use((context, next) =>
{
    var endpoint = context.GetEndpoint();
    Console.WriteLine($"Endpoint name: {endpoint?.DisplayName ?? "No info"}");

    return next(context);
});
app.UseRouting();
app.Use((context, next) =>
{
    var endpoint = context.GetEndpoint();
    Console.WriteLine($"Endpoint name: {endpoint?.DisplayName ?? "No info"}");
    if (endpoint != null) 
    {
        var endpointDescriptionAttribute = endpoint.Metadata.OfType<EndpointDescriptionAttribute>().FirstOrDefault();
        Console.WriteLine($"Description: {endpointDescriptionAttribute?.Description}");
    }

    return next(context);
});
app.UseAuthorization();

app.MapControllers();
app.MapGet("SayHello/{temperature:temperature}", 
    (int temperature) => $"Hello, today temperature is {temperature}")
    .WithDescription("Say hello with today temoperature")
    .WithSummary("");

app.Run();

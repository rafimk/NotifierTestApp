using Microsoft.AspNetCore.Mvc;
using NotifierTestApp.Controllers.Contract;
using NotifierTestApp.EmailService;

namespace NotifierTestApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IEmailService _emailService;

    public WeatherForecastController(IEmailService emailService, ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        _emailService = emailService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost]
    public async Task<ActionResult> SendEmail([FromBody] EmailContract contract)
    {
        await _emailService.Send(contract.To, contract.Subject, contract.Html);
        return Ok();
    }
}

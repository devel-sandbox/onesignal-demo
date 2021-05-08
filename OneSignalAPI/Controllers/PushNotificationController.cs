using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneSignal;
using OneSignal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneSignalAPI.Controllers
{
    [Route("notifications")]
    [ApiController]
    public class PushNotificationController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IPushNotificationService _pushService;
        public PushNotificationController(IPushNotificationService pushService)
        {
            _pushService = pushService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public async Task<IActionResult> PushNotification(NotificationRequestDTO request)
        {
            var result = await _pushService.Send(request);
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MicroserviceRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HealthCheckController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetStatus()
        {
            var client = _httpClientFactory.CreateClient();

            var services = new[]
            {
                new { Name = "MicroserviceRestApi", Url = "http://microservicerestapi/health" },
                new { Name = "MicroservicePdfGenerator", Url = "http://microservicepdfgenerator/health" },
                new { Name = "MicroserviceWeb", Url = "http://microserviceweb/health" }
            };

            var results = new List<object>();

            foreach (var service in services)
            {
                try
                {
                    var response = await client.GetAsync(service.Url);
                    var status = response.IsSuccessStatusCode ? "Healthy" : "Unhealthy";

                    results.Add(new { service.Name, Status = status });
                }
                catch
                {
                    results.Add(new { service.Name, Status = "Unreachable" });
                }
            }

            return Ok(new
            {
                Status = "OK",
                Services = results
            });
        }
    }
}

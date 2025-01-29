using Microsoft.AspNetCore.Mvc;

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
                results.Add(new { service.Name, Status = status, ResponseStatusCode = response.StatusCode });
            }
            catch (Exception ex)
            {
                results.Add(new { service.Name, Status = "Unreachable", ErrorMessage = ex.Message });
            }
        }

        return Ok(new
        {
            Status = "OK",
            Services = results
        });
    }
}

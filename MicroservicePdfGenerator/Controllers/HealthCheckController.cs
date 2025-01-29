using Microsoft.AspNetCore.Mvc;

namespace MicroservicePdfGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet("health")]
        public IActionResult GetHealthStatus()
        {
            return Ok("Healthy");
        }
    }
}

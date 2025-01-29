using MicroserviceRestApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MicroserviceRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class TrainersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TrainersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Pupils/{trainerId}/trainer/all-pupils
        [HttpGet("{trainerId}/all-pupils")]
        public async Task<IActionResult> GetPupilsByTrainerId(int trainerId)
        {
            var pupils = await _context.Pupils
                .Where(p => p.TrainerId == trainerId)
                .ToListAsync();

            // Jeśli brak wyników, zwróć 404
            if (!pupils.Any())
            {
                return NotFound($"No pupils found for trainer with ID {trainerId}.");
            }

            // Zwrócenie uczniów
            return Ok(pupils);
        }
    }
}
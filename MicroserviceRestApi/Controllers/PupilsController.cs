using MicroserviceRestApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MicroserviceRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class PupilsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PupilsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Pupils/{trainerId}/trainer/all-pupils
        [HttpGet("{pupilId}/exercises")]
        public async Task<IActionResult> GetPupilExercisesByPupilId(int pupilId)
        {
            var pupils = await _context.Exercises
                .Where(p => p.Id == pupilId)
                .ToListAsync();
            
               

            // Jeśli brak wyników, zwróć 404
            if (!pupils.Any())
            {
                return NotFound($"No pupils found for trainer with ID {pupilId}.");
            }

            // Zwrócenie uczniów
            return Ok(pupils); 
        }
    }
}
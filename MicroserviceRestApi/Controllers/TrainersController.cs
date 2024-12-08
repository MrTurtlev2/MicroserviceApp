
using DataModels;
using DataModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MicroserviceRestApi.Controllers
{
    [ApiController]
    [Route("/trainers")]
    //[Route("/api")]
    public class TrainersController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public TrainersController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: /Trainers/5 
        [HttpGet("{id}")]
        public async Task<ActionResult<Trainers>> GetTrainer(int id)
        {
            // Pobierz trenera o podanym ID  
            var trainer = await _context.Trainers
                .Include(t => t.PupilsList) // Dołącz uczniów przypisanych do trenera
                .FirstOrDefaultAsync(t => t.Id == id);

            // Jeśli nie znaleziono trenera, zwróć status 404
            if (trainer == null)
            {
                return NotFound();
            }

            // Zwróć dane trenera
            return Ok(trainer);
        }


    }
}

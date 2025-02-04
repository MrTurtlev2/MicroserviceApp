using MicroserviceRestApi.Data;
using MicroserviceRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceRestApi.Controllers
{
    [ApiController]
    [Route("api/{pupilId}/exercises")]
    public class ExercisesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExercisesController(AppDbContext context)
        {
            _context = context;
        }

        // Pobranie wszystkich ćwiczeń danego ucznia
        [HttpGet("exercises-by-pupil")]
        public async Task<IActionResult> GetExercises(int pupilId)
        {
            var exercises = await _context.Exercises
                .Where(e => e.PupilId == pupilId)
                .ToListAsync();

            if (exercises == null)
            {
                return NotFound($"Brak ćwiczeń dla ucznia o ID {pupilId}.");
            }

            return Ok(exercises);
        }

        // Dodanie nowego ćwiczenia dla danego ucznia
        [HttpPost("add")]
        public async Task<IActionResult> AddExercise(int pupilId, [FromBody] List<Exercises> exercises)
        {
            if (exercises == null || exercises.Count == 0)
            {
                return BadRequest("Nieprawidłowe dane ćwiczenia.");
            }

            foreach (var exercise in exercises)
            {
                exercise.PupilId = pupilId;
                _context.Exercises.Add(exercise);
            }

            await _context.SaveChangesAsync();

            return Ok(new { message = "Ćwiczenia zostały zapisane!" });
        }

        // Edycja istniejącego ćwiczenia
        [HttpPut("{exerciseId}/edit")]
        public async Task<IActionResult> UpdateExercise(int pupilId, int exerciseId, [FromBody] Exercises updatedExercise)
        {
            var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseId && e.PupilId == pupilId);

            if (exercise == null)
            {
                return NotFound($"Nie znaleziono ćwiczenia o ID {exerciseId} dla ucznia o ID {pupilId}.");
            }

            // Aktualizacja pól
            exercise.Label = updatedExercise.Label;
            exercise.Weight = updatedExercise.Weight;
            exercise.Reps = updatedExercise.Reps;
            exercise.Comment = updatedExercise.Comment;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Ćwiczenie zaktualizowane!" });
        }

        // Usunięcie ćwiczenia
        [HttpDelete("{exerciseId}/delete")]
        public async Task<IActionResult> DeleteExercise(int pupilId, int exerciseId)
        {
            var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseId && e.PupilId == pupilId);

            if (exercise == null)
            {
                return NotFound($"Nie znaleziono ćwiczenia o ID {exerciseId} dla ucznia o ID {pupilId}.");
            }

            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Ćwiczenie usunięte!" });
        }
    }
}

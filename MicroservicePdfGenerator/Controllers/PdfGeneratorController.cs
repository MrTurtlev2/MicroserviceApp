using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using Microsoft.AspNetCore.Mvc;
using MicroservicePdfGenerator.Data;
using System.Linq;
using System.IO;

namespace MicroservicePdfGenerator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PdfController(AppDbContext context)
        {
            _context = context;
        }



        [HttpGet("all-trainers")]
        public IActionResult GeneratePdf()
        {
            var trainers = _context.Trainers.ToList();

            string message = "Lista Trenerów";

            using (var memoryStream = new MemoryStream())
            {
                var document = new PdfDocument();
                var page = document.AddPage();
                var gfx = XGraphics.FromPdfPage(page);

                var font = new XFont("Roboto Condensed", 12);

                gfx.DrawString(message, font, XBrushes.Black, new XPoint(40, 40));

                double yPoint = 80;
                var headerFont = new XFont("Roboto Condensed", 12, XFontStyle.Bold);
                var tableFont = new XFont("Roboto Condensed", 10);

                gfx.DrawString("ID", headerFont, XBrushes.Black, new XPoint(40, yPoint));
                gfx.DrawString("Name", headerFont, XBrushes.Black, new XPoint(100, yPoint));
                gfx.DrawString("Email", headerFont, XBrushes.Black, new XPoint(250, yPoint));
                gfx.DrawString("Password", headerFont, XBrushes.Black, new XPoint(400, yPoint));
                yPoint += 20;

                foreach (var trainer in trainers)
                {
                    gfx.DrawString(trainer.Id.ToString(), tableFont, XBrushes.Black, new XPoint(40, yPoint));
                    gfx.DrawString(trainer.Name, tableFont, XBrushes.Black, new XPoint(100, yPoint));
                    gfx.DrawString(trainer.Email, tableFont, XBrushes.Black, new XPoint(250, yPoint));
                    gfx.DrawString(trainer.Password, tableFont, XBrushes.Black, new XPoint(400, yPoint));
                    yPoint += 20;
                }

                document.Save(memoryStream, false);

                return File(memoryStream.ToArray(), "application/pdf", "trainers-table.pdf");
            }
        }

        [HttpGet("pupils-for-trainer/{trainerId}")]
        public IActionResult GeneratePupilsPdf(int trainerId)
        {
            var trainer = _context.Trainers.FirstOrDefault(t => t.Id == trainerId);
            if (trainer == null)
            {
                return NotFound($"Trainer with ID {trainerId} not found.");
            }

            var pupils = _context.Pupils.Where(p => p.TrainerId == trainerId).ToList();

            string message = $"Lista uczniów dla trenera {trainer.Name}";

            using (var memoryStream = new MemoryStream())
            {
                var document = new PdfDocument();
                var page = document.AddPage();
                var gfx = XGraphics.FromPdfPage(page);

                var font = new XFont("Roboto Condensed", 12);

                gfx.DrawString(message, font, XBrushes.Black, new XPoint(40, 40));

                double yPoint = 80;
                var headerFont = new XFont("Roboto Condensed", 12, XFontStyle.Bold);
                var tableFont = new XFont("Roboto Condensed", 10);

                gfx.DrawString("ID", headerFont, XBrushes.Black, new XPoint(40, yPoint));
                gfx.DrawString("Name", headerFont, XBrushes.Black, new XPoint(100, yPoint));
                gfx.DrawString("Email", headerFont, XBrushes.Black, new XPoint(250, yPoint));
                yPoint += 20;

                foreach (var pupil in pupils)
                {
                    gfx.DrawString(pupil.Id.ToString(), tableFont, XBrushes.Black, new XPoint(40, yPoint));
                    gfx.DrawString(pupil.Name, tableFont, XBrushes.Black, new XPoint(100, yPoint));
                    gfx.DrawString(pupil.Email, tableFont, XBrushes.Black, new XPoint(250, yPoint));
                    yPoint += 20;
                }

                document.Save(memoryStream, false);

                return File(memoryStream.ToArray(), "application/pdf", $"{trainer.Name}_pupils.pdf");
            }
        }

        [HttpGet("all-pupils")]
        public IActionResult GenerateAndSaveAllPupilsPdf()
        {
            var pupils = _context.Pupils.ToList();

            if (!pupils.Any())
            {
                return NotFound("Brak zapisanych uczniów.");
            }

            string message = "Lista wszystkich uczniów";

            using (var memoryStream = new MemoryStream())
            {
                var document = new PdfDocument();
                var page = document.AddPage();
                var gfx = XGraphics.FromPdfPage(page);

                var font = new XFont("Roboto Condensed", 12);
                var headerFont = new XFont("Roboto Condensed", 12, XFontStyle.Bold);
                var tableFont = new XFont("Roboto Condensed", 10);

                gfx.DrawString(message, font, XBrushes.Black, new XPoint(40, 40));

                double yPoint = 80;

                gfx.DrawString("ID", headerFont, XBrushes.Black, new XPoint(40, yPoint));
                gfx.DrawString("Name", headerFont, XBrushes.Black, new XPoint(100, yPoint));
                gfx.DrawString("Email", headerFont, XBrushes.Black, new XPoint(250, yPoint));
              
                yPoint += 20;

                foreach (var pupil in pupils)
                {
                    gfx.DrawString(pupil.Id.ToString(), tableFont, XBrushes.Black, new XPoint(40, yPoint));
                    gfx.DrawString(pupil.Name, tableFont, XBrushes.Black, new XPoint(100, yPoint));
                    gfx.DrawString(pupil.Email, tableFont, XBrushes.Black, new XPoint(250, yPoint));
                    gfx.DrawString(pupil.TrainerId.ToString(), tableFont, XBrushes.Black, new XPoint(400, yPoint));
                    yPoint += 20;
                }

                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                string fileName = $"pupils-raport-{timestamp}.pdf";


                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Raports");
                Directory.CreateDirectory(folderPath); 
                string filePath = Path.Combine(folderPath, fileName);

                document.Save(filePath);

                return Ok($"Plik PDF zapisany: {filePath}");
            }
        }

        [HttpGet("reports")]
        public IActionResult GetReports()
        {
            string reportsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Raports");

            if (!Directory.Exists(reportsDirectory))
            {
                return NotFound("Folder z raportami nie istnieje.");
            }

            var baseUrl = $"{Request.Scheme}://{Request.Host}/Raports/";

            var files = Directory.GetFiles(reportsDirectory, "*.pdf")
                                 .Select(file => new
                                 {
                                     FileName = Path.GetFileName(file),
                                     Url = $"{baseUrl}{Path.GetFileName(file)}"
                                 })
                                 .ToList();

            return Ok(files);
        }




    }
}

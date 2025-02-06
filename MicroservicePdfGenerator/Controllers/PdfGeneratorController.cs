using Microsoft.AspNetCore.Mvc;
using MicroservicePdfGenerator.Data;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
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

        [HttpGet("generate-pdf")]
        public IActionResult GeneratePdf()
        {
            // Tekst do dodania do PDF
            string message = "Ćwiczenia zostały zapisane!";

            // Tworzenie strumienia do zapisu PDF
            using (var memoryStream = new MemoryStream())
            {
                // Tworzymy dokument PDF
                using (var writer = new PdfWriter(memoryStream))
                using (var pdf = new PdfDocument(writer))
                {
                    var document = new Document(pdf);

                    // Dodajemy tekst do dokumentu
                    document.Add(new Paragraph(message));

                    // Zapisujemy dokument PDF do strumienia
                    document.Close();
                }

                // Zwracamy PDF jako plik
                return File(memoryStream.ToArray(), "application/pdf", "generated-file.pdf");
            }
        }
    }
}

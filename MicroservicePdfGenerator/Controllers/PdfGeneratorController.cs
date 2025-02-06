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
    }
}

using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace MicroservicePdfGenerator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfController : ControllerBase
    {
        [HttpGet("generate-pdf")]
        public IActionResult GeneratePdf()
        {
            string message = "Ćwiczenia zostały zapisane!";
            string fontPath = "/usr/share/fonts/truetype/roboto/Roboto_Condensed-Light.ttf";

            using (var memoryStream = new MemoryStream())
            {
                var document = new PdfDocument();
                var page = document.AddPage();
                var gfx = XGraphics.FromPdfPage(page);

                var font = new XFont(fontPath, 12, XFontStyle.Regular);

                gfx.DrawString(message, font, XBrushes.Black, new XPoint(40, 40));

                document.Save(memoryStream, false);

                return File(memoryStream.ToArray(), "application/pdf", "generated-file.pdf");
            }
        }
    }
}

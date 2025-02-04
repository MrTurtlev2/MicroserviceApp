using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroserviceWeb.Pages
{
    public class ExersiceModel : PageModel
    {
        private readonly ILogger<ExersiceModel> _logger;
        public int PupilId { get; set; }
        public ExersiceModel(ILogger<ExersiceModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int id)
        {
            PupilId = id;
        }
    }
}

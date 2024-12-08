using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroserviceWeb.Pages
{  
    public class Dashboard : PageModel
    {
        private readonly ILogger<Dashboard> _logger;

        public Dashboard(ILogger<Dashboard> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}

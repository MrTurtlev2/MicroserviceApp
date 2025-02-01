using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroserviceWeb.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly ILogger<DashboardModel> _logger;
        private readonly HttpClient _httpClient;

        public List<Pupil> Pupils { get; set; } = new();

        public DashboardModel(ILogger<DashboardModel> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        // Pobieranie danych z API na ładowaniu strony
        public async Task OnGetAsync()
        {
            await LoadPupilsFromApi();
        }

        // Metoda do pobrania uczniów z zewnętrznego API
        private async Task LoadPupilsFromApi()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://localhost:5000/api/trainers/1/all-pupils");

                var apiPupils = JsonSerializer.Deserialize<List<Pupil>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Pupil>();

                // Dodanie domyślnego zdjęcia do każdego ucznia
                foreach (var pupil in apiPupils)
                {
                    pupil.ImageUrl = "~/images/default.jpg"; // Możesz dostosować ścieżkę
                    pupil.Info = $"Email: {pupil.Email}";
                }

                Pupils = apiPupils;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Błąd pobierania danych z API: {ex.Message}");
            }
        }

        // Pupil model
        public class Pupil
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public int TrainerId { get; set; }
            public string ImageUrl { get; set; }
            public string Info { get; set; }
        }
    }
}

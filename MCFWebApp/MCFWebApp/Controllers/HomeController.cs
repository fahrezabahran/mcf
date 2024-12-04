using MCFWebApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace MCFWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiBaseUrl = "https://localhost:7102/api";
        }

        public async Task<IActionResult> Index()
        {
            var httpResponseMessage = await _httpClient.GetAsync($"{_apiBaseUrl}/Storage");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var userId = HttpContext.Session.GetString("UserId");
                var responseData = await httpResponseMessage.Content.ReadAsStringAsync();
                var locations = JsonConvert.DeserializeObject<List<LocationDto>>(responseData);


                if (locations != null)
                {
                    ViewBag.LokasiPenyimpanan = locations.Select(l => new SelectListItem
                    {
                        Value = l.LocationId,
                        Text = l.LocationName
                    }).ToList();
                    ViewBag.LokasiPenyimpanan.Insert(0, new SelectListItem { Value = "", Text = "- Select -" });
                }

                ViewBag.UserId = userId;
            }
            else
            {
                ViewBag.LokasiPenyimpanan = new List<SelectListItem>
                {
                    new SelectListItem { Value = "", Text = "- Select -" }
                };
            }
            return View();
        }

    }
}

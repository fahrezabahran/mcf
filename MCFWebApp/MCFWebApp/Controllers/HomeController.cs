using MCFWebApp.Data;
using MCFWebApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net;

namespace MCFWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly McfDbContext _context;
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        public HomeController(McfDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
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

                ViewBag.LokasiPenyimpanan = locations.Select(l => new SelectListItem
                {
                    Value = l.LocationId,
                    Text = l.LocationName
                }).ToList();


                ViewBag.LokasiPenyimpanan.Insert(0, new SelectListItem { Value = "", Text = "- Select -" });
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BpkbCreate model)
        {
            try
            {
                var httpResponseMessage = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/Bpkb", model);

                if (!httpResponseMessage.StatusCode.Equals(HttpStatusCode.OK))
                    return Json(new { success = false, message = "Create Failed" });

                var response = await httpResponseMessage.Content.ReadAsStringAsync();

                return Json(new { success = true, message = "Create Success" });
            }
            catch
            {
                return Json(new { success = false, message = "Create Failed" });
            }
        }
    }
}

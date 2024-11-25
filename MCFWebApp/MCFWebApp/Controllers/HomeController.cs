using MCFWebApp.Data;
using MCFWebApp.DTOs;
using MCFWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

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
            _apiBaseUrl = "https://localhost:7102";
        }

        public IActionResult Index()
        {
            var lokasiPenyimpanan = _context.MsStorageLocations
                .Select(s => new SelectListItem
                {
                    Text = s.LocationName,
                    Value = s.LocationId
                })
                .ToList();

            ViewBag.LokasiPenyimpanan = lokasiPenyimpanan;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BpkbCreate model)
        {
            try
            {
                var httpResponseMessage = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/Bpkb", model);

                if (!httpResponseMessage.IsSuccessStatusCode)
                    return Json(new { success = false, message = "Create Failed" });

                var response = await httpResponseMessage.Content.ReadAsStringAsync();

                var successResponse = JsonConvert.DeserializeObject<SuccessResponse<Bpkb>>(response);

                if (successResponse == null)
                    return Json(new { success = false, message = "Create Failed" });

                return Json(new { success = true, message = "Create Success" });
            }
            catch
            {
                return Json(new { success = false, message = "Create Failed" });
            }
        }
    }
}

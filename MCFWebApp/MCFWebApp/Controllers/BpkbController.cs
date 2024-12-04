using MCFWebApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net;

namespace MCFWebApp.Controllers
{
    public class BpkbController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        public BpkbController(IHttpClientFactory httpClientFactory)
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

        public IActionResult ManageBpkb()
        {
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

                return Json(new { success = true, message = "Create Success" });
            }
            catch
            {
                return Json(new { success = false, message = "Create Failed" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string agreementNumber, BpkbUpdate model)
        {
            try
            {
                var httpResponseMessage = await _httpClient.PutAsJsonAsync($"{_apiBaseUrl}/Bpkb/{agreementNumber}", model);

                if (!httpResponseMessage.StatusCode.Equals(HttpStatusCode.OK))
                    return Json(new { success = false, message = "Update Failed" });

                return Json(new { success = true, message = "Update Success" });
            }
            catch
            {
                return Json(new { success = false, message = "Update Failed" });
            }
        }

        [HttpDelete("Bpkb/Delete/{agreementNumber}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string agreementNumber)
        {
            try
            {
                var httpResponseMessage = await _httpClient.DeleteAsync($"{_apiBaseUrl}/Bpkb/{agreementNumber}");

                if (!httpResponseMessage.StatusCode.Equals(HttpStatusCode.OK))
                    return Json(new { success = false, message = "Delete Failed" });

                return Json(new { success = true, message = "Delete Success" });
            }
            catch
            {
                return Json(new { success = false, message = "Delete Failed" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var httpResponseMessage = await _httpClient.GetAsync($"{_apiBaseUrl}/Bpkb");

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return Json(new { success = false, message = "Failed to fetch data" });
                }

                var responseData = await httpResponseMessage.Content.ReadAsStringAsync();
                var bpkbList = JsonConvert.DeserializeObject<List<BpkbDto>>(responseData);

                return Json(bpkbList); // Kembalikan data dalam format JSON
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
        }

        [HttpGet("Bpkb/Get/{agreementNumber}")]
        public async Task<IActionResult> Get(string agreementNumber)
        {
            try
            {
                var httpResponseMessage = await _httpClient.GetAsync($"{_apiBaseUrl}/Bpkb/{agreementNumber}");

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return Json(new { success = false, message = "Failed to fetch data" });
                }

                var responseData = await httpResponseMessage.Content.ReadAsStringAsync();
                var bpkbData = JsonConvert.DeserializeObject<BpkbDto>(responseData);

                // Pastikan format yang dikembalikan sesuai dengan yang diharapkan di front-end
                return Json(bpkbData); // Kembalikan data dalam format JSON
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
        }


    }
}

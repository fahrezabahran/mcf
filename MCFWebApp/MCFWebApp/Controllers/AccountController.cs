using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using MCFWebApp.DTOs;
using MCFWebApp.Models;
using Newtonsoft.Json;

namespace MCFWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiBaseUrl = "https://localhost:7102";
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            try
            {
                var httpResponseMessage = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/LoginUser", userDto);

                if (!httpResponseMessage.IsSuccessStatusCode)
                    return Json(new { success = false, message = "Login Failed" });

                var response = await httpResponseMessage.Content.ReadAsStringAsync();

                var successResponse = JsonConvert.DeserializeObject<SuccessResponse<User>>(response);

                if (successResponse == null)
                    return Json(new { success = false, message = "Login Failed" });

                return Json(new { success = true, redirectUrl = "/Home/Index" });
            }
            catch
            {
                return Json(new { success = false, message = "Login Failed" });
            }
        }
    }
}

using Carbook.DTO.BrandDtos;
using Carbook.DTO.RegisterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult CreateAppUser()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateAppUser(CreateRegisterDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var resultMessage = await client.PostAsync("https://localhost:7112/api/Register", stringContent);
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Login");
            }

            return View(dto);
        }
    }
}

using Carbook.DTO.SocialMediaDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient("MyApiClient");
            var resutlMessage = await client.GetAsync("https://localhost:7112/api/SocialMedia");
            if (resutlMessage.IsSuccessStatusCode)
            {
                var jsonData = await resutlMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSocialMediaDto createSocialMediaDto)
        {
            var client = _httpClientFactory.CreateClient("MyApiClient");
            var jsonData = JsonConvert.SerializeObject(createSocialMediaDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var resultMessage = await client.PostAsync("https://localhost:7112/api/SocialMedia", stringContent);
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
                //return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }

            return View(createSocialMediaDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var client = _httpClientFactory.CreateClient("MyApiClient");
            var resultMessage = await client.DeleteAsync($"https://localhost:7112/api/SocialMedia/{id}");
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient("MyApiClient");
            var resultMessage = await client.GetAsync($"https://localhost:7112/api/SocialMedia/{id}");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(jsonData);
                TempData["UpdateSocialMediaId"] = value.SocialMediaId;
                value.SocialMediaId = 0;
                return View(value);
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateSocialMediaDto updateSocialMediaDto)
        {
            updateSocialMediaDto.SocialMediaId = (int)TempData["UpdateSocialMediaId"];

            var client = _httpClientFactory.CreateClient("MyApiClient");
            var jsonData = JsonConvert.SerializeObject(updateSocialMediaDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var resultMessage = await client.PutAsync("https://localhost:7112/api/SocialMedia", stringContent);
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateSocialMediaDto);

        }
    }
}

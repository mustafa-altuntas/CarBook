using Carbook.DTO.FeatureDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient("MyApiClient");
            var resutlMessage = await client.GetAsync("https://localhost:7112/api/Feature");
            if (resutlMessage.IsSuccessStatusCode)
            {
                var jsonData = await resutlMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var client = _httpClientFactory.CreateClient("MyApiClient");
            var jsonData = JsonConvert.SerializeObject(createFeatureDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var resultMessage = await client.PostAsync("https://localhost:7112/api/Feature", stringContent);
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createFeatureDto);
        }

        public async Task<IActionResult> RemoveFeature(int id)
        {
            var client = _httpClientFactory.CreateClient("MyApiClient");
            var resultMessage = await client.DeleteAsync($"https://localhost:7112/api/Feature/{id}");
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> UpdateFeature(int id)
        {
            var client = _httpClientFactory.CreateClient("MyApiClient");
            var resultMessage = await client.GetAsync($"https://localhost:7112/api/Feature/{id}");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
                TempData["UpdateFeatureId"] = value.FeatureId;
                value.FeatureId = 0;
                return View(value);
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            updateFeatureDto.FeatureId = (int)TempData["UpdateFeatureId"];

            var client = _httpClientFactory.CreateClient("MyApiClient");
            var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var resultMessage = await client.PutAsync("https://localhost:7112/api/Feature", stringContent);
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateFeatureDto);

        }







    }
}

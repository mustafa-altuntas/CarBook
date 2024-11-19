using Carbook.DTO.CarFeatureDtos;
using Carbook.DTO.FeatureDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{carId}")]
        public async Task<IActionResult> Index(int carId)
        {
            ViewBag.Id = carId;

            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.GetAsync($"https://localhost:7112/api/CarFeature/{carId}");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost("{carId}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> dtos, int carId)
        {
            var client = _httpClientFactory.CreateClient();

            foreach (var item in dtos)
            {
                string url = item.Available
                    ? $"https://localhost:7112/api/CarFeature/UpdateCarFeatureAvailableChangeToTrue/{item.CarFeatureId}"
                    : $"https://localhost:7112/api/CarFeature/UpdateCarFeatureAvailableChangeToFalse/{item.CarFeatureId}";
                var resultMessage = await client.GetAsync(url);
                if (!resultMessage.IsSuccessStatusCode)
                {
                    TempData["ErrorMessage"] = "Bir hata oluştu!";
                    return RedirectToAction("Index", new { carId = carId });
                }
            }

            TempData["SuccessMessage"] = "İşlem başarıyla tamamlandı!";
            return RedirectToAction("Index", new { carId = carId });
        }


        [HttpGet("{carId}")]
        public async Task<IActionResult> CreateFeatureByCarId()
        {

            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.GetAsync($"https://localhost:7112/api/Feature");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }

            return View();
        }

    }
}

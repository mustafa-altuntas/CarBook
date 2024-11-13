using Carbook.DTO.CarFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
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
            if(resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost("{carId}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> dtos,int carId)
        {
            var client = _httpClientFactory.CreateClient();

            foreach (var item in dtos)
            {
                if (item.Available)
                {
                    var resultMessage1 = await client.GetAsync($"https://localhost:7112/api/CarFeature/UpdateCarFeatureAvailableChangeToTrue/{item.CarFeatureId}");
                }
                else
                {
                    var resultMessage2 = await client.GetAsync($"https://localhost:7112/api/CarFeature/UpdateCarFeatureAvailableChangeToFalse/{item.CarFeatureId}");

                }
            }

            var resultMessage = await client.GetAsync($"https://localhost:7112/api/CarFeature/{carId}");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }


            return View();
        }

    }
}

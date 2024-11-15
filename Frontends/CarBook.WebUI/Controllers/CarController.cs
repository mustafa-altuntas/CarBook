using Carbook.DTO.CarDtos;
using Carbook.DTO.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Arabalar";
            ViewBag.v2 = "Arabanızı Seçin";

            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.GetAsync("https://localhost:7112/api/CarPricing/GetCarPricingWithCarsList");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingDto>>(jsonData);
                return View(values);
            }

            return View();
        }


        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.v1 = "Araba Detayları";
            ViewBag.v2 = "Arabanının Teknik Aksesuar ve Özellikleri";
            ViewBag.CarId = id;
            return View();
        }


    }
}

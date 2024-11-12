using Carbook.DTO.BrandDtos;
using Carbook.DTO.CarDtos.CarEnums;
using Carbook.DTO.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var resutlMessage = await client.GetAsync("https://localhost:7112/api/Car/CarListWithBrand");
            if (resutlMessage.IsSuccessStatusCode)
            {
                var jsonData = await resutlMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var resutlMessage = await client.GetAsync("https://localhost:7112/api/Brand");
            if (resutlMessage.IsSuccessStatusCode)
            {
                var jsonData = await resutlMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                List<SelectListItem> selectListItems = new List<SelectListItem> { new SelectListItem { Text = "Seçiniz" } };

                selectListItems.AddRange(
                    from item in values
                    select new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.BrandId.ToString()
                    });

                ViewData["SelectBrandList"] = selectListItems;
                ViewBag.TransmissionType = new SelectList(Enum.GetNames(typeof(TransmissionType)));
                ViewBag.FuelType = new SelectList(Enum.GetNames(typeof(FuelType)));
            }


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var resultMessage = await client.PostAsync("https://localhost:7112/api/Car", stringContent);
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(createCarDto);
        }

        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.DeleteAsync($"https://localhost:7112/api/Car/{id}");
            return resultMessage.IsSuccessStatusCode
                ?RedirectToAction(nameof(Index))
                :View();
        }

        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var resutlMessage1 = await client.GetAsync("https://localhost:7112/api/Brand");
            if (resutlMessage1.IsSuccessStatusCode)
            {
                var jsonData = await resutlMessage1.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                List<SelectListItem> selectListItems = new List<SelectListItem> { new SelectListItem { Text = "Seçiniz" } };

                selectListItems.AddRange(
                    from item in values
                    select new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.BrandId.ToString()
                    });

                ViewData["SelectBrandList"] = selectListItems;
                ViewBag.TransmissionType = new SelectList(Enum.GetNames(typeof(TransmissionType)));
                ViewBag.FuelType = new SelectList(Enum.GetNames(typeof(FuelType)));
            }

            var resultMessage = await client.GetAsync($"https://localhost:7112/api/Car/{id}");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
                TempData["UpdateCarId"] = value.CarId;
                value.CarId = 0;
                return View(value);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            updateCarDto.CarId = (int)TempData["UpdateCarId"];

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var resultMessage = await client.PutAsync("https://localhost:7112/api/Car", stringContent);
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            var resutlMessage1 = await client.GetAsync("https://localhost:7112/api/Brand");
            if (resutlMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await resutlMessage1.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData1);
                List<SelectListItem> selectListItems = new List<SelectListItem> { new SelectListItem { Text = "Seçiniz" } };

                selectListItems.AddRange(
                    from item in values
                    select new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.BrandId.ToString()
                    });


                ViewData["SelectBrandList"] = selectListItems;
                ViewBag.TransmissionType = new SelectList(Enum.GetNames(typeof(TransmissionType)));
                ViewBag.FuelType = new SelectList(Enum.GetNames(typeof(FuelType)));
            }
            return View(updateCarDto);

        }

        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {

            return View();
        }



    }
}

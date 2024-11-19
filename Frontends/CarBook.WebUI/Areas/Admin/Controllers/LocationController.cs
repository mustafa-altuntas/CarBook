using Carbook.DTO.LocationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class LocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "carbooktoken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var resutlMessage = await client.GetAsync("https://localhost:7112/api/Location");
                if (resutlMessage.IsSuccessStatusCode)
                {
                    var jsonData = await resutlMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                    return View(values);
                }
            }

            return View();
        }

        //public async Task<IActionResult> Index()
        //{

        //    var client = _httpClientFactory.CreateClient();
        //    var resutlMessage = await client.GetAsync("https://localhost:7112/api/Location");
        //    if (resutlMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await resutlMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
        //        return View(values);
        //    }

        //    return View();
        //}

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLocationDto createLocationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createLocationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var resultMessage = await client.PostAsync("https://localhost:7112/api/Location", stringContent);
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
                //return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }

            return View(createLocationDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.DeleteAsync($"https://localhost:7112/api/Location/{id}");
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.GetAsync($"https://localhost:7112/api/Location/{id}");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateLocationDto>(jsonData);
                TempData["UpdateLocationId"] = value.LocationId;
                value.LocationId = 0;
                return View(value);
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateLocationDto updateLocationDto)
        {
            updateLocationDto.LocationId = (int)TempData["UpdateLocationId"];

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateLocationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var resultMessage = await client.PutAsync("https://localhost:7112/api/Location", stringContent);
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateLocationDto);

        }
    }
}

using Carbook.DTO.BannerDtos;
using Carbook.DTO.BannerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BannerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var resutlMessage = await client.GetAsync("https://localhost:7112/api/Banner");
            if (resutlMessage.IsSuccessStatusCode)
            {
                var jsonData = await resutlMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
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
        public async Task<IActionResult> Create(CreateBannerDto createBannerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBannerDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var resultMessage = await client.PostAsync("https://localhost:7112/api/Banner", stringContent);
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createBannerDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.DeleteAsync($"https://localhost:7112/api/Banner/{id}");
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
            var resultMessage = await client.GetAsync($"https://localhost:7112/api/Banner/{id}");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateBannerDto>(jsonData);
                TempData["UpdateBannerId"] = value.BannerId;
                value.BannerId = 0;
                return View(value);
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateBannerDto updateBannerDto)
        {
            updateBannerDto.BannerId = (int)TempData["UpdateBannerId"];

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBannerDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var resultMessage = await client.PutAsync("https://localhost:7112/api/Banner", stringContent);
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateBannerDto);

        }



    }
}

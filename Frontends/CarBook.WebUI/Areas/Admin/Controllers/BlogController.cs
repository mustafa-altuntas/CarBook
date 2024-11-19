using Carbook.DTO.BlogDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BlogController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient("MyApiClient");
            var resutlMessage = await client.GetAsync("https://localhost:7112/api/Blog/GetAllBlogsWithAuthorList");
            if (resutlMessage.IsSuccessStatusCode)
            {
                var jsonData = await resutlMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
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
        public async Task<IActionResult> Create(CreateBlogDto createBlogDto)
        {
            var client = _httpClientFactory.CreateClient("MyApiClient");
            var jsonData = JsonConvert.SerializeObject(createBlogDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var resultMessage = await client.PostAsync("https://localhost:7112/api/Blog", stringContent);
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
                //return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }

            return View(createBlogDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var client = _httpClientFactory.CreateClient("MyApiClient");
            var resultMessage = await client.DeleteAsync($"https://localhost:7112/api/Blog/{id}");
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
            var resultMessage = await client.GetAsync($"https://localhost:7112/api/Blog/{id}");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateBlogDto>(jsonData);
                TempData["UpdateBlogId"] = value.BlogID;
                value.BlogID = 0;
                return View(value);
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateBlogDto updateBlogDto)
        {
            updateBlogDto.BlogID = (int)TempData["UpdateBlogId"];

            var client = _httpClientFactory.CreateClient("MyApiClient");
            var jsonData = JsonConvert.SerializeObject(updateBlogDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var resultMessage = await client.PutAsync("https://localhost:7112/api/Blog", stringContent);
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateBlogDto);

        }

    }
}

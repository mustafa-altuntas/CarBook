using Carbook.DTO.BlogDtos;
using Carbook.DTO.CarPricingDtos;
using Carbook.DTO.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Bloglar";

            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.GetAsync("https://localhost:7112/api/Blog/GetAllBlogsWithAuthorList");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> BlogDetail(int id)
        {

            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Blog Detayı ve yorumlar";
            ViewBag.BlogId = id;

            return View();
        }

        [HttpGet]
        public async Task<PartialViewResult> AddCommet()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddCommet(CreateCommentDto request)
        {
            request.CreatedDate = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var resultMessage = await client.PostAsync("https://localhost:7112/api/Comment/CreateCommentWithMediator",stringContent);
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View();
        }



    }
}

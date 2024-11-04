using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class StatisticController : Controller
    {


        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.GetAsync($"www");
            if(resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<int>(jsonData);
                return View(values);
            }



            return View();
        }
    }
}

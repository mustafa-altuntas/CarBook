using Carbook.DTO.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Araç Rezervasyon Formu";

            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.GetAsync($"https://localhost:7112/api/Location");
            if(resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

                List<SelectListItem> selectListItems = values.Select(l => new SelectListItem { Text = l.Name, Value = l.Name }).ToList();
                ViewBag.LocationSelectList = selectListItems;

                return View();
            }






            return View();
        }
    }
}

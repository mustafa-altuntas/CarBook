using Carbook.DTO.LocationDtos;
using Carbook.DTO.ReservationDtos;
using Carbook.DTO.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Araç Rezervasyon Formu";
            ViewBag.v3 = id;

            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.GetAsync($"https://localhost:7112/api/Location");
            if(resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

                List<SelectListItem> selectListItems = values.Select(l => new SelectListItem { Text = l.Name, Value = l.LocationId.ToString() }).ToList();
                ViewBag.LocationSelectList = selectListItems;

                return View();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto dto)
        {




            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var resultMessage = await client.PostAsync("https://localhost:7112/api/Reservation", stringContent);
            if (resultMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index),"Default");
                //return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            var v = resultMessage.RequestMessage;

            ViewBag.v3 = dto.CarId;

            var resultMessage1 = await client.GetAsync($"https://localhost:7112/api/Location");
            if (resultMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await resultMessage1.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData1);

                List<SelectListItem> selectListItems = values1.Select(l => new SelectListItem { Text = l.Name, Value = l.LocationId.ToString() }).ToList();
                ViewBag.LocationSelectList = selectListItems;

            }


            return View(dto);
        }



    }
}

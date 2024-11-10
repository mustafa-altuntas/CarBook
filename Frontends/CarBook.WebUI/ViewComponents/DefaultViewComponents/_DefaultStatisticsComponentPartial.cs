using Carbook.DTO.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.GetAsync($"https://localhost:7112/api/Statistic/GetAllStatistics");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultAllStatisticDto>(jsonData);

                ViewBag.CarCount = values.CarCount;
                ViewBag.LocationCount = values.LocationCount;
                ViewBag.BrandCount = values.BrandCount;

                return View();
            }

            // deneyim yılı, araç sayısı, müşteri sayısı, şube sayısı



            return View();
        }
    }
}

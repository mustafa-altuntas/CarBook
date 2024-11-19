using Carbook.DTO.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _DashboardCarPricingListComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardCarPricingListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient("MyApiClient");
            var resultMessage = await client.GetAsync($"https://localhost:7112/api/CarPricing/GetCarPricingWithTimePeriod");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithTimePeriodDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}

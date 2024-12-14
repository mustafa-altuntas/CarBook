using Carbook.DTO.CarDtos;
using Carbook.DTO.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultLast5CarsWithBrandsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultLast5CarsWithBrandsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ResultLast5CarsWhithBrands> result = new();

            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.GetAsync("https://localhost:7112/api/Car/GetLast5CarsWhithBrands");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<ResultLast5CarsWhithBrands>>(jsonData);
                //return View(values);
            }


            var client1 = _httpClientFactory.CreateClient();
            var resultMessage1 = await client1.GetAsync($"https://localhost:7112/api/CarPricing/GetCarPricingWithTimePeriod");
            if (resultMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await resultMessage1.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<List<ResultCarPricingWithTimePeriodDto>>(jsonData1);
                foreach(var item in values1)
                {
                    var car = result.Where(x => x.Model == item.Model && x.BrandName == item.Brand).FirstOrDefault();
                    if(car != null)
                    {
                        car.ResultCarPricing = item;
                    }
                }

                return View(result);
            }




            return View();
        }
    }
}

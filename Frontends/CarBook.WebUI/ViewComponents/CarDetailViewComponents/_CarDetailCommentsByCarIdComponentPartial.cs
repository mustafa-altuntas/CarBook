using Carbook.DTO.CarDescriptionDtos;
using Carbook.DTO.ReviewDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCommentsByCarIdComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailCommentsByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int carId)
        {
            ViewBag.Id = carId;

            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.GetAsync($"https://localhost:7112/api/Review/ReviewListByCarId?carId={carId}");
            if (!resultMessage.IsSuccessStatusCode)
            {
                return View();
            }

            var star = new List<StarDto>();

            var jsonData = await resultMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultReviewByCarIdDto>>(jsonData);

            for ( int i = 1; i < 6; i++)
            {
                star.Add(new StarDto { StarCount=i,StarCommentCount= values.Where(x => x.RaytingValue == i).Count(), Percent= (100 * values.Where(x => x.RaytingValue == i).Count()) / values.Count });
            }
            star.Reverse();


            return View((values, star));
        }
    }
}



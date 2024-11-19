using Carbook.DTO.BlogDtos;
using Carbook.DTO.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _DashboardBlogListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardBlogListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient("MyApiClient");
            var resutlMessage = await client.GetAsync("https://localhost:7112/api/Blog/GetAllBlogsWithAuthorList");
            if (resutlMessage.IsSuccessStatusCode)
            {
                var jsonData = await resutlMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
                var result = values.OrderByDescending(b => b.CreatedDate).Take(5).ToList();
                return View(result);
            }
            return View();
        }

    }
}

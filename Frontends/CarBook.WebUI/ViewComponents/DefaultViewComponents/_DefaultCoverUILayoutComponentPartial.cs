using Carbook.DTO.BannerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCoverUILayoutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultCoverUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.GetAsync("https://localhost:7112/api/Banner");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}

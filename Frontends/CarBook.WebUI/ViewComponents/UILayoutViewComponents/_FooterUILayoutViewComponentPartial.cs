using Carbook.DTO.AboutDtos;
using Carbook.DTO.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutViewComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterUILayoutViewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();
            var resutlMessage = await client.GetAsync("https://localhost:7112/api/https://localhost:7112/api/FooterAddress");
            if (resutlMessage.IsSuccessStatusCode)
            {
                var jsonData = await resutlMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterAddresDto>>(jsonData);
                var value = values.FirstOrDefault();
                return View(value);
            }


            return View();
        }
    }
}

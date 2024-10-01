using Carbook.DTO.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsRecentBlogsComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsRecentBlogsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.GetAsync("https://localhost:7112/api/Blog/GetLast3BlogsWhitAuthorsList");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultLast3BlogsWhitAuthorsDto>>(jsonData);
                return View(value);
            }

            return View();
        }
    }
}

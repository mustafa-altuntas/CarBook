using Carbook.DTO.BlogDtos;
using Carbook.DTO.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _GetLast3BlogsWhitAuthorsListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _GetLast3BlogsWhitAuthorsListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            List<ResultLast3BlogsWhitAuthorsDto> values;

            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.GetAsync("https://localhost:7112/api/Blog/GetLast3BlogsWhitAuthorsList");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultLast3BlogsWhitAuthorsDto>>(jsonData);

                foreach (var blog in values)
                {
                    var responseMessage1 = await client.GetAsync($"https://localhost:7112/api/Comment/CommentListByBlog?id={blog.BlogID}");
                    if (responseMessage1.IsSuccessStatusCode)
                    {
                        var jsonD = await responseMessage1.Content.ReadAsStringAsync();
                        blog.CommentCount = JsonConvert.DeserializeObject<List<ResutlCommentDto>>(jsonD).Count;
                    }

                } 

                return View(values);

            }

            return View();
        }
    }
}

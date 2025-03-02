using Carbook.DTO.AboutDtos;
using Carbook.DTO.FooterAddressDtos;
using Carbook.DTO.SocialMediaDtos;
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

            // "https://localhost:7112/api/SocialMedia"


            ResultFooterAddresDto footerAddress;
            ResultSocialMediaDto socialMedia;

            var client = _httpClientFactory.CreateClient();
            var resutlMessageFooter = await client.GetAsync("https://localhost:7112/api/FooterAddress");
            if (!resutlMessageFooter.IsSuccessStatusCode)
            {
                return View();
            }
            var jsonData1 = await resutlMessageFooter.Content.ReadAsStringAsync();
            var footerAddresss = JsonConvert.DeserializeObject<List<ResultFooterAddresDto>>(jsonData1);
            footerAddress = footerAddresss.FirstOrDefault();

            var resutlMessageSocial = await client.GetAsync("https://localhost:7112/api/SocialMedia");
            if (!resutlMessageSocial.IsSuccessStatusCode)
            {
                return View();
            }
            var jsonData2 = await resutlMessageSocial.Content.ReadAsStringAsync();
            var socialMedias = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData2);




            return View((footerAddress, socialMedias));

        }
    }
}

using CarBook.Domain;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CarBook.WebApi.Hubs
{
    public class CarHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();
            var resultMessage = await client.GetAsync("https://localhost:7112/api/Car");
            if (resultMessage.IsSuccessStatusCode)
            {
                var jsonData = await resultMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Car>>(jsonData)!.Count();
                
                await Clients.All.SendAsync("ReceiveCarCount",values);
            }
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductImagesDtos;
using RealEstate_Dapper_UI.Services.ApiServices;

namespace RealEstate_Dapper_UI.ViewComponents.SingleProperty
{
    public class _PropertySliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiSettings _api;
        public _PropertySliderComponentPartial(IHttpClientFactory httpClientFactory, IApiSettings api)
        {
            _httpClientFactory = httpClientFactory;
            _api = api;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}ProductImages/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<GetProductImageByProductIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

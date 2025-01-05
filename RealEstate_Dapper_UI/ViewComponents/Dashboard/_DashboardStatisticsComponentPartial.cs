using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Services.ApiServices;
using System.Net.Http;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiSettings _api;

        public _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory, IApiSettings api)
        {
            _httpClientFactory = httpClientFactory;
            _api = api;
        }

        private async Task ProductCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Statistics/ProductCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.ProductCount = value;
            }
        }

        private async Task EmployeeNameByMaxProductCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Statistics/EmployeeNameByMaxProductCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                ViewBag.EmployeeNameByMaxProductCount = jsonData;
            }
        }

        private async Task DifferentCityCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Statistics/DifferentCityCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.DifferentCityCount = value;
            }
        }

        private async Task AverageProductPriceByRent()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Statistics/AverageProductPriceByRent");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.AverageProductPriceByRent = value.ToString("N0");
            }
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            await ProductCount();

            await EmployeeNameByMaxProductCount();

            await DifferentCityCount();

            await AverageProductPriceByRent();

            return View();
        }
    }
}

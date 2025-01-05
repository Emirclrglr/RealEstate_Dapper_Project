using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Services;
using RealEstate_Dapper_UI.Services.ApiServices;
using System.Net.Http;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IApiSettings _api;
        public _EstateAgentDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService, IApiSettings api)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _api = api;
        }

        //int ProductCountByEmployeeId(int id);
        //int ProductCountByStatusTrue(int id);
        //int ProductCountByStatusFalse(int id);
        //int AllProductsCount();

        private async Task ProductCountByEmployeeId()
        {
            var id = _loginService.getUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}EstateAgentDashboardStatistics/ProductCountByEmployeeId/{id}");
            if ( responseMessage.IsSuccessStatusCode )
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.ProductCountByEmployeeId = value;
            }
        }

        private async Task ProductCountByStatusTrue()
        {
            var id = _loginService.getUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}EstateAgentDashboardStatistics/ProductCountByStatusTrue/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.ProductCountByStatusTrue = value;
            }
        }

        private async Task ProductCountByStatusFalse()
        {
            var id = _loginService.getUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}EstateAgentDashboardStatistics/ProductCountByStatusFalse/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.ProductCountByStatusFalse = value;
            }
        }

        private async Task AllProductsCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}EstateAgentDashboardStatistics/AllProductsCount/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.AllProductsCount = value;
            }
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await ProductCountByEmployeeId();
            await ProductCountByStatusFalse();
            await ProductCountByStatusTrue();
            await AllProductsCount();
            return View();
        }
    }
}

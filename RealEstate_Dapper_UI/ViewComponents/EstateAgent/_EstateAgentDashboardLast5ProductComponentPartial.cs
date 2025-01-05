using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services;
using RealEstate_Dapper_UI.Services.ApiServices;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardLast5ProductComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IApiSettings _api;

        public _EstateAgentDashboardLast5ProductComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService, IApiSettings api)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _api = api;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.getUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}EstateAgentLastProducts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

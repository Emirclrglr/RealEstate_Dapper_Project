using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.MessageDtos;
using RealEstate_Dapper_UI.Services;
using RealEstate_Dapper_UI.Services.ApiServices;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.ViewComponents.EstateAgentNavbarViewComponents
{
    public class _EstateAgentNavbarMessagesComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IApiSettings _api;

        public _EstateAgentNavbarMessagesComponentPartial(ILoginService loginService, IHttpClientFactory httpClientFactory, IApiSettings api)
        {
            _loginService = loginService;
            _httpClientFactory = httpClientFactory;
            _api = api;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _loginService.getUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Messages/GetLast3InBoxMessagesByReceiverWithRelations/{userId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultInBoxWithRelationsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

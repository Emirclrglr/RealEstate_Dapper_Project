using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services;
using RealEstate_Dapper_UI.Services.ApiServices;
using System.Text;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class MyAdvertsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IApiSettings _api;

        public MyAdvertsController(IHttpClientFactory httpClientFactory, ILoginService loginService, IApiSettings api)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _api = api;
        }

        private async Task CategoryDropDownList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Categories");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                

                List<SelectListItem> categoryValues = (from x in values.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.categoryName,
                                                           Value = x.categoryId.ToString()
                                                       }).ToList();

                ViewBag.categoryDropDown = categoryValues;
            }
        }

        public async Task<IActionResult> ActiveAdverts()
        {
            var userId = _loginService.getUserId;
            

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Products/GetTrueProductsByEmployeeId/{userId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> PassiveAdverts()
        {
            var userId = _loginService.getUserId;


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Products/GetFalseProductsByEmployeeId/{userId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            await CategoryDropDownList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            var userId = _loginService.getUserId;
            dto.AppUserId = int.Parse(userId);
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_api.BaseUrl}Products", content);
            await CategoryDropDownList();
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/EstateAgent/MyAdverts/ActiveAdverts/");
            }
            return View(dto);
        }
    }
}

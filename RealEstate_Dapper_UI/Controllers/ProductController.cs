using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.AppUserDtos;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.EmployeeDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services.ApiServices;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiSettings _api;

        public ProductController(IHttpClientFactory httpClientFactory, IApiSettings api)
        {
            _httpClientFactory = httpClientFactory;
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

        private async Task EmployeeDropDownList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}AppUsers/GetAllAppUsers");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAppUserDto>>(jsonData);
            if (responseMessage.IsSuccessStatusCode)
            {
                List<SelectListItem> employeeList = (from x in values.ToList()
                                                            select new SelectListItem
                                                            {
                                                                Text = x.Name,
                                                                Value = x.UserId.ToString()
                                                            }).ToList();

                ViewBag.employeeDropDown = employeeList;

            }


        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Products/ProductListWithRelations");
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

            await EmployeeDropDownList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_api.BaseUrl}Products", content);
            await CategoryDropDownList();
            await EmployeeDropDownList();
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(dto);

        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            await CategoryDropDownList();
            await EmployeeDropDownList();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Products/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);

                return View(values);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            await CategoryDropDownList();
            await EmployeeDropDownList();
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_api.BaseUrl}Products", content);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{_api.BaseUrl}Products/{id}");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SetDealOfTheDayTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(id);
            StringContent content = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_api.BaseUrl}Products/SetDealOfTheDayActive/{id}", content);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SetDealOfTheDayFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(id);
            StringContent content = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_api.BaseUrl}Products/SetDealOfTheDayPassive/{id}", content);
            return RedirectToAction("Index");
        }
    }
}

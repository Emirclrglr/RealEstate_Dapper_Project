using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services.ApiServices;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiSettings _api;
        public PropertyController(IHttpClientFactory httpClientFactory, IApiSettings api)
        {
            _httpClientFactory = httpClientFactory;
            _api = api;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "RealEstate - İlanlar";
            ViewBag.breadcrumb1 = "Anasayfa";
            ViewBag.breadcrumb2 = "İlanlar";
            ViewBag.link = "/Default/Index/";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Products/ProductListWithRelations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> PropertyListByFilter(string keyword, int categoryId, string city)
        {
            ViewBag.Title = "RealEstate - İlanlar";
            ViewBag.breadcrumb1 = "Anasayfa";
            ViewBag.breadcrumb2 = "İlanlar";
            ViewBag.link = "/Default/Index/";
            keyword = (string)TempData["keyword"];
            city = (string)TempData["city"];
            categoryId = (int)TempData["categoryId"];
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Products/ResultProductByFilter/{keyword}/{categoryId}/{city}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet("property/{slug}/{id}")]
        public async Task<IActionResult> SingleProperty(string slug, int id)
        {
            ViewBag.Title = "RealEstate - İlan Detayları";
            ViewBag.breadcrumb1 = "İlanlar";
            ViewBag.breadcrumb2 = "İlan Detayları";
            ViewBag.link = "/Property/Index/";


            ViewBag.Id = id;

            var client = _httpClientFactory.CreateClient();

            #region Products
            var productResponseMessage = await client.GetAsync($"{_api.BaseUrl}Products/{id}");
            var productJsonData = await productResponseMessage.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<ResultProductDto>(productJsonData);
            
            ViewBag.ProductTitle = products.productTitle;
            ViewBag.ProductPrice = products.price.ToString("N0");
            ViewBag.Address = $"{products.address} {products.city} / {products.district}";
            ViewBag.Type = products.type;
            ViewBag.Date = products.ListingDate;
            ViewBag.Image = products.coverImg;
            ViewBag.Description = products.description;
            ViewBag.ProductId = products.productId;
            ViewBag.UserId = products.AppUserId;
            
            #endregion

            #region Product Details
            var productDetailsResponseMessage = await client.GetAsync($"{_api.BaseUrl}ProductDetails/GetProductDetailByProductId/{id}");
            var productDetailsJsonData = await productDetailsResponseMessage.Content.ReadAsStringAsync();
            var productDetails = JsonConvert.DeserializeObject<ResultProductDetailsDto>(productDetailsJsonData);

            ViewBag.BedroomCount = productDetails.bedroom;
            ViewBag.BathCount = productDetails.bathroom;
            ViewBag.PropertySize = productDetails.propertySize;
            ViewBag.RoomCount = productDetails.room;
            ViewBag.GarageCount = productDetails.garageSize;
            ViewBag.BuiltYear = productDetails.buildYear;
            ViewBag.Location = productDetails.location;
            ViewBag.VideoUrl = productDetails.videoUrl;
            #endregion


            return View();
        }

    }
}

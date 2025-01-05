using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Services.ApiServices;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiSettings _api;

        public StatisticsController(IHttpClientFactory httpClientFactory, IApiSettings api)
        {
            _httpClientFactory = httpClientFactory;
            _api = api;
        }


        #region Statistics Consume Methods
        private async Task ActiveCategoryCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Statistics/ActiveCategoryCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.ActiveCategoryCount = value;
            }
        }

        private async Task ActiveEmployeeCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Statistics/ActiveEmployeeCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.ActiveEmployeeCount = value;
            }
        }

        private async Task ApartmentCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Statistics/ApartmentCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.ApartmentCount = value;
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
                ViewBag.AverageProductPriceByRent = value;
            }
        }

        private async Task AverageProductPriceBySale()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Statistics/AverageProductPriceBySale");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.AverageProductPriceBySale = value;
            }

        }

        private async Task AverageRoomCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Statistics/AverageRoomCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.AverageRoomCount = value;
            }
        }

        private async Task CategoryCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Statistics/CategoryCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.CategoryCount = value;
            }
        }

        private async Task CategoryNameByMaxProductCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Statistics/CategoryNameByMaxProductCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                ViewBag.CategoryNameByMaxProductCount = jsonData;
            }
        }

        private async Task CityNameByMaxProductCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Statistics/CityNameByMaxProductCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                ViewBag.CityNameByMaxProductCount = jsonData;
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

        private async Task NewestBuildingYear()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Statistics/NewestBuildingYear");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                ViewBag.NewestBuildingYear = jsonData;
            }
        }

        private async Task OldestBuildingYear()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Statistics/OldestBuildingYear");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                ViewBag.OldestBuildingYear = jsonData;
            }
        }

        private async Task PassiveCategoryCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Statistics/PassiveCategoryCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.PassiveCategoryCount = value;
            }

        }

        private async Task PriceOfLatestListing()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Statistics/PriceOfLatestListing");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.PriceOfLatestListing = value;
            }

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

        #endregion


        public async Task<IActionResult> Index()
        {
            #region Statistics
            await ActiveCategoryCount();

            await ActiveEmployeeCount();

            await ApartmentCount();

            await AverageProductPriceByRent();

            await AverageProductPriceBySale();

            await AverageRoomCount();

            await CategoryCount();

            await CategoryNameByMaxProductCount();

            await CityNameByMaxProductCount();

            await DifferentCityCount();

            await EmployeeNameByMaxProductCount();

            await NewestBuildingYear();

            await OldestBuildingYear();

            await PassiveCategoryCount();

            await PriceOfLatestListing();

            await ProductCount();


            #endregion

            return View();
        }
    }
}

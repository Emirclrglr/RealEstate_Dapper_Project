using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsController(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
            => Ok(_statisticsRepository.ActiveCategoryCount());

        [HttpGet("ActiveEmployeeCount")]
        public IActionResult ActiveEmployeeCount()
            => Ok(_statisticsRepository.ActiveEmployeeCount());

        [HttpGet("ApartmentCount")]
        public IActionResult ApartmentCount()
            => Ok(_statisticsRepository.ApartmentCount());

        [HttpGet("AverageProductPriceByRent")]
        public IActionResult AverageProductPriceByRent()
            => Ok(_statisticsRepository.AverageProductPriceByRent());

        [HttpGet("AverageProductPriceBySale")]
        public IActionResult AverageProductPriceBySale()
            => Ok(_statisticsRepository.AverageProductPriceBySale());

        [HttpGet("AverageRoomCount")]
        public IActionResult AverageRoomCount()
            => Ok(_statisticsRepository.AverageRoomCount());

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
            => Ok(_statisticsRepository.CategoryCount());

        [HttpGet("CategoryNameByMaxProductCount")]
        public IActionResult CategoryNameByMaxProductCount()
           => Ok(_statisticsRepository.CategoryNameByMaxProductCount());

        [HttpGet("CityNameByMaxProductCount")]
        public IActionResult CityNameByMaxProductCount()
           => Ok(_statisticsRepository.CityNameByMaxProductCount());

        [HttpGet("DifferentCityCount")]
        public IActionResult DifferentCityCount()
           => Ok(_statisticsRepository.DifferentCityCount());

        [HttpGet("EmployeeNameByMaxProductCount")]
        public IActionResult EmployeeNameByMaxProductCount()
           => Ok(_statisticsRepository.EmployeeNameByMaxProductCount());

        [HttpGet("NewestBuildingYear")]
        public IActionResult NewestBuildingYear()
           => Ok(_statisticsRepository.NewestBuildingYear());

        [HttpGet("OldestBuildingYear")]
        public IActionResult OldestBuildingYear()
           => Ok(_statisticsRepository.OldestBuildingYear());

        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
           => Ok(_statisticsRepository.PassiveCategoryCount());

        [HttpGet("PriceOfLatestListing")]
        public IActionResult PriceOfLatestListing()
           => Ok(_statisticsRepository.PriceOfLatestListing());

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
           => Ok(_statisticsRepository.ProductCount());
    }
}

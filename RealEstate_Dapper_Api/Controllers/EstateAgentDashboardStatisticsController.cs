using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentDashboardStatisticsController : ControllerBase
    {
        private readonly IEstateAgentStatisticRepository _estateAgentStatisticRepository;

        public EstateAgentDashboardStatisticsController(IEstateAgentStatisticRepository estateAgentStatisticRepository)
        {
            _estateAgentStatisticRepository = estateAgentStatisticRepository;
        }

        [HttpGet("AllProductsCount")]
        public IActionResult AllProducts()
        {
            var values = _estateAgentStatisticRepository.AllProductsCount();
            return Ok(values);
        }

        [HttpGet("ProductCountByEmployeeId/{id}")]
        public IActionResult ProductCountByEmployeeId(int id)
        {
            var values = _estateAgentStatisticRepository.ProductCountByEmployeeId(id);
            return Ok(values);
        }

        [HttpGet("ProductCountByStatusTrue/{id}")]
        public IActionResult ProductCountByStatusTrue(int id)
        {
            var values = _estateAgentStatisticRepository.ProductCountByStatusTrue(id);
            return Ok(values);
        }

        [HttpGet("ProductCountByStatusFalse/{id}")]
        public IActionResult ProductCountByStatusFalse(int id)
        {
            var values = _estateAgentStatisticRepository.ProductCountByStatusFalse(id);
            return Ok(values);
        }
    }
}

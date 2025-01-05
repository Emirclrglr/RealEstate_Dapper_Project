using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentLastProductsController : ControllerBase
    {
        private readonly ILast5ProductsRepository _last5ProductsRepository;

        public EstateAgentLastProductsController(ILast5ProductsRepository last5ProductsRepository)
        {
            _last5ProductsRepository = last5ProductsRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLast5ProductByEmployeeId(int id)
        {
            var values = await _last5ProductsRepository.GetLast5ProductByEmployeeId(id);
            return Ok(values);
        }
    }
}

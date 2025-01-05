using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Repositories.PopularLocationsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationsRepository _popularLocationsRepository;

        public PopularLocationsController(IPopularLocationsRepository popularLocationsRepository)
        {
            _popularLocationsRepository = popularLocationsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPopularLocations()
        {
            var values = await _popularLocationsRepository.GetAllPopularLocationsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopularLocationById(int id)
        {
            var values = await _popularLocationsRepository.GetPopularLocationsByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreatePopularLocation(CreatePopularLocationsDto dto)
        {
            _popularLocationsRepository.CreatePopularLocation(dto);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatePopularLocation(UpdatePopularLocationsDto dto)
        {
            _popularLocationsRepository.UpdatePopularLocation(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePopularLocation(int id)
        {
            _popularLocationsRepository.DeletePopularLocation(id);
            return Ok();
        }
    }
}

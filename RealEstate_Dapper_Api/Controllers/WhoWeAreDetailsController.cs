using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailsController : ControllerBase
    {
        private readonly IWhoWeAreDetailRepository _whoWeAreDetailRepository;

        public WhoWeAreDetailsController(IWhoWeAreDetailRepository whoWeAreDetailRepository)
        {
            _whoWeAreDetailRepository = whoWeAreDetailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> WhoWeAreDetailList()
        {
            var values = await _whoWeAreDetailRepository.GetAllWhoWeAreDetailAsync();
            return Ok(values);
        }

        [HttpGet("GetFirst")]
        public async Task<IActionResult> GetFirstWhoWeAreDetail()
        {
            var value = await _whoWeAreDetailRepository.GetFirstWhoWeAreDetailAsync();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdWhoWeAreDetail(int id)
        {
            var value = await _whoWeAreDetailRepository.GetByIdWhoWeAreDetail(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateWhoWeAreDetail(CreateWhoWeAreDetailDto dto)
        {
            _whoWeAreDetailRepository.CreateWhoWeAreDetail(dto);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteWhoWeAreDetail(int id)
        {
            _whoWeAreDetailRepository.DeleteWhoWeAreDetail(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto dto)
        {
            _whoWeAreDetailRepository.UpdateWhoWeAreDetail(dto);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridsController : ControllerBase
    {
        private readonly IBottomGridRepository _bottomGridRepository;

        public BottomGridsController(IBottomGridRepository bottomGridRepository)
        {
            _bottomGridRepository = bottomGridRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBottomGrid()
        {
            var result = await _bottomGridRepository.GetAllBottomGridAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBottomGridById(int id)
        {
            var values = await _bottomGridRepository.GetBottomGridByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBottomGrid(CreateBottomGridDto dto)
        {
            _bottomGridRepository.CreateBottomGrid(dto);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBottomGrid(UpdateBottomGridDto dto)
        {
            _bottomGridRepository.UpdateBottomGrid(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBottomGrid(int id)
        {
            _bottomGridRepository.DeleteBottomGrid(id);
            return Ok();
        }
    }
}

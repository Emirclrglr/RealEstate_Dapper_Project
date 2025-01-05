using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.SerivceDtos;
using RealEstate_Dapper_Api.Repositories.ServiceRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var values = await _serviceRepository.GetAllServicesAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var values = await _serviceRepository.GetServiceByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateService(CreateServiceDto dto)
        {
            _serviceRepository.CreateServiceAsync(dto);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            _serviceRepository.DeleteService(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateService(UpdateServiceDto dto)
        {
            _serviceRepository.UpdateService(dto);
            return Ok();
        }
    }
}

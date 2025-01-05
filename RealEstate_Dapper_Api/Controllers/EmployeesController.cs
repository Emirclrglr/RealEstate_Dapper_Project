using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            var values = await _employeeRepository.GetAllEmployees();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var values = await _employeeRepository.GetEmployeeById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateEmployee(CreateEmployeeDto dto)
        {
            _employeeRepository.CreateEmployee(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateEmployee(UpdateEmployeeDto dto)
        {
            _employeeRepository.UpdateEmployee(dto);
            return Ok();
        }


    }
}

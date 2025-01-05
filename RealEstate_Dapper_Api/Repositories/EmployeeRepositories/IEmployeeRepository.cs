using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<ResultEmployeeDto>> GetAllEmployees();
        void CreateEmployee(CreateEmployeeDto dto);
        void UpdateEmployee(UpdateEmployeeDto dto);
        void DeleteEmployee(int id);
        Task<GetEmployeeByIdDto> GetEmployeeById(int id);
        
    }
}

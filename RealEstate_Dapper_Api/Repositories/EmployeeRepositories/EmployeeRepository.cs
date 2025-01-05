using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async void CreateEmployee(CreateEmployeeDto dto)
        {
            string query = "Insert into Employees (Name, Title, Mail, PhoneNumber, ImageUrl, Status) Values (@name, @title, @mail, @phoneNumber, @imageUrl, @status)";
            var @params = new DynamicParameters();
            @params.Add("@name", dto.Name);
            @params.Add("@title", dto.Title);
            @params.Add("@mail", dto.Mail);
            @params.Add("@phoneNumber", dto.PhoneNumber);
            @params.Add("@imageUrl", dto.ImageUrl);
            @params.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }

        public async void DeleteEmployee(int id)
        {
            string query = "Delete From Employees Where EmployeeId = @id";
            var @params = new DynamicParameters();
            @params.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }

        public async Task<IEnumerable<ResultEmployeeDto>> GetAllEmployees()
        {
            string query = "Select * From Employees";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetEmployeeByIdDto> GetEmployeeById(int id)
        {
            string query = "Select * From Employees Where EmployeeId = @id";
            var @params = new DynamicParameters();
            @params.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetEmployeeByIdDto>(query, @params);
                return values;
            }
        }

        public async void UpdateEmployee(UpdateEmployeeDto dto)
        {
            string query = "Update Employees Set Name = @name, Title = @title, Mail = @mail, PhoneNumber = @phoneNumber, ImageUrl = @imageUrl Where EmployeeId = @id";
            var @params = new DynamicParameters();
            @params.Add("@id", dto.EmployeeId);
            @params.Add("@name", dto.Name);
            @params.Add("@title", dto.Title);
            @params.Add("@mail", dto.Mail);
            @params.Add("@phoneNumber", dto.PhoneNumber);
            @params.Add("@imageUrl", dto.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }
    }
}

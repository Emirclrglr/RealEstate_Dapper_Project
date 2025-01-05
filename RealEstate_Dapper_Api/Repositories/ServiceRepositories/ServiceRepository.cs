using Dapper;
using RealEstate_Dapper_Api.Dtos.SerivceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async void CreateServiceAsync(CreateServiceDto dto)
        {
            string query = "Insert into Services (ServiceName, ServiceStatus) values (@p1, @p2)";
            var @params = new DynamicParameters();
            @params.Add("@p1", dto.ServiceName);
            @params.Add("@p2", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }

        public async void DeleteService(int id)
        {
            string query = "Delete Services Where Id = @id";
            var @params = new DynamicParameters();
            @params.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }

        public async Task<IEnumerable<ResultServiceDto>> GetAllServicesAsync()
        {
            string query = "Select * From Services";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdServiceDto> GetServiceByIdAsync(int id)
        {
            string query = "Select * From Services Where Id = @id";
            var @params = new DynamicParameters();
            @params.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdServiceDto>(query, @params);
                return values;
            }
        }

        public async void UpdateService(UpdateServiceDto dto)
        {
            string query = "Update Services SET ServiceName = @p1 Where Id = @id";
            var @params = new DynamicParameters();
            @params.Add("@p1", dto.ServiceName);
            @params.Add("@id", dto.Id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }
    }
}

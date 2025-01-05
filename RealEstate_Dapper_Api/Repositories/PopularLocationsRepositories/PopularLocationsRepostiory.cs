using Dapper;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Data;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationsRepositories
{
    public class PopularLocationsRepostiory : IPopularLocationsRepository
    {
        private readonly Context _context;

        public PopularLocationsRepostiory(Context context)
        {
            _context = context;
        }

        public async void CreatePopularLocation(CreatePopularLocationsDto dto)
        {
            string query = "Insert into PopularLocations (City, ImageUrl) values (@p1, @p2)";
            var @params = new DynamicParameters();
            @params.Add("@p1", dto.City);
            @params.Add("@p2", dto.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }

        public async void DeletePopularLocation(int id)
        {
            string query = "Delete PopularLocations Where Id = @id";
            var @params = new DynamicParameters();
            @params.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }

        public async Task<GetPopularLocationsByIdDto> GetPopularLocationsByIdAsync(int id)
        {
            string query = "Select * From PopularLocations Where Id = @id";
            var @params = new DynamicParameters();
            @params.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetPopularLocationsByIdDto>(query, @params);
                return values;
            }
        }

        public async Task<IEnumerable<ResultPopularLocationsDto>> GetAllPopularLocationsAsync()
        {
            var query = "Select * From PopularLocations";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultPopularLocationsDto>(query);
                return result.ToList();
            }
        }

        public async void UpdatePopularLocation(UpdatePopularLocationsDto dto)
        {
            string query = "Update PopularLocations Set City = @p1, ImageUrl = @p2 Where Id = @id";
            var @params = new DynamicParameters();
            @params.Add("@p1", dto.City);
            @params.Add("@p2", dto.ImageUrl);
            @params.Add("@id", dto.Id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }
    }
}

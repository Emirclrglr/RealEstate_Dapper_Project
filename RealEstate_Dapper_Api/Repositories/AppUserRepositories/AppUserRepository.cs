using Dapper;
using RealEstate_Dapper_Api.Dtos.AppUserDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResultAppUserDto>> GetAllAppUsers()
        {
            string query = "Select * From AppUsers";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAppUserDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetAppUserByProductIdDto> GetAppUserByProductId(int id)
        {
            string query = "Select u.UserId, u.Name, u.Email, u.ImageUrl, u.PhoneNumber From Products as p Inner Join AppUsers as u ON u.UserId = p.AppUserId Where p.AppUserId = u.UserId and ProductId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetAppUserByProductIdDto>(query, parameters);
                return value;
            }
        }

        public async Task<IEnumerable<ResultProductDto>> GetLast3ListingOfAppUser(int id)
        {
            string query = "Select top(3) * From Products as p Inner Join AppUsers as u ON u.UserId = p.AppUserId Where AppUserId = @id Order By ProductId Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}

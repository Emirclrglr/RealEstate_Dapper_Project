using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories
{
    public class Last5ProductsRepository : ILast5ProductsRepository
    {
        private readonly Context _context;

        public Last5ProductsRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResultProductWithRelationsDto>> GetLast5ProductByEmployeeId(int id)
        {
            string query = "SELECT top(5) * FROM Products Where EmployeeId = @id order by ProductId desc ";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithRelationsDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}

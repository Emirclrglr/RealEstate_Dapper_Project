using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories
{
    public interface ILast5ProductsRepository
    {
        Task<IEnumerable<ResultProductWithRelationsDto>> GetLast5ProductByEmployeeId(int id);
    }
}

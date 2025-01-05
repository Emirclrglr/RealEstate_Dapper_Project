using RealEstate_Dapper_Api.Dtos.AppUserDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepositories
{
    public interface IAppUserRepository
    {
        Task<GetAppUserByProductIdDto> GetAppUserByProductId(int id);
        Task<IEnumerable<ResultAppUserDto>> GetAllAppUsers();
        Task<IEnumerable<ResultProductDto>> GetLast3ListingOfAppUser(int id);
    }
}

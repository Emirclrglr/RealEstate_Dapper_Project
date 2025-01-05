using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationsRepositories
{
    public interface IPopularLocationsRepository
    {
        Task<IEnumerable<ResultPopularLocationsDto>> GetAllPopularLocationsAsync();
        void CreatePopularLocation(CreatePopularLocationsDto popularLocationsDto);
        void UpdatePopularLocation(UpdatePopularLocationsDto popularLocationsDto);
        void DeletePopularLocation(int id);
        Task<GetPopularLocationsByIdDto> GetPopularLocationsByIdAsync(int id);
    }
}

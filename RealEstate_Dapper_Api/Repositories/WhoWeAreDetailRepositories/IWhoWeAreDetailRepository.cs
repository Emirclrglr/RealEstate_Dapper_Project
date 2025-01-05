using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepositories
{
    public interface IWhoWeAreDetailRepository
    {
        Task<IEnumerable<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync();
        Task<ResultWhoWeAreDetailDto> GetFirstWhoWeAreDetailAsync();
        void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto dto);
        void DeleteWhoWeAreDetail(int id);
        void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto dto);
        Task<GetByIdWhoWeAreDetailDto> GetByIdWhoWeAreDetail(int id);

    }
}

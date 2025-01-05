using RealEstate_Dapper_Api.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<IEnumerable<ResultBottomGridDto>> GetAllBottomGridAsync();
        void CreateBottomGrid(CreateBottomGridDto dto);
        void DeleteBottomGrid(int id);
        void UpdateBottomGrid(UpdateBottomGridDto dto);
        Task<GetBottomGridByIdDto> GetBottomGridByIdAsync(int id);
    }
}

using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.SerivceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<ResultServiceDto>> GetAllServicesAsync();
        void CreateServiceAsync(CreateServiceDto dto);
        void DeleteService(int id);
        void UpdateService(UpdateServiceDto dto);
        Task<GetByIdServiceDto> GetServiceByIdAsync(int id);
    }
}

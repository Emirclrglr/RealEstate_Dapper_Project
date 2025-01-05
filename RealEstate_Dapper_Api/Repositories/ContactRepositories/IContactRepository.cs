using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<ResultContactDto>> GetAllContactAsync();
        Task<IEnumerable<Last4ContactResultDto>> GetLast4ContactAsync();
        void CreateContact(CreateContactDto dto);
        void DeleteContact(int id);
        Task<GetContactByIdDto> GetContactByIdAsync(int id);
    }
}

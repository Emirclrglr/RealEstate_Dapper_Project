using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<IEnumerable<ResultToDoListDto>> GetAllToDoList();
        void CreateToDoList(CreateToDoListDto dto);
        void UpdateToDoList(UpdateToDoListDto dto);
        void DeleteToDoList(int id);
        Task<GetToDoListByIdDto> GetToDoListById(int id);
    }
}

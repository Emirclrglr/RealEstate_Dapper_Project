using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategoryAsync(CreateCategoryDto dto);
        void DeleteCategory(int id);
        void UpdateCategory(UpdateCategoryDto dto);
        Task<ResultCategoryDto> GetCategoryByIdAsync(int id);
    }
}

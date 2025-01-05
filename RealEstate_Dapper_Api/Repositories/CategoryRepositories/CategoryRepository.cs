using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategoryAsync(CreateCategoryDto dto)
        {
            string query = "Insert into Categories (CategoryName, CategoryStatus) values (@categoryName, @categoryStatus)";
            var @params = new DynamicParameters();
            @params.Add("@categoryName", dto.CategoryName);
            @params.Add("@categoryStatus", true);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "Delete From Categories where CategoryId = @categoryId";
            var @params = new DynamicParameters();
            @params.Add("@categoryId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }

        public async Task<IEnumerable<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Categories";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }

        }

        public async Task<ResultCategoryDto> GetCategoryByIdAsync(int id)
        {
            string query = "Select * From Categories Where CategoryId = @categoryId";
            var @params = new DynamicParameters();
            @params.Add("@categoryId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultCategoryDto>(query, @params);
                return values;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto dto)
        {
            string query = "Update Categories Set CategoryName = @categoryName, CategoryStatus = @categoryStatus Where CategoryId = @categoryId";
            var @params = new DynamicParameters();
            @params.Add("@categoryName", dto.CategoryName);
            @params.Add("@categoryStatus", dto.CategoryStatus);
            @params.Add("@categoryId", dto.CategoryId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }

        }
    }
}

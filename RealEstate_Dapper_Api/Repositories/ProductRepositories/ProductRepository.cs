using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async void CreateProduct(CreateProductDto dto)
        {
            string query = "Insert into Products (ProductTitle, Price, CoverImg, City, District, Address, Description, Type, CategoryId, AppUserId, IsDealOfTheDay, ListingDate, ProductStatus) Values (@productTitle, @price, @coverImg, @city, @district, @address, @description, @type, @categoryId, @appUserId, @isDealOfTheDay, @listingDate, @productStatus)";
            var @params = new DynamicParameters();
            @params.Add("@productTitle", dto.ProductTitle);
            @params.Add("@price", dto.Price);
            @params.Add("@coverImg", dto.CoverImg);
            @params.Add("@city", dto.City);
            @params.Add("@district", dto.District);
            @params.Add("@address", dto.Address);
            @params.Add("@description", dto.Description);
            @params.Add("@type", dto.Type);
            @params.Add("@categoryId", dto.CategoryId);
            @params.Add("@appUserId", dto.AppUserId);
            @params.Add("@isDealOfTheDay", false);
            @params.Add("@productStatus", true);
            @params.Add("@listingDate", DateTime.Parse(DateTime.Now.ToShortDateString()));
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }

        public async void DealfOfTheDayActive(int id)
        {
            string query = "Update Products Set IsDealOfTheDay = @p1 Where ProductId = @id";
            var @params = new DynamicParameters();
            @params.Add("@p1", true);
            @params.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }

        public async void DealfOfTheDayPassive(int id)
        {
            string query = "Update Products Set IsDealOfTheDay = @p1 Where ProductId = @id";
            var @params = new DynamicParameters();
            @params.Add("@p1", false);
            @params.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }

        public async void DeleteProduct(int id)
        {
            string query = "Delete From Products Where ProductId = @id";
            var @params = new DynamicParameters();
            @params.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }

        public async Task<IEnumerable<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Products";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<IEnumerable<ResultProductWithRelationsDto>> GetAllProductWithRelationsAsync()
        {
            string query = "Select * From Products as p INNER JOIN Categories as c ON c.CategoryId = p.CategoryId INNER JOIN AppUsers as e ON e.UserId = p.AppUserId";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithRelationsDto>(query);
                return values.ToList();
            }
        }

        public async Task<IEnumerable<ResultProductWithRelationsDto>> GetFalseProductsByEmployeeId(int id)
        {
            string query = "Select * From Products p Inner join Categories c ON c.CategoryId = p.CategoryId Inner join AppUsers e ON e.UserId = p.AppUserId Where p.AppUserId = @id and ProductStatus = 0";
            var @params = new DynamicParameters();
            @params.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithRelationsDto>(query, @params);

                return values.ToList();

            }
        }

        public async Task<IEnumerable<ResultProductWithRelationsDto>> GetLast5ProductListing()
        {
            string query = "SELECT top(5) * FROM Products order by ProductId desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithRelationsDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultProductWithRelationsDto> GetProductByIdAsync(int id)
        {
            string query = "Select * From Products as p Inner join Categories as c ON c.CategoryId = p.CategoryId Inner join AppUsers as e ON e.UserId = p.AppUserId Where ProductId = @id;";
            var @params = new DynamicParameters();
            @params.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultProductWithRelationsDto>(query, @params);
                return values;
            }
        }

        public async Task<IEnumerable<ResultProductWithRelationsDto>> GetProductByIsDealOfTheDayTrue()
        {
            string query = "SELECT * FROM Products as p Inner Join Categories as c ON p.CategoryId = c.CategoryId Inner Join AppUsers as a ON p.AppUserId = a.UserId Where IsDealOfTheDay = 1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithRelationsDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultGetProductDetailByIdDto> GetProductDetailByProductId(int id)
        {
            string query = "Select * from ProductDetails pd Inner join Products p ON pd.ProductID = p.ProductId Where p.ProductId = @id";
            var @params = new DynamicParameters();
            @params.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultGetProductDetailByIdDto>(query, @params);
                return values;

            }
        }

        public async Task<IEnumerable<ResultProductWithRelationsDto>> GetTrueProductsByEmployeeId(int id)
        {
            string query = "Select * From Products p Inner join Categories c ON c.CategoryId = p.CategoryId Inner join AppUsers e ON e.UserId = p.AppUserId Where p.AppUserId = @id and ProductStatus = 1";
            var @params = new DynamicParameters();
            @params.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithRelationsDto>(query, @params);

                return values.ToList();

            }
        }

        public async Task<IEnumerable<ResultProductWithRelationsDto>> Last3Listings()
        {
            string query = "Select Top(3) * From Products p  Inner Join Categories c ON p.CategoryId = c.CategoryId Inner Join AppUsers a ON p.AppUserId = UserId Order By ProductId Desc ";
            var @params = new DynamicParameters();
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithRelationsDto>(query, @params);
                return values.ToList();
            }
        }

        public async Task<IEnumerable<ResultProductWithRelationsDto>> ResultProductByFilter(string keyword, int propertyCategoryId, string city)
        {
            string query = "SELECT * FROM Products p INNER JOIN Categories c ON p.CategoryId = c.CategoryId INNER JOIN AppUsers a ON p.AppUserId = a.UserId WHERE p.ProductTitle LIKE @Keyword AND p.CategoryId = @PropertyCategoryId AND p.City LIKE @City";
            var @params = new DynamicParameters();
            @params.Add("@Keyword", $"%{keyword}%");
            @params.Add("@PropertyCategoryId", propertyCategoryId);
            @params.Add("@City", $"%{city}%");
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithRelationsDto>(query, @params);
                return values.ToList();
            }
        }

        public async void UpdateProduct(UpdateProductDto dto)
        {
            string query = "Update Products Set ProductTitle = @productTitle, Price = @price, CoverImg = @coverImg, City = @city, District = @district, Address = @address, Description = @description, Type = @type, CategoryId = @categoryId, AppUserId = @appUserId, IsDealOfTheDay = @isDealOfTheDay, ListingDate = @listingDate Where ProductId = @id";
            var @params = new DynamicParameters();
            @params.Add("@id", dto.ProductId);
            @params.Add("@productTitle", dto.ProductTitle);
            @params.Add("@price", dto.Price);
            @params.Add("@coverImg", dto.CoverImg);
            @params.Add("@city", dto.City);
            @params.Add("@district", dto.District);
            @params.Add("@address", dto.Address);
            @params.Add("@description", dto.Description);
            @params.Add("@type", dto.Type);
            @params.Add("@categoryId", dto.CategoryId);
            @params.Add("@appUserId", dto.AppUserId);
            @params.Add("@isDealOfTheDay", dto.IsDealOfTheDay);
            @params.Add("@listingDate", dto.ListingDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }
    }
}

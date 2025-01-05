using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public async void CreateBottomGrid(CreateBottomGridDto dto)
        {
            var query = "Insert into BottomGrid (BottomGridTitle, BottomGridDescription, BottomGridIcon) Values (@p1, @p2, @p3)";
            var @params = new DynamicParameters();
            @params.Add("@p1", dto.BottomGridTitle);
            @params.Add("@p2", dto.BottomGridDescription);
            @params.Add("@p3", dto.BottomGridIcon);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }

        public async void DeleteBottomGrid(int id)
        {
            string query = "Delete BottomGrid Where BottomGridId = @id";
            var @params = new DynamicParameters();
            @params.Add("@id", id);
            using (var connecttion =  _context.CreateConnection())
            {
                await connecttion.ExecuteAsync(query, @params);
            }
        }

        public async Task<IEnumerable<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            var query = "Select * From BottomGrid";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultBottomGridDto>(query);
                return result.ToList();
            }
        }

        public async Task<GetBottomGridByIdDto> GetBottomGridByIdAsync(int id)
        {
            string query = "Select * From BottomGrid Where BottomGridId = @id";
            var @params = new DynamicParameters();
            @params.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetBottomGridByIdDto>(query, @params);
                return value;
            }
        }

        public async void UpdateBottomGrid(UpdateBottomGridDto dto)
        {
            string query = "Update BottomGrid SET BottomGridTitle = @p1, BottomGridDescription = @p2, BottomGridIcon = @p3 Where BottomGridId = @id";
            var @params = new DynamicParameters();
            @params.Add("@id", dto.BottomGridId);
            @params.Add("@p1", dto.BottomGridTitle);
            @params.Add("@p2", dto.BottomGridDescription);
            @params.Add("@p3", dto.BottomGridIcon);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }
    }
}

using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepositories
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto dto)
        {
            string query = "Insert into WhoWeAreDetail (Title, Subtitle, Description1, Description2) values (@title, @subtitle, @desc1, @desc2)";
            var @params = new DynamicParameters();
            @params.Add("@title", dto.Title);
            @params.Add("@subtitle", dto.Subtitle);
            @params.Add("@desc1", dto.Description1);
            @params.Add("@desc2", dto.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            string query = "Delete from WhoWeAreDetail where Id = @id";
            var @params = new DynamicParameters();
            @params.Add("id", id);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }

        public async Task<IEnumerable<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "Select * From WhoWeAreDetail";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdWhoWeAreDetailDto> GetByIdWhoWeAreDetail(int id)
        {
            string query = "Select * From WhoWeAreDetail Where Id = @id";
            var @params = new DynamicParameters();
            @params.Add("id", id);
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto>(query, @params);
                return values;
            }
        }

        public async Task<ResultWhoWeAreDetailDto> GetFirstWhoWeAreDetailAsync()
        {
            string query = "Select * From WhoWeAreDetail";
            using(var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<ResultWhoWeAreDetailDto>(query);
                return value;
            }
        }

        public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto dto)
        {
            string query = "Update WhoWeAreDetail Set Title = @title, Subtitle = @subtitle, Description1 = @desc1, Description2 = @desc2 Where Id = @id";
            var @params = new DynamicParameters();
            @params.Add("@id", dto.Id);
            @params.Add("@title", dto.Title);
            @params.Add("@subtitle", dto.Subtitle);
            @params.Add("@desc1", dto.Description1);
            @params.Add("@desc2", dto.Description2);
            using( var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }
    }
}

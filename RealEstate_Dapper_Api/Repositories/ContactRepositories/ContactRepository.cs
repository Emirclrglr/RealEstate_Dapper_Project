using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }

        public async void CreateContact(CreateContactDto dto)
        {
            string query = "Insert into Contact (Name, Subject, Email, Message, SendDate) values (@p1, @p2, @p3, @p4, @p5)";
            var @params = new DynamicParameters();
            @params.Add("@p1", dto.Name);
            @params.Add("@p2", dto.Subject);
            @params.Add("@p3", dto.Email);
            @params.Add("@p4", dto.Message);
            @params.Add("@p5", DateTime.Parse(DateTime.Now.ToShortDateString()));
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, @params);
            }
        }

        public async void DeleteContact(int id)
        {
            string query = "Delete From Contact Where Id = @id";
            var @params = new DynamicParameters();
            @params.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(@query, @params);
            }
        }

        public async Task<IEnumerable<ResultContactDto>> GetAllContactAsync()
        {
            string query = "Select * From Contact";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultContactDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetContactByIdDto> GetContactByIdAsync(int id)
        {
            string query = "Select * From Contact Where Id = @id";
            var @params = new DynamicParameters();
            @params.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetContactByIdDto>(query, @params);
                return values;
            }
        }

        public async Task<IEnumerable<Last4ContactResultDto>> GetLast4ContactAsync()
        {
            string query = "Select top(4) * From Contact order by Id Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<Last4ContactResultDto>(query);
                return values.ToList();
            }
        }
    }
}

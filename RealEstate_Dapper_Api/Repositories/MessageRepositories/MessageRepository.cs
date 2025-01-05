using Dapper;
using RealEstate_Dapper_Api.Dtos.MessageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResultInBoxDto>> GetLast3InBoxMessagesByReceiver(int id)
        {
            string query = "Select top(3) * From Messages Where ReceiverId = @id Order by MessageId desc";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInBoxDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<IEnumerable<ResultInBoxWithRelationsDto>> GetLast3InBoxMessagesByReceiverWithRelations(int id)
        {
            string query = "Select top(3) MessageId, Subject, MessageBody, SendDate, Name, Email, ImageUrl From Messages Inner join AppUsers ON UserId = SenderId Where ReceiverId = @id Order by MessageId Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInBoxWithRelationsDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}

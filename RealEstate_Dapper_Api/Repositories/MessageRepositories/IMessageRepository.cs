using RealEstate_Dapper_Api.Dtos.MessageDtos;

namespace RealEstate_Dapper_Api.Repositories.MessageRepositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<ResultInBoxDto>> GetLast3InBoxMessagesByReceiver(int id);
        Task<IEnumerable<ResultInBoxWithRelationsDto>> GetLast3InBoxMessagesByReceiverWithRelations(int id);
    }
}

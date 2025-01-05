using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.MessageRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLast3InBoxMessagesByReceiver(int id)
        {
            var values = await _messageRepository.GetLast3InBoxMessagesByReceiver(id);
            return Ok(values);
        }

        [HttpGet("GetLast3InBoxMessagesByReceiverWithRelations/{id}")]
        public async Task<IActionResult> GetLast3InBoxMessagesByReceiverWithRelations(int id)
        {
            var values = await _messageRepository.GetLast3InBoxMessagesByReceiverWithRelations(id);
            return Ok(values);
        }
    }
}

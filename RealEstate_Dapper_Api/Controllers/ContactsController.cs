using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Repositories.ContactRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
            => Ok(await _contactRepository.GetAllContactAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
            => Ok(await _contactRepository.GetContactByIdAsync(id));

        [HttpGet("Last4Message")]
        public async Task<IActionResult> Last4Message()
            => Ok(await _contactRepository.GetLast4ContactAsync());

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto dto)
        {
            _contactRepository.CreateContact(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            _contactRepository.DeleteContact(id);
            return Ok();
        }
    }
}

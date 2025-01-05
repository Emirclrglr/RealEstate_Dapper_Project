using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.AppUserRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUsersController(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserByProductId(int id)
        {
            var value = await _appUserRepository.GetAppUserByProductId(id);
            return Ok(value);
        }

        [HttpGet("GetAllAppUsers")]
        public async Task<IActionResult> GetAllAppUsers()
        {
            var values = await _appUserRepository.GetAllAppUsers();
            return Ok(values);
        }

        [HttpGet("GetLast3ListingOfAppUser/{id}")]
        public async Task<IActionResult> GetLast3ListingOfAppUser(int id)
        {
            var values = await _appUserRepository.GetLast3ListingOfAppUser(id);
            return Ok(values);
        }
    }
}

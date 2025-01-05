using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.LoginDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto dto)
        {
            string query = "Select * from AppUsers Where Username = @username and Password = @password";
            var parameters = new DynamicParameters();
            parameters.Add("@username", dto.Username);
            parameters.Add("@password", dto.Password);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query, parameters);
                if (values != null)
                {
                    CheckUserViewModel model = new CheckUserViewModel();
                    model.Username = values.Username;
                    model.UserId = values.UserId;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized("Giriş Başarısız");
                }
            }
        }
    }
}


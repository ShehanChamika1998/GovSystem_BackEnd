using GovSystem.Business.Entities;
using GovSystem.Business.Services.Users;
using GovSystem.Common.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GovSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _user;
        public UsersController(IUserService user)
        {
            _user = user;
        }

        [HttpPost("User_Creations")]
        public async Task<IActionResult> InsertUser([FromBody] User request)
        {
            var data = await _user.CreateUser(request);

            if (data == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred" });
            }

            return Ok(data);
        }

        [HttpPost("User_Login")]
        public async Task<dynamic> LoginUser([FromBody] UserLoginDto req)
        {
            var data = await _user.LoginUser(req);
            if (data.RetValue == 2)
            {
               return Unauthorized(new { message = "Invalid Credentials" });
            }
            return Ok(data);
        }
    }
}

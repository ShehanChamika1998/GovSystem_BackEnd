using GovSystem.Business.Entities;
using GovSystem.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GovSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUser _user;
        public UsersController(IUser user)
        {
            _user = user;
        }

        [HttpPost("User_Creations")]
        public async Task<IActionResult> InsertProject([FromBody] User request)
        {
            var data = await _user.CreateUser(request);

            if (data == null)
            {
                return Unauthorized(new { message = "Failed to update!" });
            }

            return Ok(data);
        }
    }
}

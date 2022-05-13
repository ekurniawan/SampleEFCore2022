using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyIdentityServer.Data;
using MyIdentityServer.DTO;

namespace MyIdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpPost]
        public async Task<ActionResult> Registration(CreateUserDto user)
        {
            try
            {
                await _user.Registration(user);
                return Ok($"Registrasi user {user.Username} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Authenticate(CreateUserDto createUserDto)
        {
            try
            {
                var user = await _user.Authenticate(createUserDto.Username, createUserDto.Password);
                if (user == null)
                    return BadRequest("Username/Pass not match");
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Contracts.Persistence;
using WebApi.Modules.Dtos;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository _userRepository) : ControllerBase
    {
      
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDtos userDTO)
        {
            var response = await _userRepository.CreateAccount(userDTO);
            return Ok(response);
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> authenticate(LoginDTO loginDTO)
        {
            var response = await _userRepository.LoginAccount(loginDTO);
            return Ok(response);
        }
    }
}

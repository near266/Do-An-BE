using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Contracts.Persistence;
using WebApi.Modules.Dtos;
using WebApi.Wrappers.DTOS.EmailDtos;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository _userRepository) : ControllerBase
    {
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest model)
        {
            await _userRepository.ForgotPassword(model, Request.Headers["origin"]);
            return Ok();
        }
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
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest model)
        {

            return Ok(await _userRepository.ResetPassword(model));
        }
    }
}

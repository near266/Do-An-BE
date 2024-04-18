
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Security.Claims;

namespace WebApi.Controllers
{
 
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {

        private readonly ILogger<PingController> _logger;
     
        private readonly IConfiguration _configuration;
      

        public PingController(ILogger<PingController> logger,IConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            
           
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        

        [HttpGet("ping")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Get()
        {
            _logger.LogInformation($"REST request to ping : ");
            try
            {
              
              

                return Ok("ok");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private string? GetUserIdFromConext()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        private string? GetRoleFromContext()
        {
            return User.FindFirst(ClaimTypes.Role)?.Value;
        }
    }
}
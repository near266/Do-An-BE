using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;
using WebApi.Application.Command.EnterpriseC;
using WebApi.Application.Command.UserInfoC;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos.EnterpriseDTO;
using WebApi.Application.Models.Dtos.Userinfo;
using WebApi.Application.Queries.EnterpriseQ;
using WebApi.Application.Queries.UserInfoQ;
using WebApi.Modules.Dtos;
using WebApi.Wrappers.DTOS.UserInfoDtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly ILogger<UserInfoController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

      public UserInfoController(ILogger<UserInfoController> logger, IConfiguration configuration, IMediator mediator, IUserRepository userRepository, IMapper mapper)
        {
            _logger = logger;
            _configuration = configuration;
            _mediator = mediator;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        private string? GetUserIdFromConext()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        private string? GetRoleFromContext()
        {
            return User.FindFirst(ClaimTypes.Role)?.Value;
        }

        #region Enterpriese
        [HttpPost("Enterprise/Detail")]

        public async Task<IActionResult> EnterpriseDetail([FromBody]ViewDetailEnterpriseQuery rq)
        {
            _logger.LogInformation($"Excute request to  EnterpriseCreate : {rq}");

            try
            {
                
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller had problem when running", ex);
            }

        }
        [HttpPut("Enterprise/Update")]

        public async Task<IActionResult> EnterpriseUpdate([FromBody] UpdateEnterpiseRequest rq)
        {
            _logger.LogInformation($"Excute request to  EnterpriseCreate : {rq}");

            try
            {
                var rquest = new UpdateEnterpriseCommand();
                var map = _mapper.Map<EnterpriseDTO>(rq);
                 rquest.EnterpriseDTO = map;

                var res = await _mediator.Send(rquest);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller had problem when running", ex);
            }

        }
        [HttpPut("Enterprise/Update-AccountInfo")]

        public async Task<IActionResult> EnterpriseUpdateAvatar([FromBody] UpdateInfoEnterprise rq)
        {
            _logger.LogInformation($"Excute request to  EnterpriseCreate : {rq}");

            try
            {
                var rquest = new UpdateEnterpriseCommand();
                var map = _mapper.Map<EnterpriseDTO>(rq);
                rquest.EnterpriseDTO = map;

                var res = await _mediator.Send(rquest);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller had problem when running", ex);
            }

        }
        [HttpPost("Enterprise/Create")]

        public async Task<IActionResult> EnterpriseCreate([FromBody] RegisterEnterprise rq)
        {
            _logger.LogInformation($"Excute request to  EnterpriseCreate : {rq}");

            try
            {
                var mapUser = _mapper.Map<UserDtos>(rq);
                await _userRepository.CreateAccountEnterprise(mapUser);
                var mapUserInfo = _mapper.Map<EnterpriseDTO>(rq);
                var user = await _userRepository.GetUserByUserName(rq.UserName);
                var rqCreate = new CreateEnterpriseCommand();


                mapUserInfo.account_id = user.Data.Id;

                rqCreate.EnterpriseDTO = mapUserInfo;
                var res = await _mediator.Send(rqCreate);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller had problem when running", ex);
            }

        }
        #endregion
        [HttpPost("UserInfo/Create")]
       
        public async Task<IActionResult> UserInfoCreate([FromBody] RegisterUserInfo rq)
        {
            _logger.LogInformation($"Excute request to  UserInfoCreate : {rq}");

            try
            {
                var mapUser = _mapper.Map<UserDtos>(rq);
                 await _userRepository.CreateAccount(mapUser);
                var user=  await _userRepository.GetUserByUserName(rq.UserName);
                var rqCreate = new CreateUserInfoCommand();
              
                var mapUserInfo = _mapper.Map<UserInfoDTO>(rq);

                mapUserInfo.Account_id = user.Data.Id;

                rqCreate.user = mapUserInfo;
                var res = await _mediator.Send(rqCreate);
                return Ok(res);
            }catch (Exception ex)
            {
                throw new Exception("Controller had problem when running",ex);
            }

        }
        [HttpGet("auth/me")]

        public async Task<IActionResult> userInfoDetail([FromQuery] ViewDetailUserInfoQuery rq)
        {
            _logger.LogInformation($"Excute request to  UserInfoCreate : {rq}");

            try
            {
               
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller had problem when running", ex);
            }

        }
        [HttpPut("UserInfo/Update")]

        public async Task<IActionResult> UpdateUserInfo([FromBody] UpdateUserInfoCommand rq)
        {
            _logger.LogInformation($"Excute request to  UserInfoCreate : {rq}");

            try
            {

                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller had problem when running", ex);
            }

        }
        [HttpPost("UserInfo/ViewAll")]

        public async Task<IActionResult> ViewAllUserInfo([FromBody] ViewAllUserInfoQuery rq)
        {
            _logger.LogInformation($"Excute request to  UserInfoCreate : {rq}");

            try
            {

                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller had problem when running", ex);
            }

        }
    }
}

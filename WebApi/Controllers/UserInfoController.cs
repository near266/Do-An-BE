using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;
using WebApi.Application.Command.EnterpriseC;
using WebApi.Application.Command.UserInfoC;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos;
using WebApi.Application.Models.Dtos.EnterpriseDTO;
using WebApi.Application.Models.Dtos.Userinfo;
using WebApi.Application.Queries.EnterpriseQ;
using WebApi.Application.Queries.UserInfoQ;
using WebApi.Modules.Dtos;
using WebApi.Shared.Constants;
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
        [HttpPost("User/ListUser")]

        public async Task<IActionResult> userListAccount([FromBody] SearchBase rq)
        {
            _logger.LogInformation($"Excute request to  EnterpriseCreate : {rq}");

            try
            {
                var list1 = new List<AccountDTOs>();
                var listrq = new ViewAllUserInfoQuery();
                listrq.status = rq.status;
                listrq.page = rq.page;
                listrq.pageSize = rq.pageSize;
                 var listRes = await _mediator.Send(listrq);

                foreach (var item in listRes.Data)
                {
                    var acount = new AccountDTOs();
                    acount.id = item.Account_id;
                    if (acount.id != null)
                    {

                    acount.avatar = item.avatar;
                    var user = await _userRepository.getUserbyId(item.Account_id);
                    acount.name = user.Data.UserName;
                        acount.status = item.Lock;
                        acount.phone = item.phone;
                        acount.email=user.Data.Email;
                    }
                    list1.Add(acount);
                }
                var result = new PagedList<AccountDTOs>();
                result.Data=list1;
                result.PageSize=rq.pageSize;
                result.Page=rq.page;

                
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller had problem when running", ex);
            }

        }
        [HttpPost("Enterprise/ListEnterprise")]

        public async Task<IActionResult> EnterListAccount([FromBody] SearchBase rq)
        {
            _logger.LogInformation($"Excute request to  EnterpriseCreate : {rq}");

            try
            {
                var list1 = new List<AccountDTOs>();
                var listrq = new ViewAllEnterpriseCommand();
                listrq.status = rq.status;
                listrq.page = rq.page;
                listrq.pageSize = rq.pageSize;
                var listRes = await _mediator.Send(listrq);

                foreach (var item in listRes.Data)
                {
                    var acount = new AccountDTOs();
                    acount.id = item.account_id;
                    if (acount.id != null)
                    {

                        acount.avatar = item.avatar;
                        var user = await _userRepository.getUserbyId(item.account_id);
                        acount.name = user.Data.UserName;
                        acount.status = item.IsLock ==null? 0 : item.IsLock ;
                        acount.phone=item.phone;
                        acount.email=user.Data.Email;
                    }
                    list1.Add(acount);
                }
                var result = new PagedList<AccountDTOs>();
                result.Data = list1;
                result.PageSize = rq.pageSize;
                result.Page = rq.page;


                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller had problem when running", ex);
            }

        }
        [HttpPost("UserInfo/LockAccount")]

        public async Task<IActionResult> UserLockAcc([FromBody] UpdateStatusUserAccountCommand rq)
        {
            _logger.LogInformation($"Excute request to  EnterpriseCreate : {rq}");

            try
            {
                if (rq.status == 1)
                {

                    var lockacc = await _userRepository.LockUser(rq.account_id);
                    if (lockacc == 1)
                    {
                        var res = await _mediator.Send(rq);

                    }

                }
                else
                {
                    var lockacc = await _userRepository.UnLockUser(rq.account_id);
                    if (lockacc == 1)
                    {
                        var res = await _mediator.Send(rq);

                    }

                }
                return Ok(1);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller had problem when running", ex);
            }

        }

        [HttpPost("Enterprise/LockAccount")]

        public async Task<IActionResult> EnterpriseLockAcc([FromBody] UpdateStatusEnterpriseCommand rq)
        {
            _logger.LogInformation($"Excute request to  EnterpriseCreate : {rq}");

            try
            {
                if (rq.status == 1)
                {

                var lockacc = await _userRepository.LockUser(rq.account_id);
                if (lockacc == 1)
                {
                var res = await _mediator.Send(rq);

                }
                    
                }
                else
                {
                    var lockacc = await _userRepository.UnLockUser(rq.account_id);
                    if (lockacc == 1)
                    {
                        var res = await _mediator.Send(rq);

                    }
                 
                }
                return Ok(1);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller had problem when running", ex);
            }

        }
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
        [HttpGet("enteprise/detail")]

        public async Task<IActionResult> EnterpiseByid([FromQuery] ViewEnterrpiseByIdQuery rq)
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

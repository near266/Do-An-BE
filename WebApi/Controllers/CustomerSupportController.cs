using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi.Application.Command;
using WebApi.Application.Command.Customer;
using WebApi.Application.Command.Product;
using WebApi.Application.Command.TeleSale;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos;
using WebApi.Application.Queries.Customer;
using WebApi.Application.Queries.Product;
using WebApi.Application.Queries.TeleSale;
using WebApi.Modules.Dtos;
using WebApi.Wrappers.DTOS;
using ZstdSharp.Unsafe;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSupportController : ControllerBase
    {
        private readonly ILogger<CustomerSupportController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public CustomerSupportController(ILogger<CustomerSupportController> logger, IConfiguration configuration, IMediator mediator, IUserRepository userRepository, IMapper mapper)
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
        [HttpPost("admin/create-sale-account")]
        [Authorize]
        public async Task<IActionResult> createSaleAccount([FromBody] RegisterSale rq)
        {
            var Account = new UserDtos();
            var InfoSale = new CreateTeleSaleCommand();
            Account.UserName = rq.UserName;
            Account.Name = rq.UserName;
            Account.Email = rq.Email;
            Account.Password = rq.Password;
            Account.ConfirmPassword = rq.Password;
            await _userRepository.CreateAccount(Account);
            var rqSale = _mapper.Map<TeleSaleDTO>(rq);
            var user = await _userRepository.GetUserByUserName(Account.UserName);
            rqSale.UserId = user.Data.Id;
            InfoSale.teleSaleDTO = rqSale;
            var response = await _mediator.Send(InfoSale);


            return Ok(response);

        }
        [HttpPost("telesale/detail")]
        [Authorize]
        public async Task<IActionResult> DetailTeleSale([FromBody] ViewDetailTeleSaleQuery rq)
        {

            var response = await _mediator.Send(rq);
            return Ok(response);

        }
        [HttpPost("telesale/list")]
        [Authorize]
        public async Task<IActionResult> ListTeleSale([FromBody] ViewListTeleSaleQueryHandler rq)
        {

            var response = await _mediator.Send(rq);
            return Ok(response);

        }
        [HttpPost("customer/create")]
        [Authorize]
        public async Task<IActionResult> createCustomer([FromBody] CreateCustomerCommand rq)
        {

            var response = await _mediator.Send(rq);
            return Ok(response);

        }
        [HttpPost("customer/update")]
        [Authorize]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand rq)
        {
            _logger.LogInformation("Controoler Update Customer");
            var response = await _mediator.Send(rq);
            return Ok(response);

        }
        [HttpDelete("customer/delete")]
        [Authorize]
        public async Task<IActionResult> DeleteCustomer([FromBody] DeleteCustomerCommand rq)
        {
            _logger.LogInformation("Controller Delete Customer");
            var response = await _mediator.Send(rq);
            return Ok(response);

        }
        [HttpGet("customer/view-detail/{id}")]
        [Authorize]
        public async Task<IActionResult> ViewDetailCustomer([FromRoute] string id)
        {
            _logger.LogInformation("Controller View Detail Customer");
            var rq = new ViewDetailCustomer { Id = id };
            var response = await _mediator.Send(rq);
            return Ok(response);

        }
        [HttpPost("customer/view-list")]
        [Authorize]
        public async Task<IActionResult> ViewListCustomer([FromQuery] ViewListCustomer rq)
        {
            _logger.LogInformation("Controller View List Customer ");
            var response = await _mediator.Send(rq);
            return Ok(response);

        }

        #region Product
        [HttpPost("product/create")]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand rq)
        {
            _logger.LogInformation("Controoler Update Customer");
            var response = await _mediator.Send(rq);
            return Ok(response);

        }
        [HttpPut("product/update")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand rq)
        {
            _logger.LogInformation("Controller UpdateProduct");
            var response = await _mediator.Send(rq);
            return Ok(response);

        }
        [HttpDelete("product/delete")]
        [Authorize]
        public async Task<IActionResult> deleteProduct([FromBody] DeleteProductCommand rq)
        {
            _logger.LogInformation("Controller deleteProduct");
            var response = await _mediator.Send(rq);
            return Ok(response);

        }
        [HttpGet("product/view-detail{id}")]
        [Authorize]
        public async Task<IActionResult> ViewDetailProduct([FromQuery] ViewDetailProductQuery rq)
        {
            _logger.LogInformation("Controller ViewDetailProduct");
            var response = await _mediator.Send(rq);
            return Ok(response);

        }
        #endregion
    }
}

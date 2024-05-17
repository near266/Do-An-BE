using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Command.CareerFieldC;
using WebApi.Application.Command.JobC;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Queries.CareeFieldsQ;
using WebApi.Application.Queries.EnterpriseQ;
using WebApi.Application.Queries.Job_postQ;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CvController : ControllerBase
    {
        private readonly ILogger<UserInfoController> _logger;

        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CvController(ILogger<UserInfoController> logger, IMediator mediator, IUserRepository userRepository, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        #region Job-Post
        [HttpPost("job-post/create")]

        public async Task<IActionResult> jobPostCreate([FromBody] CreateJob_postCommand rq)
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
        [HttpPost("job-post/update")]

        public async Task<IActionResult> jobPostUpdate([FromBody] UpdateJobPostCommand rq)
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
        [HttpPost("job-post/search")]

        public async Task<IActionResult> jobPostSearch([FromBody] SearchJob_postQuery rq)
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
        [HttpDelete("job-post/delete")]

        public async Task<IActionResult> jobPostDelete([FromBody] DeleteJob_postCommand rq)
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
        [HttpGet("job-post/detail")]

        public async Task<IActionResult> jobPostDelete([FromQuery] ViewDetailJob_postQuery rq)
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
        #endregion
        #region Caree
        [HttpPost("Cv/create-careerfields")]

        public async Task<IActionResult> createCareerFields([FromBody] CreateCareerFieldsCommand rq)
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
        [HttpPost("careeFields/detail")]

        public async Task<IActionResult> DetailCareeFields([FromBody] ViewDetailFieldsQuery rq)
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
        [HttpPost("caree/detail")]

        public async Task<IActionResult> DetailCaree([FromBody] ViewDetailCareeQuery rq)
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
        [HttpPost("caree/search")]

        public async Task<IActionResult> searchCaree([FromBody] SearchCareeByFileldIdQuery rq)
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
        [HttpPost("Cv/ViewAll-careerfields")]

        public async Task<IActionResult> ViewAllCareerFields([FromBody] ViewAllCareerFieldsQuery rq)
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
        #endregion
    }
}

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Command.RecordSheet;
using WebApi.Application.Queries.RecordSheet;

namespace WebApi.Controllers
{
    [Route("api/sheets/")]
    [ApiController]
    public class RecordSheetController : ControllerBase
    {
        private readonly ILogger<RecordSheetController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RecordSheetController(ILogger<RecordSheetController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateRecordSheet([FromBody] CreateRecordSheetCommand rq)
        {
            _logger.LogInformation("Create Record Sheet");
            var recordSheet = await _mediator.Send(rq);
            return Ok(recordSheet);
        }

        [HttpPut("update")]
        [Authorize]
        public async Task<IActionResult> UpdateRecordSheet([FromBody] UpdateRecordSheetCommand rq)
        {
            _logger.LogInformation("Update Record Sheet");
            var recordSheet = await _mediator.Send(rq);
            return Ok(recordSheet);
        }

        [HttpGet("view-detail/{id}")]
        [Authorize]
        public async Task<IActionResult> ViewDetailRecordSheet([FromRoute] string id)
        {
            _logger.LogInformation("View Detail Record Sheet");
            var rq = new ViewDetailRecordSheet { Id = Guid.Parse(id) };
            var recordSheet = await _mediator.Send(rq);
            return Ok(recordSheet);
        }

        [HttpPost()]
        [Authorize]
        public async Task<IActionResult> ViewAllRecordSheet([FromBody] ViewListRecordSheet rq)
        {
            _logger.LogInformation("View All Record Sheet");
            var recordSheet = await _mediator.Send(rq);
            return Ok(recordSheet);
        }
    }
}
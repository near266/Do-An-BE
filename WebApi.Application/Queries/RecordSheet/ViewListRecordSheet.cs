using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models;
using WebApi.Application.Models.Dtos;

namespace WebApi.Application.Queries.RecordSheet
{
    public class ViewListRecordSheet : IRequest<Pagination<RecordSheetDTO>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? Code { get; set; }
        public string? TelesaleId { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? Created_date { get; set; }
        public int? Status { get; set; }
    }
    public class ViewListRecordSheetHandler : IRequestHandler<ViewListRecordSheet, Pagination<RecordSheetDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ViewListRecordSheetHandler> _logger;
        private readonly IRecordSheetRepository _repo;

        public ViewListRecordSheetHandler(IMapper mapper, ILogger<ViewListRecordSheetHandler> logger, IRecordSheetRepository repo)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        public async Task<Pagination<RecordSheetDTO>> Handle(ViewListRecordSheet request, CancellationToken cancellationToken)
        {
            var rs = await _repo.ViewListRecordSheet(request.Page, request.PageSize, request.Code, request.TelesaleId, request.CustomerName, request.Created_date, request.Status, cancellationToken);
            var result = _mapper.Map<Pagination<RecordSheetDTO>>(rs);
            return result;
        }
    }
}
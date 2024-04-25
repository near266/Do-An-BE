using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos;

namespace WebApi.Application.Queries.RecordSheet
{
    public class ViewDetailRecordSheet : IRequest<RecordSheetDTO>
    {
        public Guid? Id { get; set; }
    }
    public class ViewDetailRecordSheetHandler : IRequestHandler<ViewDetailRecordSheet, RecordSheetDTO>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ViewDetailRecordSheetHandler> _logger;
        private readonly IRecordSheetRepository _repo;

        public ViewDetailRecordSheetHandler(IMapper mapper, ILogger<ViewDetailRecordSheetHandler> logger, IRecordSheetRepository repo)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        public async Task<RecordSheetDTO> Handle(ViewDetailRecordSheet request, CancellationToken cancellationToken)
        {
            var rs = await _repo.ViewDetailRecordSheet(request.Id, cancellationToken);
            var result = _mapper.Map<RecordSheetDTO>(rs);
            return result;
        }
    }
}
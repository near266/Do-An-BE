using AutoMapper;
using MediatR;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos;

namespace WebApi.Application.Command.RecordSheet
{
    public class UpdateRecordSheetCommand : IRequest<RecordSheetDTO>
    {
        public RecordSheetDTO? RecordSheet { get; set; }
    }

    public class UpdateRecordSheetCommandHandler : IRequestHandler<UpdateRecordSheetCommand, RecordSheetDTO>
    {
        private readonly IMapper _mapper;
        private readonly IRecordSheetRepository _repo;
        public UpdateRecordSheetCommandHandler(IMapper mapper, IRecordSheetRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<RecordSheetDTO> Handle(UpdateRecordSheetCommand request, CancellationToken cancellationToken)
        {
            var recordSheet = await _repo.UpdateRecordSheet(request.RecordSheet, cancellationToken);
            return recordSheet;
        }
    }
}
using AutoMapper;
using MediatR;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos;
using WebApi.Domain.Entites;

namespace WebApi.Application.Command.RecordSheet
{
    public class CreateRecordSheetCommand : IRequest<RecordSheetDTO>
    {
        public RecordSheetDTO? RecordSheet { get; set; }
    }

    public class CreateRecordSheetCommandHandler : IRequestHandler<CreateRecordSheetCommand, RecordSheetDTO>
    {
        private readonly IMapper _mapper;
        private readonly IRecordSheetRepository _repo;
        public CreateRecordSheetCommandHandler(IMapper mapper, IRecordSheetRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<RecordSheetDTO> Handle(CreateRecordSheetCommand request, CancellationToken cancellationToken)
        {
            var recordSheet = await _repo.CreateRecordSheet(request.RecordSheet, cancellationToken);
            return recordSheet;
        }
    }
}
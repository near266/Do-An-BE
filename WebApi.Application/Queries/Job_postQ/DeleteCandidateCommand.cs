using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos;
using WebApi.Shared.Constants;

namespace WebApi.Application.Queries.Job_postQ
{
    public class DeleteCandidateCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand, int>
    {
        private readonly ICustomRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCandidateCommandHandler> _logger;

        public DeleteCandidateCommandHandler(ICustomRepository repo, IMapper mapper, ILogger<DeleteCandidateCommandHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<int> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("UpdateComand");
           
            var cus = await _repo.DeleteCandidate(request.Id);
            return 1;
        }
    }
}

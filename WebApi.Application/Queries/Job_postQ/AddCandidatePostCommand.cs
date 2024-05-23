using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApi.Application.Command.JobC;
using WebApi.Application.Contracts.Persistence;
using WebApi.Domain.Entites.Job;

namespace WebApi.Application.Queries.Job_postQ
{
    public class AddCandidatePostCommand : IRequest<job_post_candidates>
    {
        [JsonIgnore]
        public int? id { get; set; }

        public string? job_post_id { get; set; }
        public string? user_id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? cv_path { get; set; }
        public int? status_id { get; set; }
        public DateTime? created_at { get; set; }
    }
    public class  AddCandidatePostCommandHandler : IRequestHandler< AddCandidatePostCommand, job_post_candidates>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger< AddCandidatePostCommandHandler> _logger;

        public  AddCandidatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger< AddCandidatePostCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<job_post_candidates> Handle( AddCandidatePostCommand request, CancellationToken cancellationToken)
        {

            var map = _mapper.Map<job_post_candidates>(request);


            await _unitOfWork.ExecuteTransactionAsync(async () => await _unitOfWork.job_Post_Candidates.AddAsync(map), cancellationToken);

            return map;
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Domain.Entites.Job;

namespace WebApi.Application.Command.JobC
{
    public class UpdateCandidateCommnad:IRequest<job_post_candidates>
    {
        public int? id { get; set; }
        public int? job_post_id { get; set; }
        public int? user_id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? cv_path { get; set; }
        public string? status_id { get; set; }
        public DateTime? created_at { get; set; }
    }
    public class UpdateCandidateCommnadHandler : IRequestHandler<UpdateCandidateCommnad, job_post_candidates>
    {
        private readonly ICustomRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCandidateCommnadHandler> _logger;

        public UpdateCandidateCommnadHandler(ICustomRepository repo, IMapper mapper, ILogger<UpdateCandidateCommnadHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<job_post_candidates> Handle(UpdateCandidateCommnad request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("UpdateComand");
            var map = _mapper.Map<job_post_candidates>(request);
            var cus = await _repo.UpdateCandidatePost(map);

            return cus;
        }
    }
}

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
using WebApi.Shared.Constants;

namespace WebApi.Application.Command.JobC
{
    public class ViewCandidateByEnterpiseQuery : IRequest<PagedList<job_post_candidates>>
    {
        public string? enterprise_id { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }

    }
    public class ViewCandidateByEnterpiseQueryHandler : IRequestHandler<ViewCandidateByEnterpiseQuery, PagedList<job_post_candidates>>
    {
        private readonly ICustomRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewCandidateByEnterpiseQueryHandler> _logger;

        public ViewCandidateByEnterpiseQueryHandler(ICustomRepository repo, IMapper mapper, ILogger<ViewCandidateByEnterpiseQueryHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<PagedList<job_post_candidates>> Handle(ViewCandidateByEnterpiseQuery request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("UpdateComand");
            var cus = await _repo.Search(request.enterprise_id,request.page,request.pageSize);

            return cus;
        }
    }
}

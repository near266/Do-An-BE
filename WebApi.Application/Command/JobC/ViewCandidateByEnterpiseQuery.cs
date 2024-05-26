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
using WebApi.Domain.Entites.Job;
using WebApi.Shared.Constants;

namespace WebApi.Application.Command.JobC
{
    public class ViewCandidateByEnterpiseQuery : IRequest<PagedList<CandidatesDtos>>
    {
        public int? idFields { get; set; }
        public string? enterprise_id { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }

    }
    public class ViewCandidateByEnterpiseQueryHandler : IRequestHandler<ViewCandidateByEnterpiseQuery, PagedList<CandidatesDtos>>
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
        public async Task<PagedList<CandidatesDtos>> Handle(ViewCandidateByEnterpiseQuery request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("UpdateComand");
            var ls = new List<CandidatesDtos>();
            var cus = await _repo.Search(request.idFields,request.enterprise_id,request.page,request.pageSize);
            foreach( var candidate in cus.Data) {
                var user = await _repo.GetInfoUserId(candidate.user_id);
                var post = await _repo.GetJobPostsById(candidate.job_post_id);
                var filed = await _repo.GetCareerFieldsById((int)post.career_field_id);
                var map = _mapper.Map<CandidatesDtos>(candidate);
                map.avatar = user.avatar;
                map.nameFields = filed.name;
                ls.Add(map);
            }

            return new PagedList<CandidatesDtos>()
            {
                Page=request.page,
                PageSize=request.pageSize,
                Data=ls,
                TotalCount=cus.TotalCount,
            };
        }
    }
}

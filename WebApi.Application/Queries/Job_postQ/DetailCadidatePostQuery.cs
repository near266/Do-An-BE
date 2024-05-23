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

namespace WebApi.Application.Queries.Job_postQ
{
    public class DetailCadidatePostQuery : IRequest<job_post_candidates>
    {
        public int? id { get; set; } 
    }
    public class DetailCadidatePostQueryHandler : IRequestHandler<DetailCadidatePostQuery, job_post_candidates>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DetailCadidatePostQueryHandler> _logger;

        public DetailCadidatePostQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DetailCadidatePostQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<job_post_candidates> Handle(DetailCadidatePostQuery request, CancellationToken cancellationToken)
        {

            var cus = await _unitOfWork.job_Post_Candidates.FirstOrDefaultAsync(x => x.id == request.id);


            return cus;
        }
    }
}

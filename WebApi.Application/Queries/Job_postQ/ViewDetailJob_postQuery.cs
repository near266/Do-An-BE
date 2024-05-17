using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos.Userinfo;
using WebApi.Application.Queries.UserInfoQ;
using WebApi.Domain.Entites.Job;

namespace WebApi.Application.Queries.Job_postQ
{
    public class ViewDetailJob_postQuery : IRequest<job_posts>
    {
        public string? id {  get; set; }
    }
    public class ViewDetailJob_postQueryHandler : IRequestHandler<ViewDetailJob_postQuery, job_posts>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewDetailJob_postQueryHandler> _logger;

        public ViewDetailJob_postQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ViewDetailJob_postQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<job_posts> Handle(ViewDetailJob_postQuery request, CancellationToken cancellationToken)
        {

            var cus = await _unitOfWork.jobPostRepository.FirstOrDefaultAsync(x => x.Id == request.id);


            return cus;
        }
    }
}

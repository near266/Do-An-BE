using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Models.Dtos.Userinfo;
using WebApi.Application.Models;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Queries.UserInfoQ;
using WebApi.Domain.Entites.Job;

namespace WebApi.Application.Queries.Job_postQ
{
    public class SearchJob_postQuery: IRequest <Pagination<job_posts>>
    {
        public string? enterprise_id { get; set; }
        public string? name { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
    }
    public class SearchJob_postQueryHandler : IRequestHandler<SearchJob_postQuery, Pagination<job_posts>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<SearchJob_postQueryHandler> _logger;

        public SearchJob_postQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SearchJob_postQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Pagination<job_posts>> Handle(SearchJob_postQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("View List Customer");
            var res = new Pagination<job_posts>();
           
            var cus = await _unitOfWork.jobPostRepository.GetAsync(i=>i.enterprise_id==request.enterprise_id,request.page,request.pageSize);
            if (request.enterprise_id == null)
            {
                cus=await _unitOfWork.jobPostRepository.ToPagination(request.page,request.pageSize);
            }
            if(request.name != null) {
                cus = await _unitOfWork.jobPostRepository.GetAsync(i => request.name.Contains(i.title), request.page, request.pageSize);
            }
            return cus;
        }
    }
}

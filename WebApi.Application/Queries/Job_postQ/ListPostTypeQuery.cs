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
using WebApi.Application.Queries.EnterpriseQ;
using WebApi.Domain.Entites.Account;
using WebApi.Domain.Entites.Job;
using WebApi.Shared.Constants;

namespace WebApi.Application.Queries.Job_postQ
{
    public class ListPostTypeQuery:IRequest<PagedList<JobListDtos>>
    {
        public int type {  get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }

    }
    public class ListPostTypeQueryHandler : IRequestHandler<ListPostTypeQuery, PagedList<JobListDtos>>
    {
        private readonly ICustomRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<ListPostTypeQueryHandler> _logger;

        public ListPostTypeQueryHandler(ICustomRepository repo, IMapper mapper, ILogger<ListPostTypeQueryHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<PagedList<JobListDtos>> Handle(ListPostTypeQuery request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("UpdateComand");
            var res = new PagedList<JobListDtos>();
            var ls = new List<JobListDtos>();
            var cus = await _repo.ViewAllPostByType(request.type, request.page, request.pageSize);
            foreach ( var item in cus.Data)
            {
                var enterprise = await _repo.getEnterpriseById(item.enterprise_id);
                var fieldsDetail = await _repo.GetCareerFieldsById((int)item.career_field_id);
                var careeDetail = await _repo.GetCareerById(item.career_id);
                var item1 = new JobListDtos();
                item1.id = item.Id;
                item1.title = item.title;
                item1.approved_status_id = item.approve_status_id;
                item1.entepriseId = item.enterprise_id;
                item1.created_at = item.created_date;
                item1.enterpriseName = enterprise.enterprise_name;
                item1.caree = careeDetail.name;
                item1.fileds = fieldsDetail.name;
              ls.Add(item1);


            }
            res.Data=ls;
            res.TotalCount = cus.TotalCount;
                res.PageSize = cus.PageSize;
            res.Page = cus.Page;
            return res;
        }
    }
}

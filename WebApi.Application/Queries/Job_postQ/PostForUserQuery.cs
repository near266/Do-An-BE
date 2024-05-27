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
    public class PostForUserQuery:IRequest<PagedList<UserPostCandidate>>
    {
        public int? fields_id {  get; set; }    
        public string? city { get; set; }
        public string? district { get; set; }
        public int page {  get; set; }
        public int pageSize { get; set; }
    }
    public class PostForUserQueryHandler : IRequestHandler<PostForUserQuery, PagedList<UserPostCandidate>>
    {
        private readonly ICustomRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<PostForUserQueryHandler> _logger;

        public PostForUserQueryHandler(ICustomRepository repo, IMapper mapper, ILogger<PostForUserQueryHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<PagedList<UserPostCandidate>> Handle(PostForUserQuery request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("UpdateComand");
            var res = new PagedList<UserPostCandidate>();
            var ls = new List<UserPostCandidate>();
            var cus = await _repo.PostForuser( request.fields_id, request.city, request.district, request.page,request.pageSize);
            foreach (var c in cus.Data)
            {
                var post = await _repo.GetJobPostsById(c.Id);
                var fields = await _repo.GetCareerFieldsById((int)post.career_field_id);
                var enter = await _repo.getEnterpriseById(post.enterprise_id);
                var map = new UserPostCandidate();
                map.job_post_id = post.Id;
                map.overView = post.overview;
                map.image_url = post.image_url;
                map.title = post.title;
                map.city = post.city;
                map.district = post.district;
                map.EnterpriseName = enter.enterprise_name;
                map.contact_phone = post.contact_phone;
                map.contact_email = post.contact_email;
                map.filedName = fields.name;
                map.createPost_at = post.created_date;
                ls.Add(map);
            }
            res.Data = ls;
            res.TotalCount = cus.TotalCount;
            res.PageSize = cus.PageSize;
            res.Page = cus.Page;
            return res;
        }
    }
}

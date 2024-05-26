using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models;
using WebApi.Application.Models.Dtos.Userinfo;
using WebApi.Domain.Entites.Account;
using WebApi.Shared.Constants;

namespace WebApi.Application.Queries.UserInfoQ
{
    public class ViewAllUserInfoQuery : IRequest<PagedList<userInfo>>
    {
        public int status { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
    }
    public class ViewAllUserInfoQueryHandler : IRequestHandler<ViewAllUserInfoQuery, PagedList<userInfo>>
    {
        private readonly ICustomRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewAllUserInfoQueryHandler> _logger;

        public ViewAllUserInfoQueryHandler(ICustomRepository repo, IMapper mapper, ILogger<ViewAllUserInfoQueryHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<PagedList<userInfo>> Handle(ViewAllUserInfoQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("View List Customer");
            var cus = await _repo.ViewListUserInfo(request.status, request.page, request.pageSize);
      
            return cus;
        }
    }
}

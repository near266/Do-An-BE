using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models;
using WebApi.Application.Models.Dtos;
using WebApi.Shared.Utils;

namespace WebApi.Infrastructure.Persistence.Repositories
{
    public class RecordSheetRepository : IRecordSheetRepository
    {
        private readonly CustomerSupportDatabaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public RecordSheetRepository(CustomerSupportDatabaseContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<RecordSheetDTO> CreateRecordSheet(RecordSheetDTO recordSheet, CancellationToken cancellationToken)
        {
            var JwtHelper = new JwtHelper(_httpContextAccessor);
            var user_id = JwtHelper.GetUserIdFromToken();
            var rs = new Domain.Entites.RecordSheet
            {
                Id = Guid.NewGuid(),
                Name = recordSheet.Name,
                Priority = recordSheet.Priority,
                Status = recordSheet.Status,
                Content = recordSheet.Content,
                CustomerId = recordSheet.CustomerId,
                TelesaleId = recordSheet.TelesaleId,
                Created_by = user_id,
                Created_date = DateTime.UtcNow,
                Last_modified_by = user_id,
                Last_modified_date = DateTime.UtcNow
            };
            await _context.RecordSheets.AddAsync(rs, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<RecordSheetDTO>(rs);
        }

        public async Task<RecordSheetDTO> UpdateRecordSheet(RecordSheetDTO recordSheet, CancellationToken cancellationToken)
        {
            var JwtHelper = new JwtHelper(_httpContextAccessor);
            var user_id = JwtHelper.GetUserIdFromToken();
            var rs = await _context.RecordSheets.FirstOrDefaultAsync(x => x.Id == recordSheet.Id, cancellationToken);
            rs = _mapper.Map(recordSheet, rs);
            rs.Last_modified_by = user_id;
            rs.Last_modified_date = DateTime.UtcNow;
            _context.RecordSheets.Update(rs);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<RecordSheetDTO>(rs);
        }

        public async Task<RecordSheetDTO> ViewDetailRecordSheet(Guid? id, CancellationToken cancellationToken)
        {
            var rs = await _context.RecordSheets.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return _mapper.Map<RecordSheetDTO>(rs);
        }

        public async Task<Pagination<RecordSheetDTO>> ViewListRecordSheet(int Page, int PageSize, string? Code, string? TelesaleId, string? CustomerName, DateTime? Created_at, int? Status, CancellationToken cancellationToken)
        {
            var query = _context.RecordSheets.AsQueryable();
            if (!string.IsNullOrEmpty(Code))
            {
                query = query.Where(x => x.Id.ToString().Contains(Code));
            }
            if (!string.IsNullOrEmpty(TelesaleId))
            {
                query = query.Where(x => x.TelesaleId.Contains(TelesaleId));
            }
            if (!string.IsNullOrEmpty(CustomerName))
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Name.Contains(CustomerName), cancellationToken);
                if (customer != null)
                {
                    query = query.Where(x => x.CustomerId == customer.Id.ToString());
                }
            }
            if (Created_at != null)
            {
                query = query.Where(x => x.Created_date == Created_at);
            }
            if (Status != null)
            {
                query = query.Where(x => x.Status == Status);
            }
            var total = await query.CountAsync(cancellationToken);
            var rs = await query.Skip((Page - 1) * PageSize).Take(PageSize).ToListAsync(cancellationToken);
            return new Pagination<RecordSheetDTO>
            {
                Items = _mapper.Map<List<RecordSheetDTO>>(rs),
                TotalItemsCount = total,
                PageIndex = Page,
                PageSize = PageSize
            };
        }
    }
}
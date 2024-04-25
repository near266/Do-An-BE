using WebApi.Application.Models;
using WebApi.Application.Models.Dtos;
using WebApi.Domain.Entites;

namespace WebApi.Application.Contracts.Persistence
{
    public interface IRecordSheetRepository
    {
        Task<RecordSheetDTO> CreateRecordSheet(RecordSheetDTO recordSheet, CancellationToken cancellationToken);
        Task<RecordSheetDTO> UpdateRecordSheet(RecordSheetDTO recordSheet, CancellationToken cancellationToken);
        Task<RecordSheetDTO> ViewDetailRecordSheet(Guid? id, CancellationToken cancellationToken);
        Task<Pagination<RecordSheetDTO>> ViewListRecordSheet(int Page, int PageSize, string? Code, string? TelesaleId, string? CustomerName, DateTime? Created_at, int? Status, CancellationToken cancellationToken);
    }
}
namespace WebApi.Application.Models.Dtos
{
    public class RecordSheetDTO
    {
        public Guid? Id { get; set; } = new Guid();
        public string? Name { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public string? Content { get; set; }
        public string CustomerId { get; set; }
        public string TelesaleId { get; set; }
    }
}
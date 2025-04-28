namespace CafeEmployee.Core.Features.Cafes.DTO
{
    public class CafeCreateRequest
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Logo { get; set; }
        public string Location { get; set; } = null!;
    }
}
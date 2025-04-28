namespace CafeEmployee.Core.Features.Cafes.DTO
{
    public class CafeUpdateRequest
    {
        public Guid Id { get; set; } // Cafe ID
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Logo { get; set; }
        public string Location { get; set; } = null!;
    }
}
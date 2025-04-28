using CafeEmployee.Core.Features.Employees.DTO;

namespace CafeEmployee.Core.Features.Cafes.DTO
{
    public class CafeResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        //public int Employees { get; set; } 
         public List<EmployeeResponse> Employees { get; set; } = new(); 
         public int TotalEmployees { get; set; }
        public string? Logo { get; set; } 
        public string Location { get; set; } = null!;
    }
}
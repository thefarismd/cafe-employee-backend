using CafeEmployee.Core.Enums;

namespace CafeEmployee.Core.Features.Employees.DTO
{
    public class EmployeeResponse
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int DaysWorked { get; set; }
        public string? CafeName { get; set; }
        public GenderOptions Gender { get; set; }
        public DateTime StartDate { get; set; }
        
    }
}
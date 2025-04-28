using System.ComponentModel.DataAnnotations;
using CafeEmployee.Core.Enums;

namespace CafeEmployee.Core.Features.Employees.DTO
{
    public class EmployeeUpdateRequest
    {
        [Required]
        public string Id { get; set; } = null!; 
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [RegularExpression(@"^[89]\d{7}$", ErrorMessage = "Phone number must start with 8 or 9 and be 8 digits.")]
        public string PhoneNumber { get; set; } = null!;

        public DateTime StartDate { get; set; }

        [Required]
        public Guid CafeId { get; set; } 

        [Required]
        public GenderOptions Gender { get; set; }
    }
}
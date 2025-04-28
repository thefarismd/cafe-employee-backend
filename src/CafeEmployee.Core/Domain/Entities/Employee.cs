using CafeEmployee.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CafeEmployee.Core.Domain.Entities
{
    public class Employee
    {
        [Key] // Must be in format "UIXXXXXXX", enforce in validation
        [RegularExpression(@"^UI\d{7}$", ErrorMessage = "ID must start with 'UI' followed by 7 digits.")]
        public string Id { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [RegularExpression(@"^[89]\d{7}$", ErrorMessage = "Phone number must start with 8 or 9 and be 8 digits.")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public GenderOptions Gender { get; set; }

        [Required]
        public Guid CafeId { get; set; } //Foreign key to Cafe

        public Cafe Cafe { get; set; } = null!;

        public DateTime StartDate { get; set; }

    }
}
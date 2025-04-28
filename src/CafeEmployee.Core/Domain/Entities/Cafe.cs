using System.ComponentModel.DataAnnotations;

namespace CafeEmployee.Core.Domain.Entities
{
    public class Cafe
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!; 

        public string? Logo { get; set; } // Optional

        [Required]
        public string Location { get; set; } = null!;

        public ICollection<Employee> Employees { get; set; } = [];
    
        
    }
}
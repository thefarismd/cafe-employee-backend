using System.ComponentModel.DataAnnotations;

namespace CafeEmployee.Core.Features.Employees.DTO
{
    public class EmployeeDeleteRequest
    {
        [Required]
        public string Id { get; set; } = null!; // Employee Id (UIxxxxxxx)
    }
}
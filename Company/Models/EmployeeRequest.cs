using Company.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Company.Models
{
    public class EmployeeRequest
    {
        public int Id { get; set; }
        public int DepartmentId { get; init; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public string? MiddleInitial { get; set; }
        [Required]
        public string? Email { get; init; }
        public DateTime? DOB { get; init; }
        public string? PhoneNumber { get; init; }
        public int Age { get; set; }
        public string? Title { get; set; }
        public DateTime? HireDate { get; set; }
        public decimal? Salary { get; set; }
        public WorkLocation? WorkLocation { get; init; }
    }
}

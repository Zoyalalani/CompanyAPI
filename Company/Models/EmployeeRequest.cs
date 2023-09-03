using Company.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Company.Models
{
    public class EmployeeRequest
    {
        public int Id { get; init; }
        [Required]
        public int DepartmentId { get; init; }
        [Required]
        public string FirstName { get; init; } = string.Empty;
        [Required]
        public string LastName { get; init; } = string.Empty;
        public string MiddleInitial { get; init; }
        [Required]
        public string Email { get; init; }
        public DateTime? DOB { get; init; }
        public string PhoneNumber { get; init; }
        public string Street { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string Zip { get; init; }
        public int Age { get; init; }
        public string Title { get; init; }
        public DateTime? HireDate { get; init; }
        public decimal? Salary { get; init; }
        public WorkLocation? WorkLocation { get; init; }
    }
}

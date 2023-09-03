using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Models.Entity
{
    public record Employee
    {
        [Key]
        [Column("employee_id")]
        public int EmployeeId { get; init; }

        [Column("department_id")]
        public int DepartmentId { get; init; }

        [Column("first_name")]
        [Required]
        public string FirstName { get; init; }  = string.Empty;

        [Column("last_name")]
        [Required]
        public string LastName { get; init; } = string.Empty;

        [Column("middle_initial")]
        [MaxLength(1)]
        public string MiddleInitial { get; init; }

        [Column("email")]
        [Required]
        public string Email { get; init; }

        [Column("dob")]
        public DateTime? DOB { get; init; }

        [Column("phone_number")]
        [MaxLength(10)]
        public string? PhoneNumber { get; init; }

        [Column("street")]
        [Required]
        public string Street { get; init; } = string.Empty;

        [Column("city")]
        public string City { get; init; }

        [Column("state")]
        public string State { get; init; }

        [Column("zip")]
        [MaxLength(6)]
        public string Zip { get; init; }

        [Column("age")]
        public int Age { get; init; }

        [Column("title")]
        public string Title { get; init; }

        [Column("date_of_hire")]
        public DateTime? HireDate { get; init; }

        [Column("salary")]
        public decimal? Salary { get; init; }

        [Column("work_location")]
        public WorkLocation? WorkLocation { get; init; }
        public virtual Department Department { get; init; }
    }

    public enum WorkLocation
    {
        Hybrid,
        InOffice,
        Remote
    }
}

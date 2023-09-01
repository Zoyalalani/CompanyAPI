using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Models.Entity
{
    public record Department
    {
        [Key]
        [Column("department_id")]
        public int DepartmentId { get; init; }
        [Required]
        public string Name { get; init; } = string.Empty;
        public virtual ICollection<Employee>? Employees { get; init; }
    }
}

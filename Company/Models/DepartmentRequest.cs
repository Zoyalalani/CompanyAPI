using System.ComponentModel.DataAnnotations;

namespace Company.Models
{
    public class DepartmentRequest
    {
        public int Id { get; init; }
        [Required]
        public string Name { get; init; } = string.Empty;
    }
}

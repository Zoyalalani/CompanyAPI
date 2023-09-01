using System.ComponentModel.DataAnnotations;

namespace Company.Models
{
    public class DepartmentRequest
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}

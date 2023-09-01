using Company.Models.Entity;
using Company.Models;

namespace Company.Datalayer.Interfaces
{
    public interface IDepartmentDataLayer
    {
        Task<Department> CreateDepartment(DepartmentRequest employeeRequest);
        Task<Department> UpdateDepartment(int id, DepartmentRequest employeeRequest);
        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
    }
}

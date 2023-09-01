using Company.Models.Entity;
using Company.Models;

namespace Company.BuisnessLayer.Interfaces
{
    public interface IDepartmentBusinessLayer
    {
        Task<Department> CreateDepartment(DepartmentRequest employeeRequest);
        Task<Department> UpdateDepartment(int id, DepartmentRequest employeeRequest);
        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
    }
}

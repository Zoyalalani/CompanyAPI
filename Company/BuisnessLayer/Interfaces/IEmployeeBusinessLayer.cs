using Company.Models;
using Company.Models.Entity;

namespace Company.BuisnessLayer.Interfaces
{
    public interface IEmployeeBusinessLayer
    {
        Task<Employee> CreateEmployee(EmployeeRequest employeeRequest);
        Task<Employee> UpdateEmployee(int id, EmployeeRequest employeeRequest);
        Task DeleteEmployee(int id);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
    }
}

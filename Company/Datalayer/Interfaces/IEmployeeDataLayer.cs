using Company.Models.Entity;
using Company.Models;

namespace Company.Datalayer.Interfaces
{
    public interface IEmployeeDataLayer
    {
        Task<Employee> CreateEmployee(EmployeeRequest employeeRequest);
        Task<Employee> UpdateEmployee(int id, EmployeeRequest employeeRequest);
        Task DeleteEmployee(int id);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<List<Employee>> GetEmployeesByFirstAndLastName(string firstName, string lastName);

    }
}

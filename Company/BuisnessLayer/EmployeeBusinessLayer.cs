using Company.BuisnessLayer.Interfaces;
using Company.Datalayer.Interfaces;
using Company.Models;
using Company.Models.Entity;

namespace Company.BuisnessLayer
{
    public class EmployeeBusinessLayer : IEmployeeBusinessLayer
    {
        private readonly IEmployeeDataLayer _employeeDataLayer;

        public EmployeeBusinessLayer(IEmployeeDataLayer employeeDataLayer)
        {
            _employeeDataLayer = employeeDataLayer;
        }

        public Task<Employee> CreateEmployee(EmployeeRequest employeeRequest) => _employeeDataLayer.CreateEmployee(employeeRequest);

        public Task DeleteEmployee(int id) => _employeeDataLayer.DeleteEmployee(id);

        public Task<List<Employee>> GetAllEmployees() => _employeeDataLayer.GetAllEmployees();

        public Task<Employee> GetEmployeeById(int id) => _employeeDataLayer.GetEmployeeById(id);

        public Task<Employee> UpdateEmployee(int id, EmployeeRequest employeeRequest) => _employeeDataLayer.UpdateEmployee(id, employeeRequest);
    }
}

using Company.Datalayer.Context;
using Company.Datalayer.Interfaces;
using Company.Datalayer.Interfaces.Context;
using Company.Models;
using Company.Models.Entity;
using Company.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Company.Datalayer
{
    public class EmployeeDataLayer : IEmployeeDataLayer
    {
        private readonly CompanyDbContext _context;

        public EmployeeDataLayer(CompanyDbContext context)
        {
            _context = context;
        }

        public ICompanyDbContext GetCompanyDbContext() => (ICompanyDbContext)_context;

        public async Task<Employee> CreateEmployee(EmployeeRequest employeeRequest)
        {
            var employee = new Employee
            {
                FirstName = employeeRequest.FirstName,
                DepartmentId = employeeRequest.DepartmentId,
                LastName = employeeRequest.LastName,
                MiddleInitial = employeeRequest.MiddleInitial,
                Email = employeeRequest.Email,
                DOB = employeeRequest.DOB,
                PhoneNumber = employeeRequest.PhoneNumber,
                Age = employeeRequest.Age,
                Title = employeeRequest.Title,
                HireDate = employeeRequest.HireDate,
                Salary = employeeRequest.Salary,
                WorkLocation = employeeRequest.WorkLocation
            };
            var employeeEntry = _context.Employee.Add(employee);
            await _context.SaveChangesAsync();
            return employeeEntry.AsNoTrackedEntity();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _context.Employee
                .AsNoTracking()
                .Include(employee => employee.Department)
                .FirstOrDefaultAsync(employee => employee.EmployeeId == id);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with id ({id}) not found.");
            }

            return employee;
        }

        public async Task<List<Employee>> GetEmployeesByFirstAndLastName(string firstName, string lastName)
        {
            var employees = await _context.Employee
                .Where(e=>e.FirstName == firstName && e.LastName == lastName)
                .AsNoTracking()
                .Include(employee => employee.Department)
                .ToListAsync();
            return employees;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await _context.Employee
                .AsNoTracking()
                .Include(employee => employee.Department)
                .ToListAsync();

            return employees;
        }

        public async Task<Employee> UpdateEmployee(int id, EmployeeRequest employeeRequest)
        {
            var employeeTypeToUpdate = await _context.Employee
                .AsNoTracking()
                .SingleOrDefaultAsync(lt => lt.EmployeeId.Equals(id));

            if (employeeTypeToUpdate == null)
            {
                throw new ArgumentException($"employee with Id ({id}) not found.");
            }

            var employeeEntry = _context.Update(employeeTypeToUpdate with
            {
                FirstName = employeeRequest.FirstName,
                LastName = employeeRequest.LastName,
                MiddleInitial = employeeRequest.MiddleInitial,
                Email = employeeRequest.Email,
                DOB = employeeRequest.DOB,
                PhoneNumber = employeeRequest.PhoneNumber,
                Age = employeeRequest.Age,
                Title = employeeRequest.Title,
                HireDate = employeeRequest.HireDate,
                Street = employeeRequest.Street,
                City = employeeRequest.City,
                State = employeeRequest.State,
                Zip = employeeRequest.Zip,
                Salary = employeeRequest.Salary,
                WorkLocation = employeeRequest.WorkLocation
            });

            await _context.SaveChangesAsync();

            return employeeEntry.AsNoTrackedEntity();
        }

        public async Task DeleteEmployee(int id)
        {
            var request = _context.Employee.Find(id);
            if (request == null)
            {
                throw new ArgumentException($"employee with id ({id}) not found.");
            }
            _context.Remove(request);

            await _context.SaveChangesAsync();
        }

    }
}

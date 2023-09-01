using Company.Datalayer.Context;
using Company.Datalayer.Interfaces;
using Company.Datalayer.Interfaces.Context;
using Company.Models;
using Company.Models.Entity;
using Company.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Company.Datalayer
{
    public class DepartmentDataLayer : IDepartmentDataLayer
    {
        private readonly CompanyDbContext _context;

        public DepartmentDataLayer(CompanyDbContext context)
        {
            _context = context;
        }

        public ICompanyDbContext GetCompanyDbContext() => (ICompanyDbContext)_context;

        public async Task<Department> CreateDepartment(DepartmentRequest departmentRequest)
        {
            var department = new Department
            {
                Name = departmentRequest.Name
            };
            var departmentEntry = _context.Department.Add(department);
            await _context.SaveChangesAsync();
            return departmentEntry.AsNoTrackedEntity();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var department = await _context.Department
                .AsNoTracking()
                .FirstOrDefaultAsync(department => department.DepartmentId == id);

            if (department == null)
            {
                throw new ArgumentException($"Department with id ({id}) not found.");
            }

            return department;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            var departments = await _context.Department
                .AsNoTracking()
                .ToListAsync();

            return departments;
        }

        public async Task<Department> UpdateDepartment(int id, DepartmentRequest departmentRequest)
        {
            var departmentTypeToUpdate = await _context.Department
                .AsNoTracking()
                .SingleOrDefaultAsync(lt => lt.DepartmentId.Equals(id));

            if (departmentTypeToUpdate == null)
            {
                throw new ArgumentException($"department with Id ({id}) not found.");
            }

            var departmentEntry = _context.Update(departmentTypeToUpdate with
            {
                Name = departmentRequest.Name
            });

            await _context.SaveChangesAsync();

            return departmentEntry.AsNoTrackedEntity();
        }

    }
}

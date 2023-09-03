using Company.BuisnessLayer.Interfaces;
using Company.Datalayer.Interfaces;
using Company.Models;
using Company.Models.Entity;

namespace Company.BuisnessLayer
{
    public class DepartmentBusinessLayer : IDepartmentBusinessLayer
    {
        private readonly IDepartmentDataLayer _departmentDataLayer;

        public DepartmentBusinessLayer(IDepartmentDataLayer departmentDataLayer)
        {
            _departmentDataLayer = departmentDataLayer;
        }
        //In real scenarios, BL is for inserting business logic
        //since we don't need any logical statements, this is just a passthrough.
        public Task<Department> CreateDepartment(DepartmentRequest departmentRequest) => _departmentDataLayer.CreateDepartment(departmentRequest);

        public Task<List<Department>> GetAllDepartments() => _departmentDataLayer.GetAllDepartments();

        public Task<Department> GetDepartmentById(int id) => _departmentDataLayer.GetDepartmentById(id);

        public Task<Department> UpdateDepartment(int id, DepartmentRequest departmentRequest) => _departmentDataLayer.UpdateDepartment(id, departmentRequest);
    }
}

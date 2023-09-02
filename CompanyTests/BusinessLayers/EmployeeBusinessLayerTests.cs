using Moq;
using Company.Models;
using Company.Models.Entity;
using Company.BuisnessLayer;
using Company.Datalayer.Interfaces;

namespace Company.Tests.BusinessLayers
{
    public class EmployeeBusinessLayerTests
    {
        private EmployeeBusinessLayer _employeeBusinessLayer;
        private Mock<IEmployeeDataLayer> _mockemployeeDataLayer;

        Employee _employee;
        EmployeeRequest _employeeRequest;

        public EmployeeBusinessLayerTests()
        {
            _mockemployeeDataLayer = new Mock<IEmployeeDataLayer>();
            _employeeBusinessLayer = new EmployeeBusinessLayer(_mockemployeeDataLayer.Object);

            _employeeRequest = new EmployeeRequest
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Employee1",
                DepartmentId = 1,
                Email = "Test1@test.com"
            };

            _employee = new Employee
            {
                EmployeeId = 1,
                FirstName = "Test",
                LastName = "Employee1",
                DepartmentId = 1,
                Email = "Test1@test.com"
            };

        }

        [Fact]
        public async Task GetEmployeeById_Success()
        {
            // Arrange
            _mockemployeeDataLayer.Setup(dataLayer => dataLayer.GetEmployeeById(It.IsAny<int>()))
                .ReturnsAsync(_employee);

            // Act
            var result = await _employeeBusinessLayer.GetEmployeeById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.EmployeeId);
        }

        [Fact]
        public async Task GetEmployees_Success()
        {
            // Arrange
            _mockemployeeDataLayer.Setup(dataLayer => dataLayer.GetAllEmployees())
                .ReturnsAsync(new List<Employee> { _employee });

            // Act
            var result = _employeeBusinessLayer.GetAllEmployees();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Post_AddEmployee_Success()
        {
            // Arrange
            _mockemployeeDataLayer.Setup(dataLayer => dataLayer.CreateEmployee(It.IsAny<EmployeeRequest>()))
                .ReturnsAsync(_employee);

            // Act
            var result = await _employeeBusinessLayer.CreateEmployee(_employeeRequest);

            // Assert            
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Put_Updateemployee_Success()
        {
            // Arrange
            _mockemployeeDataLayer.Setup(dataLayer => dataLayer.UpdateEmployee(It.IsAny<int>(), It.IsAny<EmployeeRequest>()))
                .ReturnsAsync(_employee);

            // Act
            var result = await _employeeBusinessLayer.UpdateEmployee(1, _employeeRequest);

            // Assert
            Assert.NotNull(result);
        }
    }
}

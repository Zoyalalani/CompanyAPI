using Company.BuisnessLayer.Interfaces;
using Company.Controllers;
using Company.Models;
using Company.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Company.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        private EmployeeController _employeeController;
        private readonly Mock<IEmployeeBusinessLayer> _mockEmployeeBusinessLayer;
        private readonly EmployeeRequest _employeeRequest;
        private readonly Employee _employee;

        public EmployeeControllerTests()
        {
            _mockEmployeeBusinessLayer = new Mock<IEmployeeBusinessLayer>();
            _employeeController = new EmployeeController(_mockEmployeeBusinessLayer.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

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
        public async Task CreateEmployee_Success()
        {
            // Arrange
            _mockEmployeeBusinessLayer.Setup(businessLayer => businessLayer.CreateEmployee(It.IsAny<EmployeeRequest>()))
                .ReturnsAsync(_employee);

            // Act
            var result = await _employeeController.CreateEmployeeAsync(_employeeRequest);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task CreateEmployee_BadRequest_Null()
        {
            // Arrange
            _mockEmployeeBusinessLayer.Setup(businessLayer => businessLayer.CreateEmployee(It.IsAny<EmployeeRequest>()))
                .ReturnsAsync(_employee);

            // Act
            var result = await _employeeController.CreateEmployeeAsync(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task CreateEmployee_Exception()
        {
            // Arrange
            _mockEmployeeBusinessLayer.Setup(businessLayer => businessLayer.CreateEmployee(It.IsAny<EmployeeRequest>()))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _employeeController.CreateEmployeeAsync(_employeeRequest);

            // Assert
            Assert.Equal(500, StatusCodes.Status500InternalServerError);
        }

        [Fact]
        public async Task GetEmployeeById_Success()
        {
            // Arrange
            _mockEmployeeBusinessLayer.Setup(businessLayer => businessLayer.GetEmployeeById(It.IsAny<int>()))
                .ReturnsAsync(_employee);

            // Act
            var result = await _employeeController.GetEmployeeByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetAllEmployee_Success()
        {
            // Arrange
            _mockEmployeeBusinessLayer.Setup(businessLayer => businessLayer.GetAllEmployees());

            // Act
            var result = _employeeController.GetAllEmployeesAsync();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateEmployee_Success()
        {
            // Arrange
            _mockEmployeeBusinessLayer.Setup(businessLayer => businessLayer.UpdateEmployee(It.IsAny<int>(), It.IsAny<EmployeeRequest>()))
                .ReturnsAsync(_employee);

            // Act
            var result = await _employeeController.UpdateEmployeeAsync(1, _employeeRequest);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateEmployee_BadRequest_Null_Request()
        {
            // Arrange
            _mockEmployeeBusinessLayer.Setup(businessLayer => businessLayer.UpdateEmployee(It.IsAny<int>(), It.IsAny<EmployeeRequest>()))
                .ReturnsAsync(_employee);

            // Act
            var result = await _employeeController.UpdateEmployeeAsync(1, null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateEmployee_BadRequest_Null_Id()
        {
            // Arrange
            _mockEmployeeBusinessLayer.Setup(businessLayer => businessLayer.UpdateEmployee(It.IsAny<int>(), It.IsAny<EmployeeRequest>()))
                .ReturnsAsync(_employee);

            // Act
            var result = await _employeeController.UpdateEmployeeAsync(2, _employeeRequest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateEmployee_NotFound()
        {
            // Arrange
            _mockEmployeeBusinessLayer.Setup(businessLayer => businessLayer.UpdateEmployee(It.IsAny<int>(), It.IsAny<EmployeeRequest>()))
                .ThrowsAsync(new ArgumentException());

            // Act
            var result = await _employeeController.UpdateEmployeeAsync(1, _employeeRequest);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task DeleteEmployee_Success()
        {
            // Arrange
            _mockEmployeeBusinessLayer.Setup(businessLayer => businessLayer.DeleteEmployee(It.IsAny<int>()));

            // Act
            var result = await _employeeController.DeleteEmployee(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteEmployee_NotFound()
        {
            // Arrange
            _mockEmployeeBusinessLayer.Setup(businessLayer => businessLayer.DeleteEmployee(It.IsAny<int>())).ThrowsAsync(new ArgumentException()); ;

            // Act
            var result = await _employeeController.DeleteEmployee(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}

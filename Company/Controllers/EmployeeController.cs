using Company.Datalayer.Interfaces;
using Company.Models;
using Company.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeDataLayer _employeeDataLayer;
        public EmployeeController(IEmployeeDataLayer employeeDataLayer)
        {
            _employeeDataLayer = employeeDataLayer;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] int id)
        {
            try
            {
                var result = await _employeeDataLayer.GetEmployeeById(id);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);

            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var result = await _employeeDataLayer.GetAllEmployees();

            return Ok(result);
        }

        //Extra credit : Get list of employees whose first and last name matches
        [HttpGet]
        [Route("FirstName/{firstName}/LastName/{lastName}")]
        [ProducesResponseType(typeof(List<Employee>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEmployeesByFirstAndLastNameAsync([FromRoute] string firstName, string lastName)
        {
            var result = await _employeeDataLayer.GetEmployeesByFirstAndLastName(firstName, lastName);

            if (result.Count == 0)
            {
                return NotFound($"No employees with firstName {firstName} and {lastName} found");
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status409Conflict)]

        public async Task<IActionResult> CreateEmployeeAsync([FromBody] EmployeeRequest employeeRequest)
        {
            if (employeeRequest == null)
            {
                return BadRequest("Invalid Request. Request cannot be null.");
            }

            try
            {
                var employee = await _employeeDataLayer.CreateEmployee(employeeRequest);

                //Returning the newly created employee
                return Created($"Employee/{employee.EmployeeId}", employee);
            }
            catch (SqlException exception)
            {
                return StatusCode(StatusCodes.Status409Conflict, exception);

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] int id, [FromBody] EmployeeRequest employeeRequest)
        {
            if (employeeRequest == null)
            {
                return BadRequest("Invalid Request. Request cannot be null.");
            }

            if (id != employeeRequest.Id)
            {
                return BadRequest($"Employee with id provided in route ({id}) must match the id provided in body ({employeeRequest.Id})");
            }

            try
            {
                var employee = await _employeeDataLayer.UpdateEmployee(id, employeeRequest);

                return Ok(employee);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            try
            {
                await _employeeDataLayer.DeleteEmployee(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

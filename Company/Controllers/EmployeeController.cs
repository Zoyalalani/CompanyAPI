using Company.BuisnessLayer.Interfaces;
using Company.Models;
using Company.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusinessLayer _employeeBusinessLayer;
        public EmployeeController(IEmployeeBusinessLayer employeeBusinessLayer)
        {
            _employeeBusinessLayer = employeeBusinessLayer;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] int id)
        {
            try
            {
                var result = await _employeeBusinessLayer.GetEmployeeById(id);
                return Ok(result);
            }
            catch(ArgumentException ex)
            {
                return NotFound(ex.Message);

            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var result = await _employeeBusinessLayer.GetAllEmployees();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody] EmployeeRequest employeeRequest)
        {
            if (employeeRequest == null)
            {
                return BadRequest("Invalid Request. Request cannot be null.");
            }

            try
            {
                var employee = await _employeeBusinessLayer.CreateEmployee(employeeRequest);

                //Returning the newly created employee
                return Created($"Employee/{employee.EmployeeId}", employee);
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
                var employee = await _employeeBusinessLayer.UpdateEmployee(id, employeeRequest);

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
                await _employeeBusinessLayer.DeleteEmployee(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

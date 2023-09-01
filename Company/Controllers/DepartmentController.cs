using Company.BuisnessLayer.Interfaces;
using Company.Models;
using Company.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentBusinessLayer _departmentBusinessLayer;
        public DepartmentController(IDepartmentBusinessLayer departmentBusinessLayer)
        {
            _departmentBusinessLayer = departmentBusinessLayer;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Department), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDepartmentByIdAsync([FromRoute] int id)
        {
            try
            {
                var result = await _departmentBusinessLayer.GetDepartmentById(id);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);

            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Department>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDepartmentsAsync()
        {
            var result = await _departmentBusinessLayer.GetAllDepartments();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Department), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateDepartmentAsync([FromBody] DepartmentRequest departmentRequest)
        {
            if (departmentRequest == null)
            {
                return BadRequest("Invalid Request. Request cannot be null.");
            }

            try
            {
                var department = await _departmentBusinessLayer.CreateDepartment(departmentRequest);

                //Returning the newly created department
                return Created($"Department/{department.DepartmentId}", department);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Department), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateDepartmentAsync([FromRoute] int id, [FromBody] DepartmentRequest departmentRequest)
        {
            if (departmentRequest == null)
            {
                return BadRequest("Invalid Request. Request cannot be null.");
            }

            if (id != departmentRequest.Id)
            {
                return BadRequest($"Department with id provided in route ({id}) must match the id provided in body ({departmentRequest.Id})");
            }

            try
            {
                var department = await _departmentBusinessLayer.UpdateDepartment(id, departmentRequest);

                return Ok(department);
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
    }
}

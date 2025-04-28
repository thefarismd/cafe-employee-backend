using Microsoft.AspNetCore.Mvc;
using CafeEmployee.Core.Features.Employees.Queries;
using MediatR;
using CafeEmployee.Core.Features.Employees.Commands;
using CafeEmployee.Core.Features.Employees.DTO;

namespace CafeEmployee.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET /api/employees?cafe=
        [HttpGet]
        public async Task<IActionResult> GetEmployees([FromQuery] string? cafe)
        {
            var query = new GetEmployeesQuery(cafe);

            var employees = await _mediator.Send(query);

            return Ok(employees);
        }

        // POST /api/employees
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateRequest employeeCreateRequest)
        {
            var command = new CreateEmployeeCommand(employeeCreateRequest);

            var newId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetEmployees), new { id = newId }, new { id = newId });
        }

        // PUT /api/employees
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeUpdateRequest employeeUpdateRequest)
        {
            var command = new UpdateEmployeeCommand(employeeUpdateRequest);

            var result = await _mediator.Send(command);

            return Ok("Employee updated successfully.");
        }

        // DELETE /api/employee
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee([FromBody] EmployeeDeleteRequest employeeDeleteRequest)
        {
            var command = new DeleteEmployeeCommand(employeeDeleteRequest);

            var result = await _mediator.Send(command);

            return Ok("Employee deleted successfully.");
        }

    }
}
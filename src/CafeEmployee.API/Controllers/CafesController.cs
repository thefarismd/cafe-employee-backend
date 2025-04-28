using Microsoft.AspNetCore.Mvc;
using MediatR;
using CafeEmployee.Core.Features.Cafes.Queries;
using CafeEmployee.Core.Features.Cafes.Commands;
using CafeEmployee.Core.Features.Cafes.DTO;
using CafeEmployee.API.Models;

namespace CafeEmployee.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CafesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CafesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET /cafes?location=bugis
        [HttpGet]
        public async Task<IActionResult> GetCafes([FromQuery] string? location)
        {
            var query = new GetCafesQuery(location);

            var cafes = await _mediator.Send(query);
            
            return Ok(cafes);
        }

        // POST /api/cafes
        [HttpPost]
        public async Task<IActionResult> CreateCafe([FromBody] CafeCreateRequest cafeCreateRequest)
        {
            var command = new CreateCafeCommand(cafeCreateRequest);

            var newId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCafes), new { id = newId }, new { id = newId });
        }

        // PUT /api/cafes
        [HttpPut]
        public async Task<IActionResult> UpdateCafe([FromBody] CafeUpdateRequest cafeUpdateRequest)
        {
            var command = new UpdateCafeCommand(cafeUpdateRequest); // Wrap DTO into Command

            var result = await _mediator.Send(command); // Send the command via Mediator

            return Ok("Cafe updated successfully.");
        }

        // DELETE /api/cafes
        public async Task<IActionResult> DeleteCafe([FromBody] CafeDeleteRequest cafeDeleteRequest)
        {
            var command = new DeleteCafeCommand(cafeDeleteRequest);

            var result = await _mediator.Send(command);

            return Ok("Cafe and related employees deleted successfully.");
        }

    }
}
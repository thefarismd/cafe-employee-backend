using MediatR;
using CafeEmployee.Core.Features.Cafes.Commands;
using CafeEmployee.Core.RepositoryContracts;
using CafeEmployee.Core.Domain.Entities;
using CafeEmployee.Core.Common;
using Microsoft.Extensions.Logging; 

namespace CafeEmployee.Core.Features.Cafes.Handlers
{
    public class UpdateCafeCommandHandler : IRequestHandler<UpdateCafeCommand, bool>
    {
        private readonly ICafesRepository _cafesRepository;
        private readonly ILogger<UpdateCafeCommandHandler> _logger;

        public UpdateCafeCommandHandler(ICafesRepository cafesRepository, ILogger<UpdateCafeCommandHandler> logger)
        {
            _cafesRepository = cafesRepository;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateCafeCommand request, CancellationToken cancellationToken)
        {
            var cafe = new Cafe
            {
                Id = request.CafeUpdateRequest.Id,
                Name = request.CafeUpdateRequest.Name,
                Description = request.CafeUpdateRequest.Description,
                Logo = request.CafeUpdateRequest.Logo,
                Location = request.CafeUpdateRequest.Location
            };

            var success = await _cafesRepository.UpdateCafeAsync(cafe, cancellationToken);

              if (!success)
            {
                _logger.LogWarning("Update failed: Cafe with ID {CafeId} not found.", request.CafeUpdateRequest.Id);

                throw new CustomValidationException(new List<string> { "Cafe not found." });
            }

            _logger.LogInformation("Cafe with ID {CafeId} updated successfully.", request.CafeUpdateRequest.Id);

            return success;
        }
    }
}
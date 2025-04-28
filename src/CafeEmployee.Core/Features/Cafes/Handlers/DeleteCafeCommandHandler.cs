using MediatR;
using CafeEmployee.Core.RepositoryContracts;
using CafeEmployee.Core.Features.Cafes.Commands;
using CafeEmployee.Core.Common;
using Microsoft.Extensions.Logging;

namespace CafeEmployee.Core.Features.Cafes.Handlers
{
    public class DeleteCafeCommandHandler : IRequestHandler<DeleteCafeCommand, bool>
    {
        private readonly ICafesRepository _cafesRepository;
        private readonly ILogger<DeleteCafeCommandHandler> _logger; 

        public DeleteCafeCommandHandler(ICafesRepository cafesRepository, ILogger<DeleteCafeCommandHandler> logger)
        {
            _cafesRepository = cafesRepository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteCafeCommand request, CancellationToken cancellationToken)
        {
            var success = await _cafesRepository.DeleteCafeAsync(request.CafeDeleteRequest.Id, cancellationToken);

            if (!success)
            {
                  _logger.LogWarning("Delete failed: Cafe with ID {CafeId} not found.", request.CafeDeleteRequest.Id);
                throw new CustomValidationException(new List<string> { "Cafe not found." });
            }

            _logger.LogInformation("Cafe with ID {CafeId} deleted successfully.", request.CafeDeleteRequest.Id);

            return success;
        }
    }
}
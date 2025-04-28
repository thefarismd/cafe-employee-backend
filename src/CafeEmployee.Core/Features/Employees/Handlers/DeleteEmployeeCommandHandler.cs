using MediatR;
using CafeEmployee.Core.Features.Employees.Commands;
using CafeEmployee.Core.RepositoryContracts;
using CafeEmployee.Core.Common;
using Microsoft.Extensions.Logging;

namespace CafeEmployee.Core.Features.Employees.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly ILogger<DeleteEmployeeCommandHandler> _logger;

        public DeleteEmployeeCommandHandler(IEmployeesRepository employeesRepository, ILogger<DeleteEmployeeCommandHandler> logger)
        {
            _employeesRepository = employeesRepository;
            _logger = logger;
        }
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var success = await _employeesRepository.DeleteEmployeeAsync(
               request.EmployeeDeleteRequest.Id, cancellationToken);

            if (!success)
            {
                _logger.LogWarning("Delete failed: Employee with ID {EmployeeId} not found.", request.EmployeeDeleteRequest.Id);

                throw new CustomValidationException(new List<string> { "Employee not found." });
            }

            _logger.LogInformation("Employee with ID {EmployeeId} deleted successfully.", request.EmployeeDeleteRequest.Id);

            return true;
        }
    }
}
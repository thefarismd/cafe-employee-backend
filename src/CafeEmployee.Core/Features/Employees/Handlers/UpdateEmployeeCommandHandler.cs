using MediatR;
using CafeEmployee.Core.RepositoryContracts;
using CafeEmployee.Core.Domain.Entities;
using CafeEmployee.Core.Common;
using Microsoft.Extensions.Logging;

namespace CafeEmployee.Core.Features.Employees.Commands
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly ILogger<UpdateEmployeeCommandHandler> _logger;

        public UpdateEmployeeCommandHandler(IEmployeesRepository employeesRepository, ILogger<UpdateEmployeeCommandHandler> logger)
        {
            _employeesRepository = employeesRepository;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Id = request.EmployeeUpdateRequest.Id,
                Name = request.EmployeeUpdateRequest.Name,
                EmailAddress = request.EmployeeUpdateRequest.EmailAddress,
                PhoneNumber = request.EmployeeUpdateRequest.PhoneNumber,
                StartDate = DateTime.SpecifyKind(request.EmployeeUpdateRequest.StartDate, DateTimeKind.Utc),
                CafeId = request.EmployeeUpdateRequest.CafeId,
                Gender = request.EmployeeUpdateRequest.Gender
            };

            var success = await _employeesRepository.UpdateEmployeeAsync(employee, cancellationToken);

            if (!success)
            {
                _logger.LogWarning("Update failed: Employee with ID {EmployeeId} not found.", request.EmployeeUpdateRequest.Id);

                throw new CustomValidationException(new List<string> { "Employee not found." });
            }

            _logger.LogInformation("Employee with ID {EmployeeId} updated successfully.", request.EmployeeUpdateRequest.Id);

            return true;
        }
    }
}
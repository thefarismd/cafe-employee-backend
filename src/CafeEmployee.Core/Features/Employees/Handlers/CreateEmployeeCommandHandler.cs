using MediatR;
using CafeEmployee.Core.Features.Employees.Commands;
using CafeEmployee.Core.RepositoryContracts;
using CafeEmployee.Core.Domain.Entities;

namespace CafeEmployee.Core.Features.Employees.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, string>
    {
        private readonly IEmployeesRepository _employeesRepository;

        public CreateEmployeeCommandHandler(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }
        public async Task<string> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
    
            var employee = new Employee
            {
                Name = request.EmployeeCreateRequest.Name,
                EmailAddress = request.EmployeeCreateRequest.EmailAddress,
                PhoneNumber = request.EmployeeCreateRequest.PhoneNumber,
                StartDate = DateTime.SpecifyKind(request.EmployeeCreateRequest.StartDate, DateTimeKind.Utc),
                CafeId = request.EmployeeCreateRequest.CafeId,
                Gender = request.EmployeeCreateRequest.Gender,
                Id = "UI" + Guid.NewGuid().ToString("N")[..7].ToUpper() // Random EmployeeNumber
            };

            return await _employeesRepository.CreateEmployeeAsync(employee, cancellationToken);
        }
    }
}
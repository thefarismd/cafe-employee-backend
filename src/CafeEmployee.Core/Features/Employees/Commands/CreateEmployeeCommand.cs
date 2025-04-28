using CafeEmployee.Core.Features.Employees.DTO;
using MediatR;

namespace CafeEmployee.Core.Features.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<string>
    {
        public EmployeeCreateRequest EmployeeCreateRequest { get; }

        public CreateEmployeeCommand(EmployeeCreateRequest employeeCreateRequest)
        {
            EmployeeCreateRequest = employeeCreateRequest;
        }
    }
}
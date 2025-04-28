using MediatR;
using CafeEmployee.Core.Features.Employees.DTO;

namespace CafeEmployee.Core.Features.Employees.Commands
{
    public class UpdateEmployeeCommand : IRequest<bool>
    {
        public EmployeeUpdateRequest EmployeeUpdateRequest { get; }

        public UpdateEmployeeCommand(EmployeeUpdateRequest employeeUpdateRequest)
        {
            EmployeeUpdateRequest = employeeUpdateRequest;
        }
    }
}
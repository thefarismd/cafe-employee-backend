using MediatR;
using CafeEmployee.Core.Features.Employees.DTO;

namespace CafeEmployee.Core.Features.Employees.Commands
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public EmployeeDeleteRequest EmployeeDeleteRequest { get; }

        public DeleteEmployeeCommand(EmployeeDeleteRequest employeeDeleteRequest)
        {
            EmployeeDeleteRequest = employeeDeleteRequest;
        }
    }
}
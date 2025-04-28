using CafeEmployee.Core.Features.Employees.DTO;
using MediatR;

namespace CafeEmployee.Core.Features.Employees.Queries
{
    public class GetEmployeesQuery : IRequest<List<EmployeeResponse>>
    {
        public string? CafeName { get; }

        public GetEmployeesQuery(string? cafeName)
        {
            CafeName = cafeName;
        }
    }
}
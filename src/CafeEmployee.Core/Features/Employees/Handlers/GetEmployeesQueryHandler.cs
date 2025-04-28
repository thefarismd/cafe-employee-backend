using CafeEmployee.Core.Features.Employees.DTO;
using CafeEmployee.Core.Features.Employees.Queries;
using MediatR;
using CafeEmployee.Core.RepositoryContracts;

namespace CafeEmployee.Core.Features.Employees.Handlers
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<EmployeeResponse>>
    {
        private readonly IEmployeesRepository _employeesRepository;

        public GetEmployeesQueryHandler(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }
        public async Task<List<EmployeeResponse>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeesRepository.GetEmployeesAsync(request.CafeName, cancellationToken);

            return employees.Select(e => new EmployeeResponse
            {
                Id = e.Id,
                Name = e.Name,
                EmailAddress = e.EmailAddress,
                PhoneNumber = e.PhoneNumber,
                Gender = e.Gender,
                StartDate = e.StartDate,
                DaysWorked = (int)(DateTime.UtcNow - e.StartDate).TotalDays, 
                CafeName = e.Cafe != null ? e.Cafe.Name : "" 
            })
            .OrderByDescending(e => e.DaysWorked)
            .ToList();
        }
    }
}
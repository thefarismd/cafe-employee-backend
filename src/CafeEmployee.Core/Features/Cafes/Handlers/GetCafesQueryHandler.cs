using CafeEmployee.Core.RepositoryContracts;
using CafeEmployee.Core.Features.Cafes.DTO;
using CafeEmployee.Core.Features.Employees.DTO;
using MediatR;
using CafeEmployee.Core.Features.Cafes.Queries;

namespace CafeEmployee.Core.Features.Cafes.Handlers
{
    public class GetCafesQueryHandler : IRequestHandler<GetCafesQuery, List<CafeResponse>>

    {
        private readonly ICafesRepository _cafesRepository;

        public GetCafesQueryHandler(ICafesRepository cafesRepository)
        {
            _cafesRepository = cafesRepository;
        }

        public async Task<List<CafeResponse>> Handle(GetCafesQuery request, CancellationToken cancellationToken)
        {
            var cafes = await _cafesRepository.GetCafesAsync(request.Location, cancellationToken);

            return cafes.Select(c => new CafeResponse
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Logo = c.Logo,
                Location = c.Location,
                Employees = c.Employees.Select(e => new EmployeeResponse
                {
                    Id = e.Id,
                    Name = e.Name,
                    EmailAddress = e.EmailAddress,
                    PhoneNumber = e.PhoneNumber,
                    Gender = e.Gender,
                    StartDate = e.StartDate
                }).ToList(),
                TotalEmployees = c.Employees.Count 
            })
            .ToList();
        }
    }
}
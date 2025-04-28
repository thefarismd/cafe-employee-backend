using CafeEmployee.Core.Features.Cafes.DTO;
using MediatR;

namespace CafeEmployee.Core.Features.Cafes.Queries
{
    // Query to fetch cafes, optionally filtered by location
    public class GetCafesQuery : IRequest<List<CafeResponse>>
    {
        public string? Location { get; }

        public GetCafesQuery(string? location)
        {
            Location = location;
        }
    }
}
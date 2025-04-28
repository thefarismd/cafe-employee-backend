using CafeEmployee.Core.RepositoryContracts;
using MediatR;
using CafeEmployee.Core.Features.Cafes.Commands;
using CafeEmployee.Core.Domain.Entities;

namespace CafeEmployee.Core.Features.Cafes.Handlers
{
    public class CreateCafeCommandHandler : IRequestHandler<CreateCafeCommand, Guid>
    {
        private readonly ICafesRepository _cafeRepository;

        public CreateCafeCommandHandler(ICafesRepository cafesRepository)
        {
            _cafeRepository = cafesRepository;
        }

        public async Task<Guid> Handle(CreateCafeCommand request, CancellationToken cancellationToken)
        {

            var cafe = new Cafe
            {
                Id = Guid.NewGuid(),
                Name = request.CafeCreateRequest.Name,
                Description = request.CafeCreateRequest.Description,
                Logo = request.CafeCreateRequest.Logo,
                Location = request.CafeCreateRequest.Location
            };

            return await _cafeRepository.CreateCafeAsync(cafe, cancellationToken);

        }
    }
}
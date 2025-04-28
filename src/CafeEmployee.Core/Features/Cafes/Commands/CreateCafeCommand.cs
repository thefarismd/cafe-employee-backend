using MediatR;
using CafeEmployee.Core.Features.Cafes.DTO;

namespace CafeEmployee.Core.Features.Cafes.Commands
{
    public class CreateCafeCommand : IRequest<Guid>
    {
        public CafeCreateRequest CafeCreateRequest { get; }

        public CreateCafeCommand(CafeCreateRequest cafeCreateRequest)
        {
            CafeCreateRequest = cafeCreateRequest;
        }
    }
}
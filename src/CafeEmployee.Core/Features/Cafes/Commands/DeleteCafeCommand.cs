using MediatR;
using CafeEmployee.Core.Features.Cafes.DTO;

namespace CafeEmployee.Core.Features.Cafes.Commands
{
    public class DeleteCafeCommand : IRequest<bool>
    {
        public CafeDeleteRequest CafeDeleteRequest { get; }

        public DeleteCafeCommand(CafeDeleteRequest cafeDeleteRequest)
        {
            CafeDeleteRequest = cafeDeleteRequest;
        }
    }
}
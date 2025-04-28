using MediatR;
using CafeEmployee.Core.Features.Cafes.DTO;

namespace CafeEmployee.Core.Features.Cafes.Commands
{
    public class UpdateCafeCommand : IRequest<bool>
    {
        public CafeUpdateRequest CafeUpdateRequest { get; } 

        public UpdateCafeCommand(CafeUpdateRequest cafeUpdateRequest)
        {
            CafeUpdateRequest = cafeUpdateRequest;
        }
    }
}
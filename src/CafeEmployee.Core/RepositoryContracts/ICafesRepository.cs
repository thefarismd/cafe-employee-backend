using CafeEmployee.Core.Domain.Entities;

namespace CafeEmployee.Core.RepositoryContracts
{
    public interface ICafesRepository
    {
        Task<List<Cafe>> GetCafesAsync(string? location, CancellationToken cancellationToken);

        Task<Guid> CreateCafeAsync(Cafe cafe, CancellationToken cancellationToken);

        Task<bool> UpdateCafeAsync(Cafe cafe, CancellationToken cancellationToken);

        Task<bool> DeleteCafeAsync(Guid cafeId, CancellationToken cancellationToken);

    }
}
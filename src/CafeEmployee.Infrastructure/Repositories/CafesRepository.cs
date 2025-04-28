using CafeEmployee.Core.Domain.Entities;
using CafeEmployee.Core.RepositoryContracts;
using CafeEmployee.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace CafeEmployee.Infrastructure.Repositories
{
    public class CafesRepository : ICafesRepository
    {
        private readonly ApplicationDbContext _context;

        public CafesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cafe>> GetCafesAsync(string? location, CancellationToken cancellationToken)
        {
            var query = _context.Cafes
            .Include(c => c.Employees)
            .AsQueryable();

            if (!string.IsNullOrWhiteSpace(location))
            {
                query = query.Where(e =>
                    e.Location != null &&
                    e.Location.ToLower().Contains(location.Trim().ToLower()));
            }

            return await query
                .OrderByDescending(c => c.Employees.Count)
                .ToListAsync(cancellationToken);
        }

        public async Task<Guid> CreateCafeAsync(Cafe cafe, CancellationToken cancellationToken)
        {
            _context.Cafes.Add(cafe);
            await _context.SaveChangesAsync(cancellationToken);
            return cafe.Id;
        }

        public async Task<bool> UpdateCafeAsync(Cafe cafe, CancellationToken cancellationToken)
        {
            var existingCafe = await _context.Cafes.FirstOrDefaultAsync(c => c.Id == cafe.Id, cancellationToken);

            if (existingCafe == null) return false;

            existingCafe.Name = cafe.Name;
            existingCafe.Description = cafe.Description;
            existingCafe.Logo = cafe.Logo;
            existingCafe.Location = cafe.Location;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteCafeAsync(Guid cafeId, CancellationToken cancellationToken)
        {
            var existingCafe = await _context.Cafes
            .Include(c => c.Employees) // include employees
            .FirstOrDefaultAsync(c => c.Id == cafeId, cancellationToken);

            if (existingCafe == null) return false;

            // Remove all employees first
            _context.Employees.RemoveRange(existingCafe.Employees);

            // Then remove the cafe
            _context.Cafes.Remove(existingCafe);

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
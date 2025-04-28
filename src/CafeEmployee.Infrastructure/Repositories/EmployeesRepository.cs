using CafeEmployee.Core.Domain.Entities;
using CafeEmployee.Core.RepositoryContracts;
using CafeEmployee.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;


namespace CafeEmployee.Infrastructure.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployeesAsync(string? cafeName, CancellationToken cancellationToken)
        {
            var query = _context.Employees
            .Include(e => e.Cafe)
            .AsQueryable();

            if (!string.IsNullOrWhiteSpace(cafeName))
            {
                query = query.Where(e =>
                    e.Cafe != null &&
                    e.Cafe.Name.ToLower().Contains(cafeName.Trim().ToLower()));
            }

            return await query
                .OrderByDescending(e => e.StartDate) 
                .ToListAsync(cancellationToken);

        }

        public async Task<string> CreateEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {
            var existingEmployee = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == employee.Id, cancellationToken);

            if (existingEmployee == null) return false;

            existingEmployee.Name = employee.Name;
            existingEmployee.EmailAddress = employee.EmailAddress;
            existingEmployee.PhoneNumber = employee.PhoneNumber;
            existingEmployee.StartDate = employee.StartDate;
            existingEmployee.CafeId = employee.CafeId;
            existingEmployee.Gender = employee.Gender;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(string employeeId, CancellationToken cancellationToken)
        {
            var existingEmployee = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == employeeId, cancellationToken);

            if (existingEmployee == null) return false;

            _context.Employees.Remove(existingEmployee);

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
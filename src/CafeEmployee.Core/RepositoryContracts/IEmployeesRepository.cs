using CafeEmployee.Core.Domain.Entities;

namespace CafeEmployee.Core.RepositoryContracts
{
    public interface IEmployeesRepository
    {
        Task<List<Employee>> GetEmployeesAsync(string? cafeName, CancellationToken cancellationToken);

        Task<string> CreateEmployeeAsync(Employee employee, CancellationToken cancellationToken);

        Task<bool> UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken);

        Task<bool> DeleteEmployeeAsync(string employeeId, CancellationToken cancellationToken);


    }
}
using CafeEmployee.Core.Domain.Entities;
using CafeEmployee.Core.Enums;

namespace CafeEmployee.Infrastructure.DBContext


{
    public class DBSeeder
    {
        public static void SeedInitialData(ApplicationDbContext context)
        {
            // Prevent seeding if data already exists
            if (context.Cafes.Any()) return;

            // Create sample cafes
            var cafes = new List<Cafe>
            {
                new Cafe { Id = Guid.NewGuid(), Name = "Kopi Kita", Description = "Friendly spot for coffee lovers", Location = "Orchard Road" },
                new Cafe { Id = Guid.NewGuid(), Name = "LatteKu", Description = "Tech cafe with fast Wi-Fi", Location = "Bugis" },
                new Cafe { Id = Guid.NewGuid(), Name = "BeanBui", Description = "Creative drinks and chill vibes", Location = "Tampines" },
                new Cafe { Id = Guid.NewGuid(), Name = "BrewIndo", Description = "Built for remote workers", Location = "Raffles Place" },
                new Cafe { Id = Guid.NewGuid(), Name = "Cafe Ria", Description = "Stylish hangout with local beans", Location = "Tiong Bahru" }
            };

            context.Cafes.AddRange(cafes);

            // Create sample employees (1 per cafe)
            var employees = new List<Employee>
            {
                new Employee { Id = "UI1000001", Name = "Ali Ahmad", EmailAddress = "ali@example.com", PhoneNumber = "81234567", Gender = GenderOptions.Male, CafeId = cafes[0].Id, StartDate = DateTime.UtcNow.AddMonths(-2) },
                new Employee { Id = "UI1000002", Name = "Nur Aisy", EmailAddress = "aisyah@example.com", PhoneNumber = "92234567", Gender = GenderOptions.Female, CafeId = cafes[1].Id, StartDate = DateTime.UtcNow.AddMonths(-4) },
                new Employee { Id = "UI1000003", Name = "John Tan", EmailAddress = "john@example.com", PhoneNumber = "83214567", Gender = GenderOptions.Male, CafeId = cafes[2].Id, StartDate = DateTime.UtcNow.AddMonths(-1) },
                new Employee { Id = "UI1000004", Name = "Siti Zula", EmailAddress = "siti@example.com", PhoneNumber = "81238765", Gender = GenderOptions.Female, CafeId = cafes[3].Id, StartDate = DateTime.UtcNow.AddMonths(-3) },
                new Employee { Id = "UI1000005", Name = "Mike Lim", EmailAddress = "michael@example.com", PhoneNumber = "84234567", Gender = GenderOptions.Male, CafeId = cafes[4].Id, StartDate = DateTime.UtcNow.AddMonths(-5) }
            };

            context.Employees.AddRange(employees);

            // Save everything to the database
            context.SaveChanges();
        }
    }
}
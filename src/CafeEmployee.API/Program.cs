using Microsoft.EntityFrameworkCore;
using CafeEmployee.Infrastructure.DBContext;
using MediatR;
using CafeEmployee.Infrastructure.Repositories;
using CafeEmployee.Core.RepositoryContracts;
using CafeEmployee.Core;
using dotenv.net;
using Autofac; 
using Autofac.Extensions.DependencyInjection;
using CafeEmployee.API.Middlewares;
using CafeEmployee.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();

// Use Autofac as DI container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());


// Register services inside Autofac
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<CafesRepository>().As<ICafesRepository>();
    containerBuilder.RegisterType<EmployeesRepository>().As<IEmployeesRepository>();
});

// Add other services your app will use
builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(AssemblyReference).Assembly);
// builder.Services.AddScoped<ICafesRepository, CafesRepository>();
// builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();

builder.Services.ConfigureCustomApiBehavior();

var dbConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

if (string.IsNullOrWhiteSpace(dbConnectionString))
{
    dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}

// Connect to PostgreSQL using your connection string in appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(dbConnectionString,
    npgsqlOptions => npgsqlOptions.MigrationsAssembly("CafeEmployee.Infrastructure")
));

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();
//app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapGet("/", ()=> "The Application is running!");

app.MapControllers();

// Call the seeder
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DBSeeder.SeedInitialData(context);
}

app.Run();

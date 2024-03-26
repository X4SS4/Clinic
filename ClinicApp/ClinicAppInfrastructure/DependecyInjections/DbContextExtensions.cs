namespace ClinicAppInfrastructure.DependecyInjections;

using System.Reflection;
using ClinicAppInfrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DbContextExtensions
{
    public static void InitDbContext(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        Assembly migrationsAssembly)
    {
        serviceCollection.AddDbContext<ClinicAppDbContext>(options =>
        {
            string connectionKey = "IdentityCLinicDB";
            string? connectionString = configuration.GetConnectionString("DefaultConnectionString");
            if (string.IsNullOrEmpty(connectionString)) throw new NullReferenceException($"Connection string with a key '{connectionKey}' is not found in settings file");
            options.UseSqlServer(connectionString, options => options.MigrationsAssembly(migrationsAssembly.FullName));
        });

        serviceCollection.AddIdentityCore<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ClinicAppDbContext>();
    }
}
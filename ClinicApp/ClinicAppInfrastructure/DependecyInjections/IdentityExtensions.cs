namespace ClinicAppInfrastructure.DependecyInjections;

using System.Reflection;
using ClinicAppInfrastructure.Data;
using Microsoft.AspNetCore.Identity;
using ClinicAppCore.Employee.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class IdentityExtensions
{
    public static void InitIdentity(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddIdentity<Employee, IdentityRole<int>>(options =>
        {
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 5;
            options.Password.RequireNonAlphanumeric = false;
            options.Lockout.AllowedForNewUsers = false;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(60);
            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<ClinicAppDbContext>();
    }
}
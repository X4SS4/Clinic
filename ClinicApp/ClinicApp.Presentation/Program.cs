using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ClinicApp.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using ClinicApp.Presentation.Middlewares;
using ClinicApp.Core.Employees.Entities;
using ClinicApp.Core.Logging.Entities;
using ClinicApp.Infrastructure.Patients.Repositories.Base;
using ClinicApp.Infrastructure.Patients.Repositories;
using ClinicApp.Infrastructure.Logging.Repositories.Base;
using ClinicApp.Infrastructure.Logging.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ClinicAppDbContext>(options =>
{
    string connectionKey = "IdentityCLinicDB";
    string? connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new NullReferenceException($"Connection string with a key '{connectionKey}' is not found in settings file");
    }
    options.UseSqlServer(connectionString, options =>
    {
        options.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
    });
});

builder.Services.AddIdentity<Employee, IdentityRole<int>>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Lockout.AllowedForNewUsers = false; //admin aprove need in future!!!
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(60);
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ClinicAppDbContext>();

builder.Services.Configure<LoggerSwitch>(builder.Configuration.GetSection("LoggerSwitch"));

builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<ClinicAppDbContext>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<ILogRecordRepository, LogRecordRepository>();

builder.Services.AddTransient<LoggingMiddleware>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<LoggingMiddleware>();
app.MapDefaultControllerRoute();

app.Run();

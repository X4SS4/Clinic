using System.Security.Claims;
using ClinicApp.Core.Models.ManageTools;
using ClinicApp.Presentation.Middlewares;
using Microsoft.AspNetCore.Authentication.Cookies;
using ClinicApp.Infrastructure.Repositories.Doctor;
using ClinicApp.Infrastructure.Repositories.Logging;
using ClinicApp.Infrastructure.Repositories.Patient;
using ClinicApp.Infrastructure.Repositories.Doctor.Base;
using ClinicApp.Infrastructure.Repositories.Logging.Base;
using ClinicApp.Infrastructure.Repositories.Patient.Base;
using ClinicApp.Infrastructure.Repositories.MedicalEmployee;
using ClinicApp.Infrastructure.Repositories.MedicalEmployee.Base;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{
    options.LoginPath = "/Home/Login";
    options.AccessDeniedPath = "/Home/AccessDenied";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admins", policy =>
    {
        policy.RequireRole(ClaimTypes.Role, AccessRoles.Admin.ToString());
    });
});

string connectionKey = "BonaDeaDB";
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

if (string.IsNullOrEmpty(connectionString))
{
    throw new NullReferenceException($"Connection string with a key '{connectionKey}' is not found in settings file");
}

builder.Services.Configure<ConnectionTools>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.Configure<LoggerSwitch>(builder.Configuration.GetSection("LoggerSwitch"));

builder.Services.AddScoped<IMedicalEmployeeRepository, MedicalEmployeeRepository>();
builder.Services.AddScoped<ILogRecordRepository, LogRecordRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

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

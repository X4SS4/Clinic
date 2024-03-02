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
using Microsoft.EntityFrameworkCore;
using ClinicApp.Infrastructure.Data;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using ClinicApp.Core.Models.ClinicEntities.MedicalEmployee;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admins", policy =>
    {
        policy.RequireRole(ClaimTypes.Role, AccessRoles.Admin.ToString());
    });
});

var assembly = 

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

builder.Services.AddIdentity<MedicalEmployee, IdentityRole<int>>(options =>
{
    options.Password.RequiredLength = 8;
}
).AddEntityFrameworkStores<ClinicAppDbContext>();

builder.Services.ConfigureApplicationCookie(o => {
    o.AccessDeniedPath = "/Home/index";
    o.LoginPath = "/Home/index";
});

builder.Services.Configure<LoggerSwitch>(builder.Configuration.GetSection("LoggerSwitch"));

builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<ClinicAppDbContext>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
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

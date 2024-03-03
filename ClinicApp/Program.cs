using ClinicApp.Middlewares;
using ClinicApp.Models.ManageTools;
using ClinicApp.Repositories.Doctor;
using ClinicApp.Repositories.Logging;
using ClinicApp.Repositories.Logging.Base;
using ClinicApp.Repositories.MedicalReceptionist;
using ClinicApp.Repositories.MedicalReceptionist.Base;
using ClinicApp.Repositories.Patient;
using Repositories.Doctor.Base;
using Repositories.Patient.Base;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

string connectionKey = "BonaDeaDB";
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

if (string.IsNullOrEmpty(connectionString))
{
    throw new NullReferenceException($"Connection string with a key '{connectionKey}' is not found in settings file");
}

builder.Services.Configure<ConnectionTools>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.Configure<LoggerSwitch>(builder.Configuration.GetSection("LoggerSwitch"));

builder.Services.AddScoped<IMedicalReceptionistRepository, MedicalReceptionistRepository>();
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
app.UseAuthorization();
app.UseMiddleware<LoggingMiddleware>();
app.MapDefaultControllerRoute();

app.Run();

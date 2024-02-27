using ClinicApp.Models.ManageTools;
using ClinicApp.Repositories.Doctor;
using ClinicApp.Repositories.Patient;
using Repositories.Doctor.Base;
using Repositories.Patient.Base;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.Configure<ConnectionTools>(builder.Configuration.GetSection("ConnectionString"));
builder.Services.Configure<LoggerSwitch>(builder.Configuration.GetSection("LoggerSwitch"));

builder.Services.AddSingleton<IDoctorRepository, DoctorRepository>();
builder.Services.AddSingleton<IPatientRepository, PatientRepository>();

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
app.MapDefaultControllerRoute();

app.Run();

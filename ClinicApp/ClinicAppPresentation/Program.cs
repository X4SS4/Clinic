using ClinicAppCore.Logging.Entities;
using ClinicAppPresentation.Middlewares;
using ClinicAppCore.Logging.Repositories;
using ClinicAppInfrastructure.Logging.Repositories;
using ClinicAppInfrastructure.DependecyInjections;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.InitIdentity();
builder.Services.InitDbContext(builder.Configuration, System.Reflection.Assembly.GetExecutingAssembly());
builder.Services.Configure<LoggerSwitch>(builder.Configuration.GetSection("LoggerSwitch"));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
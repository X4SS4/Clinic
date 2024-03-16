namespace ClinicApp.Infrastructure.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ClinicApp.Core.Logging.Entities;
using ClinicApp.Core.Patients.Entities;
using ClinicApp.Core.Employees.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class ClinicAppDbContext : IdentityDbContext<Employee, IdentityRole<int>, int>
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientCard> PatientsCards { get; set; }
    public DbSet<DiseaseRecord> DiseaseRecords { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<LogRecord> LogRecords { get; set; }
    public DbSet<EmployeePatient> EmployeePatients { get; set; }
    public ClinicAppDbContext(DbContextOptions<ClinicAppDbContext> options) : base(options) { }
}
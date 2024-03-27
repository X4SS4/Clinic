namespace ClinicAppInfrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ClinicAppCore.Patient.Entities;
using ClinicAppCore.Logging.Entities;
using ClinicAppCore.Employee.Entities;
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
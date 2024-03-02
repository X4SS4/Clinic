namespace ClinicApp.Infrastructure.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ClinicApp.Core.Models.ClinicEntities.Doctor;
using ClinicApp.Core.Models.ClinicEntities.Patient;
using ClinicApp.Core.Models.LoggingEntities.LogRecord;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ClinicApp.Core.Models.ClinicEntities.DoctorPatient;
using ClinicApp.Core.Models.ClinicEntities.MedicalEmployee;

public class ClinicAppDbContext : IdentityDbContext<MedicalEmployee, IdentityRole<int>, int>
{
    public DbSet<MedicalEmployee> Employees { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<LogRecord> LogRecords { get; set; }

    public DbSet<DoctorPatient> DoctorPatients { get; set; }

    public ClinicAppDbContext(DbContextOptions<ClinicAppDbContext> options) : base(options) { }
}
namespace ClinicAppInfrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ClinicAppCore.Logging.Entities;
using ClinicAppCore.Employee.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class ClinicAppDbContext : IdentityDbContext<Employee, IdentityRole<int>, int>
{
    public DbSet<LogRecord> LogRecords { get; set; }
    public ClinicAppDbContext(DbContextOptions<ClinicAppDbContext> options) : base(options) { }
}

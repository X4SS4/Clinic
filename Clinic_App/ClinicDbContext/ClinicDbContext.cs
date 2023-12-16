using Clinic.Models.Persons;
using Microsoft.EntityFrameworkCore;

namespace Clinic.ClinicDbContext;

public class ClinicDbContext : DbContext
{

    public DbSet<Staff> Staff { get; set; }
    public DbSet<Cabinet> Cabinets { get; set; }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<DiseaseHistory> Diseases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = $"Server=localhost;Database=ClinicDB;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False;";
        optionsBuilder.UseSqlServer(connectionString);
        base.OnConfiguring(optionsBuilder);
    }
}

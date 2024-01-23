using Clinic_App.Models.Persons;
using Clinic_App.Models.Persons.PatientEntities;
using Clinic_App.Models.Persons.StaffEntities;
using Clinic_App.Models.Rooms;
using Microsoft.EntityFrameworkCore;

namespace Clinic_App.Clinic_db_ef
{
    public class ClinicDbContext : DbContext
    {
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<StaffContract> StaffContracts { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientCard> Cards { get; set; }
        public DbSet<DiseaseHistory> DiseaseHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=ClinicDB;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
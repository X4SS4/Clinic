namespace ClinicApp.Infrastructure.Repositories.Patient.Base;

using ClinicApp.Core.Models.ClinicEntities.Patient;
using ClinicApp.Core.Models.ClinicEntities.Doctor;

public interface IPatientRepository
{
    Task<Patient> GetPatientByFIN(string? patientFIN);
    Task<IEnumerable<Patient>> GetPatientsByDoctor(Doctor doctor);
    Task<IEnumerable<Patient>> GetAllPatients();
    Task AddPatient(Patient patient);
}
namespace ClinicApp.Infrastructure.Repositories.Patient.Base;

using ClinicApp.Core.Models.ClinicEntities.Patient;

public interface IPatientRepository
{
    Task<Patient> GetPatientByFIN(string? patientFIN);
    Task<IEnumerable<Patient>> GetPatientsByDoctor(string doctorFIN);
    Task<IEnumerable<Patient>> GetAllPatients();
    Task<Patient> AddPatient(Patient patient);
}
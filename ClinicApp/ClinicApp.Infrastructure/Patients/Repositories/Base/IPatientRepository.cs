namespace ClinicApp.Infrastructure.Patients.Repositories.Base;

using ClinicApp.Core.Patients.Entities;

public interface IPatientRepository
{
    Task<Patient> GetPatientByFIN(string? patientFIN);
    Task<IEnumerable<Patient>> GetPatientsByDoctor(string doctorFIN);
    Task<IEnumerable<Patient>> GetAllPatients();
    Task<Patient> AddPatient(Patient patient);
}
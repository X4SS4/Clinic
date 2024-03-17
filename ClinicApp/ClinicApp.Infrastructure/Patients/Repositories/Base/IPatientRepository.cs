namespace ClinicApp.Infrastructure.Patients.Repositories.Base;

using ClinicApp.Core.Patients.Entities;

public interface IPatientRepository
{
    Task<Patient> GetPatientByFIN(string? patientFIN);
    Task<IEnumerable<Patient>> GetPatientsByDoctor(int doctorId);
    Task<IEnumerable<Patient>> GetAllPatients();
    Task<Patient> AddPatient(Patient patient);
}
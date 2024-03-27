namespace ClinicAppCore.Patient.Repositories;

using ClinicAppCore.Patient.Entities;

public interface IPatientRepository
{
    Task Discharge(int patientId, int doctorId);


    Task<Patient> GetPatientByFIN(string? patientFIN);
    Task<IEnumerable<Patient>> GetPatientsByDoctor(int doctorId);
    Task<IEnumerable<Patient>> GetAllPatients();
    Task<Patient> AddPatient(Patient patient);
}
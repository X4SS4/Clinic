namespace ClinicApp.Infrastructure.Patients.Services.Base;

using ClinicApp.Core.Employees.Entities;
using ClinicApp.Core.Patients.Entities;

public interface IPatientService
{
    Task AddPatientToDoctor(EmployeePatient doctorPatient);
    Task<Patient> GetPatient(string patientFIN);
    Task<IEnumerable<Patient>> GetAllPatients();
    Task<IEnumerable<Patient>> GetPatientsByDoctor(int doctorId);
    Task<PatientCard> GetPatientCard(int patientId);
    Task<IEnumerable<DiseaseRecord>> GetDiseaseRecords(int patientId);
    Task DischargePatient(Patient patient, Employee doctor);
    Task CreateDiseaseRecord(int patientCardID, Employee doctor);
    Task EditDiseaseRecord(DiseaseRecord diseaseRecord, string description);
}
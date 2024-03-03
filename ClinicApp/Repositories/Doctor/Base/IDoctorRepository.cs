namespace Repositories.Doctor.Base;

using ClinicApp.Models.ClinicEntities.Doctor;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> GetDoctorsByMedicalDepartment(int medicalDepartment);
    Task<Doctor> GetDoctorByFIN(string? doctorFIN);
    Task AddPatientToDoctor(int doctorId, int patientId);
    Task<IEnumerable<Doctor>> GetAllDoctors();
}
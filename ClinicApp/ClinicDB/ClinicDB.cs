namespace ClinicApp.ClinicDB;

using ClinicApp.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


public class BonadeaDB : DbContext
{
    private readonly string connectionString = "Server=localhost;Database=BonaDeaDB;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True";
    public async Task<IEnumerable<Doctor>> GetDoctorsByMedicalDepartment(int medicalDepartment)
    {
        using var connection = new SqlConnection(connectionString);

        string getDoctorByDepartmentQuery = @"SELECT * FROM Doctors WHERE MEDICALDEPARTMENT = @MedicalDepartment";
        var doctors = await connection.QueryAsync<Doctor>(getDoctorByDepartmentQuery, new { MedicalDepartment = medicalDepartment });
        return doctors;

    }

    public async Task<Doctor> GetDoctorByFIN(string? doctorFIN)
    {
        using var connection = new SqlConnection(connectionString);

        string getDoctorByFINQuery = @"SELECT * FROM Doctors WHERE FIN = @FIN";
        var doctor = await connection.QueryFirstOrDefaultAsync<Doctor>(getDoctorByFINQuery, new { FIN = doctorFIN }) ?? new Doctor();
        return doctor;

    }
    public async Task<Patient> GetPatientByFIN(string? patientFIN)
    {
        using var connection = new SqlConnection(connectionString);

        string getPatientByFINQuery = @"SELECT * FROM Patients WHERE FIN = @FIN";
        var patient = await connection.QueryFirstOrDefaultAsync<Patient>(getPatientByFINQuery, new { FIN = patientFIN }) ?? new Patient();
        return patient;
    }

    public async Task AddPatientToDoctor(int doctorId, int patientId)
    {
        using var connection = new SqlConnection(connectionString);

        string insertDoctorPatientQuery = @"INSERT INTO DoctorPatient (DoctorId, PatientId) 
VALUES (@DoctorId, @PatientId)";
        await connection.ExecuteAsync(insertDoctorPatientQuery,
            new { DoctorId = doctorId, PatientId = patientId });
    }

    public async Task<IEnumerable<Patient>> GetPatients(Doctor doctor)
    {
        using var connection = new SqlConnection(connectionString);

        string getPatientsByDoctorQuery = @"SELECT p.* FROM Patients p 
INNER JOIN DoctorPatient dp ON p.PatientId = dp.PatientId 
WHERE dp.DoctorId = @DoctorId";
        var patients = await connection.QueryAsync<Patient>(getPatientsByDoctorQuery,
            new { DoctorId = doctor.Id });
        return patients;
    }

    public async Task<IEnumerable<Patient>> GetAllPatients()
    {
        using var connection = new SqlConnection(connectionString);

        string getPatientsQuery = @"SELECT * FROM Patients";
        var patients = await connection.QueryAsync<Patient>(getPatientsQuery);
        return patients;
    }

    public async Task<IEnumerable<Doctor>> GetAllDoctors()
    {
        using var connection = new SqlConnection(connectionString);

        string getDoctorsByDoctorQuery = @"SELECT * FROM Doctors";
        var doctors = await connection.QueryAsync<Doctor>(getDoctorsByDoctorQuery);
        return doctors;
    }

    public async Task AddPatient(Patient patient)
    {
        string addPatientQuery = @"INSERT INTO Patients (FIN, Firstname, Lastname, Email) 
VALUES (@FIN, @FirstName, @LastName, @Email)";
        using var connection = new SqlConnection(connectionString);
        var products = await connection.ExecuteAsync(addPatientQuery,
            param: new
            {
                FirstName = patient.Firstname,
                LastName = patient.Lastname,
                FIN = patient.FIN,
                Email = patient.Email
            });
    }

    public async Task<IEnumerable<Patient>> GetPatientsByDoctor(string doctorFIN)
    {
        using var connection = new SqlConnection(connectionString);

        string getPatientsByDoctorQuery = @"SELECT Patients.* 
FROM Patients 
INNER JOIN DoctorPatient ON Patients.Id = DoctorPatient.PatientId 
INNER JOIN Doctors ON DoctorPatient.DoctorId = Doctors.Id 
WHERE Doctors.FIN = @DoctorFIN;";
        var patients = await connection.QueryAsync<Patient>(getPatientsByDoctorQuery, new { DoctorFIN = doctorFIN });
        return patients;
    }
}

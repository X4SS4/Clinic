using Repositories.Patient.Base;

namespace ClinicApp.Repositories.Patient;

using System.Data.SqlClient;
using ClinicApp.Models;
using Dapper;

public class PatientRepository : IPatientRepository
{
    private const string connectionString = 
        @"Server=localhost;Database=BonaDeaDB;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True";

    private readonly SqlConnection connection = new SqlConnection(connectionString);

    public async Task<Patient> GetPatientByFIN(string? patientFIN)
    {
        string getPatientByFINQuery = @"SELECT * FROM Patients WHERE FIN = @FIN";
        var patient = await connection.QueryFirstOrDefaultAsync<Patient>(getPatientByFINQuery, new { FIN = patientFIN }) ?? new Patient();
        return patient;
    }
    public async Task<IEnumerable<Patient>> GetPatients(Doctor doctor)
    {
        string getPatientsByDoctorQuery = @"SELECT p.* FROM Patients p 
INNER JOIN DoctorPatient dp ON p.PatientId = dp.PatientId 
WHERE dp.DoctorId = @DoctorId";
        var patients = await connection.QueryAsync<Patient>(getPatientsByDoctorQuery,
            new { DoctorId = doctor.Id });
        return patients;
    }
    public async Task<IEnumerable<Patient>> GetAllPatients()
    {
        string getPatientsQuery = @"SELECT * FROM Patients";
        var patients = await connection.QueryAsync<Patient>(getPatientsQuery);
        return patients;
    }
    public async Task AddPatient(Patient patient)
    {
        string addPatientQuery = @"INSERT INTO Patients (FIN, Firstname, Lastname, Email) 
VALUES (@FIN, @FirstName, @LastName, @Email)";
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

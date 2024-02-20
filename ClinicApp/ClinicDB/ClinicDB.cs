using ClinicApp.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.ClinicDB
{
    public class BonadeaDB : DbContext
    {
        private readonly string connectionString = "Server=localhost;Database=BonaDeaDB;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True";
        
        public async Task<IEnumerable<Doctor>> GetDoctorsByMedicalDepartment(int medicalDepartment)
        {
            using var connection = new SqlConnection(connectionString);

            string getDoctorByDepartmentQuery = "SELECT * FROM Doctors WHERE MEDICALDEPARTMENT = @MedicalDepartment";
            var doctors = await connection.QueryAsync<Doctor>(getDoctorByDepartmentQuery, new {MedicalDepartment = medicalDepartment});
            return doctors;
        }

        public async Task AddPatientToDoctor(Doctor doctor, Patient patient)
        {
            using var connection = new SqlConnection(connectionString);

            string insertDoctorPatientQuery = @"INSERT INTO DoctorPatient (DoctorId, PatientId) 
VALUES (@DoctorId, @PatientId)";
            await connection.ExecuteAsync(insertDoctorPatientQuery, 
                new { DoctorId = doctor.Id, PatientId = patient.Id });
        }

        public async Task<IEnumerable<Patient>> GetPatients(Doctor doctor)
        {
            using var connection = new SqlConnection(connectionString);
            
            string getPatientsByDoctorQuery = @"
            SELECT p.*
            FROM Patients p
            INNER JOIN DoctorPatient dp ON p.PatientId = dp.PatientId
            WHERE dp.DoctorId = @DoctorId";
            var patients = await connection.QueryAsync<Patient>(getPatientsByDoctorQuery, 
                new { DoctorId = doctor.Id});
            return patients;
        }

        public async Task AddPatient(Patient patient)
        {
            string addPatientQuery = "INSERT INTO Patients (FirstName, LastName, Email) VALUES (@FirstName, @LastName, @Email)";
            using var connection = new SqlConnection(connectionString);
            var products = await connection.ExecuteAsync( addPatientQuery,
                param: new
                {
                    FirstName = patient.Firstname,
                    LastName = patient.Lastname,
                    Email = patient.Email
                });
        }
    }
}
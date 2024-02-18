using ClinicApp.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace ClinicApp.ClinicDB
{
    public class ClinicDB : DbContext
    {
        private readonly string connectionString = "Server=localhost;Database=ClinicDB;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True";
        
        public async Task<IEnumerable<Doctor>> GetDoctorsByMedicalDepartment(int MedicalDepartment)
        {
            using var connection = new SqlConnection(connectionString);
            var doctors = await connection.QueryAsync<Doctor>("SELECT * FROM Doctors WHERE MEDICALDEPARTMENT = 2");
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
            string getPatientsByDoctorQuery = @"
            SELECT p.*
            FROM Patients p
            INNER JOIN DoctorPatient dp ON p.PatientId = dp.PatientId
            WHERE dp.DoctorId = @DoctorId";

            using var connection = new SqlConnection(connectionString);
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
                    patient.FirstName,
                    patient.LastName,
                    patient.Email
                });
        }
    }
}
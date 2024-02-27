using Repositories.Doctor.Base;

namespace ClinicApp.Repositories.Doctor;

using Dapper;
using ClinicApp.Models.ClinicEntities.Doctor;
using System.Data.SqlClient;
using ClinicApp.Models.ManageTools;
using Microsoft.Extensions.Options;

public class DoctorRepository : IDoctorRepository
{
    private readonly SqlConnection connection;
    public DoctorRepository(IOptions<ConnectionTools> connectionTools)
    {
        this.connection = new SqlConnection(connectionTools.Value.DefaultConnectionString);
    }

    public async Task<IEnumerable<Doctor>> GetDoctorsByMedicalDepartment(int medicalDepartment)
    {
        string getDoctorByDepartmentQuery = @"SELECT * FROM Doctors WHERE MEDICALDEPARTMENT = @MedicalDepartment";
        var doctors = await connection.QueryAsync<Doctor>(getDoctorByDepartmentQuery, new { MedicalDepartment = medicalDepartment });
        return doctors;
    }
    public async Task<Doctor> GetDoctorByFIN(string? doctorFIN)
    {
        string getDoctorByFINQuery = @"SELECT * FROM Doctors WHERE FIN = @FIN";
        var doctor = await connection.QueryFirstOrDefaultAsync<Doctor>(getDoctorByFINQuery, new { FIN = doctorFIN }) ?? new Doctor();
        return doctor;
    }
    public async Task AddPatientToDoctor(int doctorId, int patientId)
    {
        string insertDoctorPatientQuery = @"INSERT INTO DoctorPatient (DoctorId, PatientId) 
VALUES (@DoctorId, @PatientId)";
        await connection.ExecuteAsync(insertDoctorPatientQuery,
            new { DoctorId = doctorId, PatientId = patientId });
    }
    public async Task<IEnumerable<Doctor>> GetAllDoctors()
    {
        string getDoctorsByDoctorQuery = @"SELECT * FROM Doctors";
        var doctors = await connection.QueryAsync<Doctor>(getDoctorsByDoctorQuery);
        return doctors;
    }
}

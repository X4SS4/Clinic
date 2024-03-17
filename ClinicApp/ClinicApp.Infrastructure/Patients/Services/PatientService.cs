namespace ClinicApp.Infrastructure.Patients.Services;

using System.Threading.Tasks;
using System.Collections.Generic;
using ClinicApp.Core.Patients.Entities;
using ClinicApp.Core.Employees.Entities;
using ClinicApp.Infrastructure.Patients.Services.Base;
using ClinicApp.Infrastructure.Patients.Repositories.Base;

public class PatientService : IPatientService
{
    public readonly IPatientRepository patientRepository;
    public PatientService(IPatientRepository patientRepository)
    {
        this.patientRepository = patientRepository;
    }

    public Task AddPatientToDoctor(EmployeePatient doctorPatient)
    {
        throw new NotImplementedException();
    }

    public Task CreateDiseaseRecord(int patientCard, Employee doctor)
    {
        throw new NotImplementedException();
    }

    public Task DischargePatient(Patient patient, Employee doctor)
    {
        throw new NotImplementedException();
    }

    public Task EditDiseaseRecord(DiseaseRecord diseaseRecord, string description)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Patient>> GetAllPatients()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PatientCard>> GetDiseaseRecords(int patientId)
    {
        throw new NotImplementedException();
    }

    public Task<Patient> GetPatient(string patientFIN)
    {
        throw new NotImplementedException();
    }

    public Task<PatientCard> GetPatientCard(int patientId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Patient>> GetPatientsByDoctor(int doctorId)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<DiseaseRecord>> IPatientService.GetDiseaseRecords(int patientId)
    {
        throw new NotImplementedException();
    }
}

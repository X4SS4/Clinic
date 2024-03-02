namespace ClinicApp.Infrastructure.Repositories.Patient;

using ClinicApp.Infrastructure.Data;
using ClinicApp.Core.Models.ClinicEntities.Doctor;
using ClinicApp.Core.Models.ClinicEntities.Patient;
using ClinicApp.Infrastructure.Repositories.Patient.Base;
using System.Threading.Tasks;
using System.Collections.Generic;

public class PatientRepository : IPatientRepository
{
    private readonly ClinicAppDbContext _context;
    public PatientRepository(ClinicAppDbContext _context)
    {
        this._context = _context;
    }

    public Task AddPatient(Patient patient)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Patient>> GetAllPatients()
    {
        throw new NotImplementedException();
    }

    public Task<Patient> GetPatientByFIN(string? patientFIN)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Patient>> GetPatients(Doctor doctor)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Patient>> GetPatientsByDoctor(string doctorFIN)
    {
        throw new NotImplementedException();
    }

    //public async Task<Patient> GetPatientByFIN(string? patientFIN)
    //{

    //}
    //public async Task<IEnumerable<Patient>> GetPatients(Doctor doctor)
    //{

    //}
    //public async Task<IEnumerable<Patient>> GetAllPatients()
    //{

    //}
    //public async Task AddPatient(Patient patient)
    //{

    //}
    //public async Task<IEnumerable<Patient>> GetPatientsByDoctor(string doctorFIN)
    //{

    //}
}

namespace ClinicAppInfrastructure.Patient.Repositories;

using ClinicAppCore.Patient.Repositories;
using ClinicAppInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class PatientRepository : IPatientRepository
{
    public ClinicAppDbContext _context { get; }
    public PatientRepository(ClinicAppDbContext _context)
    {
        this._context = _context;
    }

    public async Task Discharge(int patientId, int doctorId)
    {
        var deleteEntity = await this._context.EmployeePatients.FirstOrDefaultAsync(entity => entity.PatientId == patientId && entity.EmployeeId == doctorId);
        this._context.EmployeePatients.Remove(deleteEntity);
        await this._context.SaveChangesAsync();
    }

    public Task<ClinicAppCore.Patient.Entities.Patient> AddPatient(ClinicAppCore.Patient.Entities.Patient patient)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ClinicAppCore.Patient.Entities.Patient>> GetAllPatients()
    {
        throw new NotImplementedException();
    }

    public Task<ClinicAppCore.Patient.Entities.Patient> GetPatientByFIN(string? patientFIN)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ClinicAppCore.Patient.Entities.Patient>> GetPatientsByDoctor(int doctorId)
    {
        throw new NotImplementedException();
    }
}

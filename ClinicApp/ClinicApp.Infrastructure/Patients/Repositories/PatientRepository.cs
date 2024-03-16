namespace ClinicApp.Infrastructure.Patients.Repositories;

using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ClinicApp.Infrastructure.Data;
using ClinicApp.Infrastructure.Patients.Repositories.Base;
using ClinicApp.Core.Patients.Entities;

public class PatientRepository : IPatientRepository
{
    private readonly ClinicAppDbContext _context;
    public PatientRepository(ClinicAppDbContext _context)
    {
        this._context = _context;
    }

    public Task<Patient> AddPatient(Patient patient)
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

    public Task<IEnumerable<Patient>> GetPatientsByDoctor(string doctorFIN)
    {
        throw new NotImplementedException();
    }
}

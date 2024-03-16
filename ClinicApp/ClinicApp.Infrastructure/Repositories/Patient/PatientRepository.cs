namespace ClinicApp.Infrastructure.Repositories.Patient;

using ClinicApp.Infrastructure.Data;
using ClinicApp.Core.Models.ClinicEntities.Patient;
using ClinicApp.Infrastructure.Repositories.Patient.Base;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class PatientRepository : IPatientRepository
{
    private readonly ClinicAppDbContext _context;
    public PatientRepository(ClinicAppDbContext _context)
    {
        this._context = _context;
    }

    public async Task<Patient> GetPatientByFIN(string? patientFIN)
    {
        return await _context.Patients.FirstOrDefaultAsync(patient => patient.FIN == patientFIN);
    }

    public async Task<IEnumerable<Patient>> GetPatientsByDoctor(string doctorFIN)
    {
        var doctor = await _context.Doctors.FirstOrDefaultAsync(doctor => doctor.FIN == doctorFIN);
        var patientIds = await _context.DoctorPatients
                                        .Where(dp => dp.DoctorId == doctor.Id)
                                        .Select(dp => dp.PatientId)
                                        .ToListAsync();

        return await _context.Patients
                                .Where(patient => patientIds.Contains(patient.Id))
                                .ToListAsync();
    }

    public async Task<IEnumerable<Patient>> GetAllPatients()
    {
        return await _context.Patients.ToListAsync();
    }

    public async Task<Patient> AddPatient(Patient patient)
    {
        var addedPatient = await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
        return addedPatient.Entity;
    }
}

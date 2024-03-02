namespace ClinicApp.Infrastructure.Repositories.Doctor;

using ClinicApp.Core.Models.ClinicEntities.Doctor;
using ClinicApp.Infrastructure.Data;
using ClinicApp.Infrastructure.Repositories.Doctor.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicApp.Core.Models.ClinicEntities.DoctorPatient;
using Microsoft.EntityFrameworkCore;

public class DoctorRepository : IDoctorRepository
{
    private readonly ClinicAppDbContext _context;
    public DoctorRepository(ClinicAppDbContext _context)
    {
        this._context = _context;
    }

    public async Task<IEnumerable<Doctor>> GetDoctorsByMedicalDepartment(int medicalDepartment)
    {
        var doctors = await _context.Doctors.Where(doctor => doctor.MedicalDepartment == (MedicalDepartmentsEnum)medicalDepartment).ToListAsync();
        return doctors;
    }
    public Task<Doctor> GetDoctorByFIN(string? doctorFIN)
    {
        var doctor = _context.Doctors.FirstOrDefaultAsync(doctor => doctor.FIN == doctorFIN);
        return doctor;
    }
    public async Task AddPatientToDoctor(int doctorId, int patientId)
    {
        var doctorPatient = new DoctorPatient 
        {
            PatientId = patientId,
            DoctorId = doctorId
        };
        _ = await _context.DoctorPatients.AddAsync(doctorPatient);
    }
    public async Task<IEnumerable<Doctor>> GetAllDoctors()
    {
        var doctors = (await _context.Doctors.ToListAsync()).ToList();
        return doctors;
    }
}

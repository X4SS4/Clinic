namespace ClinicApp.Infrastructure.Repositories.DoctorPatient;

using ClinicApp.Infrastructure.Data;
using ClinicApp.Infrastructure.Repositories.DoctorPatient.Base;

public class DoctorPatientRepository : IDoctorPatientRepository
{
    private readonly ClinicAppDbContext _context;
    public DoctorPatientRepository(ClinicAppDbContext _context)
    {
        this._context = _context;
    }


}

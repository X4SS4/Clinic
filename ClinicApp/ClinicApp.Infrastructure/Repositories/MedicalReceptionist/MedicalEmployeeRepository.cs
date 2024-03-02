namespace ClinicApp.Infrastructure.Repositories.MedicalEmployee;

using ClinicApp.Core.Models.ClinicEntities.MedicalEmployee;
using ClinicApp.Infrastructure.Data;
using ClinicApp.Infrastructure.Repositories.MedicalEmployee.Base;
using System.Threading.Tasks;

public class MedicalEmployeeRepository : IMedicalEmployeeRepository
{
    private readonly ClinicAppDbContext _context;
    public MedicalEmployeeRepository(ClinicAppDbContext _context)
    {
        this._context = _context;
    }

    public Task<int> AddEmployee(MedicalEmployee employee)
    {
        throw new NotImplementedException();
    }

    public Task<MedicalEmployee?> GetEmployeeByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<MedicalEmployee?> LoginAsync(string? email, string? password)
    {
        throw new NotImplementedException();
    }

    //public async Task<int> AddEmployee(MedicalEmployee employee)
    //{

    //}

    //public async Task<MedicalEmployee?> GetEmployeeByEmail(string email)
    //{

    //}

    //public async Task<MedicalEmployee?> LoginAsync(string? email, string? password)
    //{

    //}
}
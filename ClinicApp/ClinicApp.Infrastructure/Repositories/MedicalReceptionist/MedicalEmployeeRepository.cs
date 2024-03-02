namespace ClinicApp.Infrastructure.Repositories.MedicalEmployee;

using ClinicApp.Core.Models.ClinicEntities.MedicalEmployee;
using ClinicApp.Infrastructure.Data;
using ClinicApp.Infrastructure.Repositories.MedicalEmployee.Base;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class MedicalEmployeeRepository : IMedicalEmployeeRepository
{
    private readonly ClinicAppDbContext _context;
    public MedicalEmployeeRepository(ClinicAppDbContext _context)
    {
        this._context = _context;
    
}

    public async Task AddEmployee(MedicalEmployee employee)
    {
        _ = await _context.Employees.AddAsync(employee);
    }

    public Task<MedicalEmployee?> GetEmployeeByEmail(string email)
    {
        return _context.Employees.FirstOrDefaultAsync(employee => employee.Email == email);
    }
}

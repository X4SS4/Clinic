namespace ClinicApp.Infrastructure.Repositories.MedicalEmployee.Base;

using ClinicApp.Core.Models.ClinicEntities.MedicalEmployee;

public interface IMedicalEmployeeRepository
{
    Task<int> AddEmployee(MedicalEmployee employee);
    Task<MedicalEmployee?> GetEmployeeByEmail(string email);
    Task<MedicalEmployee?> LoginAsync(string? email, string? password);
}

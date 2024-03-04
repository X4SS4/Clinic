using ClinicApp.Infrastructure.Repositories.MedicalEmployee.Base;

namespace ClinicApp.Infrastructure.Repositories.MedicalEmployee;

using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using ClinicApp.Core.Models.ManageTools;
using ClinicApp.Core.Models.ClinicEntities.MedicalEmployee;

public class MedicalEmployeeRepository : IMedicalEmployeeRepository
{
    private readonly SqlConnection connection;

    public MedicalEmployeeRepository(IOptions<ConnectionTools> connectionManager)
    {
        this.connection = new SqlConnection(connectionManager.Value.DefaultConnectionString);
    }

    public async Task<int> AddEmployee(MedicalEmployee employee)
    {
        return await connection.ExecuteAsync(@"
        INSERT INTO [MedicalEmployees]([Email], [Firstname], [Lastname], [Password], [Role])
        VALUES (@Email, @Firstname, @Lastname, @Password, @Role)", employee);
    }

    public async Task<MedicalEmployee?> GetEmployeeByEmail(string email)
    {
        return await connection.QueryFirstOrDefaultAsync<MedicalEmployee>(@"SELECT * FROM [MedicalEmployees] 
WHERE [Email] = @email", new { email });
    }

    public async Task<MedicalEmployee?> LoginAsync(string? email, string? password)
    {
        var result = await connection.QueryFirstOrDefaultAsync<MedicalEmployee>(@"SELECT * FROM MedicalEmployees 
WHERE Email = @Email AND Password = @Password", new { Email = email, Password = password });
        return result;
    }
}
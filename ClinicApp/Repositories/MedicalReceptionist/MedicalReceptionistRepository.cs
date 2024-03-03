namespace ClinicApp.Repositories.MedicalReceptionist;

using System.Data.SqlClient;
using ClinicApp.Models.ClinicEntities.MedicalReceptionist;
using ClinicApp.Models.ManageTools;
using ClinicApp.Repositories.MedicalReceptionist.Base;
using Dapper;
using Microsoft.Extensions.Options;

public class MedicalReceptionistRepository : IMedicalReceptionistRepository
{
    private readonly SqlConnection connection;

    public MedicalReceptionistRepository(IOptions<ConnectionTools> connectionManager)
    {
        this.connection = new SqlConnection(connectionManager.Value.DefaultConnectionString);
    }

    public async Task<MedicalReceptionist?> LoginAsync(string? email, string? password)
    {
        var result = await connection.QueryFirstOrDefaultAsync<MedicalReceptionist>(@"SELECT * FROM MedicalReceptionists 
WHERE Email = @Email AND Password = @Password", new { Email = email, Password = password });
        return result;
    }
}
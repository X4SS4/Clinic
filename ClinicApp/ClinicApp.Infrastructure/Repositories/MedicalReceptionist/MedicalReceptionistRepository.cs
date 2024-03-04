using ClinicApp.Infrastructure.Repositories.MedicalReceptionist.Base;

namespace ClinicApp.Infrastructure.Repositories.MedicalReceptionist;

using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using ClinicApp.Core.Models.ManageTools;
using ClinicApp.Core.Models.ClinicEntities.MedicalReceptionist;

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
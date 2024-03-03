namespace ClinicApp.Repositories.Logging;

using System.Data.SqlClient;
using ClinicApp.Models.LoggingEntities.LogRecord;
using ClinicApp.Models.ManageTools;
using ClinicApp.Repositories.Logging.Base;
using Dapper;
using Microsoft.Extensions.Options;

public class LogRecordRepository : ILogRecordRepository
{
    private readonly SqlConnection connection;
    public LogRecordRepository(IOptions<ConnectionTools> connectionManager)
    {
        this.connection = new SqlConnection(connectionManager.Value.DefaultConnectionString);
    }

    public async Task<int> CreateAsync(LogRecord logRecord)
    {
        return await connection.ExecuteAsync(@"
insert into LogRecords(MedicalReceptionistId, Url, MethodType, StatusCode, RequestBody, ResponseBody) 
values(@MedicalReceptionistId, @Url, @MethodType, @StatusCode, @RequestBody, @ResponseBody)", logRecord);
    }
}

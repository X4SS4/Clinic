using ClinicApp.Infrastructure.Repositories.Logging.Base;

namespace ClinicApp.Infrastructure.Repositories.Logging;

using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using ClinicApp.Core.Models.ManageTools;
using ClinicApp.Core.Models.LoggingEntities.LogRecord;

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

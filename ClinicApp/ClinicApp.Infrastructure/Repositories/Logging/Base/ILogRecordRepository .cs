namespace ClinicApp.Infrastructure.Repositories.Logging.Base;

using ClinicApp.Core.Models.LoggingEntities.LogRecord;

public interface ILogRecordRepository
{
    Task CreateAsync(LogRecord log);
}

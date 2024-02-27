using ClinicApp.Models.LoggingEntities.LogRecord;

namespace ClinicApp.Repositories.Logging.Base;


public interface ILogRecordRepository
{
    Task<int> CreateAsync(LogRecord log);
}

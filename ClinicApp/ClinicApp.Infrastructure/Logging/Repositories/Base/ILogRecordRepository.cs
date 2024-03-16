namespace ClinicApp.Infrastructure.Logging.Repositories.Base;

using ClinicApp.Core.Logging.Entities;

public interface ILogRecordRepository
{
    Task CreateAsync(LogRecord log);
}

namespace ClinicApp.Infrastructure.Repositories.Logging.Base;

using ClinicApp.Core.Logging.Entities;

public interface ILogRecordRepository
{
    Task CreateAsync(LogRecord log);
}

namespace ClinicAppCore.Logging.Repositories;

using ClinicAppCore.Logging.Entities;

public interface ILogRecordRepository { Task CreateAsync(LogRecord log); }
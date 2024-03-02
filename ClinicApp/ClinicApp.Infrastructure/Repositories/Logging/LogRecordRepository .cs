namespace ClinicApp.Infrastructure.Repositories.Logging;

using ClinicApp.Infrastructure.Data;
using ClinicApp.Core.Models.LoggingEntities.LogRecord;
using ClinicApp.Infrastructure.Repositories.Logging.Base;
using System.Threading.Tasks;

public class LogRecordRepository : ILogRecordRepository
{
    private readonly ClinicAppDbContext _context;
    public LogRecordRepository(ClinicAppDbContext _context)
    {
        this._context = _context;
    }

    public Task<int> CreateAsync(LogRecord log)
    {
        throw new NotImplementedException();
    }

    //public async Task<int> CreateAsync(LogRecord logRecord)
    //{

    //}
}

namespace ClinicApp.Infrastructure.Repositories.Logging;

using System.Threading.Tasks;
using ClinicApp.Infrastructure.Data;
using ClinicApp.Core.Logging.Entities;
using ClinicApp.Infrastructure.Repositories.Logging.Base;

public class LogRecordRepository : ILogRecordRepository
{
    private readonly ClinicAppDbContext _context;
    public LogRecordRepository(ClinicAppDbContext _context)
    {
        this._context = _context;
    }

    public async Task CreateAsync(LogRecord log)
    {
        _ = await _context.AddAsync(log);
        await _context.SaveChangesAsync();
    }
}

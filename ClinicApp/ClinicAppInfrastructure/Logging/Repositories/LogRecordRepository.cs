namespace ClinicAppInfrastructure.Logging.Repositories;

using System.Threading.Tasks;
using ClinicAppInfrastructure.Data;
using ClinicAppCore.Logging.Entities;
using ClinicAppCore.Logging.Repositories;

public class LogRecordRepository : ILogRecordRepository
{
    private readonly ClinicAppDbContext _context;
    public LogRecordRepository(ClinicAppDbContext _context) { this._context = _context; }
    public async Task CreateAsync(LogRecord log)
    {
        await _context.AddAsync(log);
        await _context.SaveChangesAsync();
    }
}

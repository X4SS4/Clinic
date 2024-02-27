using ClinicApp.Models.LoggingEntities.LogRecord;
using ClinicApp.Models.ManageTools;
using ClinicApp.Repositories.Logging.Base;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;

namespace ClinicApp.Middlewares;

public class LoggingMiddleware : IMiddleware
{
    private readonly ILogRecordRepository logRecordRepository;
    private readonly IOptionsMonitor<LoggerSwitch> optionsMonitorLoggerSwitch;
    private readonly IDataProtector dataProtector;

    public LoggingMiddleware(ILogRecordRepository logRecordRepository, IDataProtectionProvider dataProtectionProvider, IOptionsMonitor<LoggerSwitch> optionsMonitorLoggerSwitch)
    {
        this.logRecordRepository = logRecordRepository;
        this.optionsMonitorLoggerSwitch = optionsMonitorLoggerSwitch;
        this.dataProtector = dataProtectionProvider.CreateProtector("IdentityProtection");
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (optionsMonitorLoggerSwitch.CurrentValue.IsActive == false) {
            await next.Invoke(context);
            return;
        }

        // Get MedicalReceptionistId
        int medicalReceptionId = default;
        if (context.Request.Cookies["MedicalReceptionId"] is not null)
        {
            medicalReceptionId = int.Parse(dataProtector.Unprotect(context.Request.Cookies["MedicalReceptionId"]!));
        }

        // Get RequestBody
        context.Request.EnableBuffering();
        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
        context.Request.Body.Position = default;                    

        // Get ResponseBody
        var originalResponseBody = context.Response.Body;
        using var memoryStream = new MemoryStream();
        context.Response.Body = memoryStream;

        await next.Invoke(context);

        context.Response.Body.Seek(0, SeekOrigin.Begin);
        var responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
        context.Response.Body.Seek(0, SeekOrigin.Begin);
        await context.Response.Body.CopyToAsync(originalResponseBody);

        //Record Loggs
        await logRecordRepository.CreateAsync(new LogRecord
        {
            MedicalReceptionistId = medicalReceptionId,
            Url = context.Request.GetDisplayUrl(),
            MethodType = context.Request.Method,
            StatusCode = context.Response.StatusCode,
            RequestBody = requestBody,
            ResponseBody = responseBody
        });

    }
}

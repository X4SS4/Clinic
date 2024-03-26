namespace ClinicAppPresentation.Middlewares;

using System.Security.Claims;
using ClinicAppCore.Logging.Entities;
using ClinicAppCore.Logging.Repositories;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;

public class LoggingMiddleware : IMiddleware
{
    private readonly ILogRecordRepository logRecordRepository;
    private readonly IOptionsMonitor<LoggerSwitch> optionsMonitorLoggerSwitch;

    public LoggingMiddleware(ILogRecordRepository logRecordRepository, IOptionsMonitor<LoggerSwitch> optionsMonitorLoggerSwitch)
    {
        this.logRecordRepository = logRecordRepository;
        this.optionsMonitorLoggerSwitch = optionsMonitorLoggerSwitch;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (optionsMonitorLoggerSwitch.CurrentValue.IsActive == false) 
        {
            await next.Invoke(context);
            return;
        }

        // Get MedicalEmployeeId
        int medicalEmployeeId = default;
        int.TryParse(context.User.FindFirstValue("MedicalEmployeeId"), out medicalEmployeeId);

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
            MedicalEmployeeId = medicalEmployeeId,
            Url = context.Request.GetDisplayUrl(),
            MethodType = context.Request.Method,
            StatusCode = context.Response.StatusCode,
            RequestBody = requestBody,
            ResponseBody = responseBody
        });
    }
}
namespace ClinicApp.Core.Logging.Entities;

public class LogRecord
{
    public int Id { get; set; }
    public int MedicalEmployeeId { get; set; }
    public string? Url { get; set; }
    public string? MethodType { get; set; }
    public int StatusCode { get; set; }
    public string? RequestBody { get; set; }
    public string? ResponseBody { get; set; }
}
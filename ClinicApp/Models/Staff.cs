namespace ClinicApp.Models;

public class Staff
{
    public int Id { get; set; }
    public required string? FIN { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? Birthday { get; set; }
    public required StaffContract Contract { get; set; }
}
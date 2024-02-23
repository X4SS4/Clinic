namespace ClinicApp.Models;

using System;

public class Patient
{
    public int Id { get; set; }
    public string? FIN { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
}
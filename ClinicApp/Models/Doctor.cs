namespace ClinicApp.Models;

using System.Collections.Generic;


public class Doctor
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surame { get; set; }
    public string? MedicalDepartment { get; set; }
    public List<Patient>? Patients { get; set; } 
}
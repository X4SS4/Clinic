namespace ClinicAppCore.Employee.Entities;

using ClinicAppCore.Employee.Enums;
using Microsoft.AspNetCore.Identity;

public class Employee : IdentityUser<int>
{
    public string? FIN { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? ImagePath { get; set; }
    public MedicalDepartmentsEnum? MedicalDepartment { get; set; }
}
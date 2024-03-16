namespace ClinicApp.Core.Employees.Entities;

using Microsoft.AspNetCore.Identity;
using ClinicApp.Core.Employees.Enums;

public class Employee : IdentityUser<int>
{
    public string? FIN { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public MedicalDepartmentsEnum? MedicalDepartment { get; set; }
}

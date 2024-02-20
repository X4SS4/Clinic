namespace ClinicApp.DTO;

using ClinicApp.Models;


public class DoctorDTO
{
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public MedicalDepartmentsEnum? MedicalDepartment { get; set; }
}

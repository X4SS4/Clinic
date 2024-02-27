namespace ClinicApp.DTO;

using ClinicApp.Models.ClinicEntities.Doctor;

public class DoctorDTO
{
    public string? FIN { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public MedicalDepartmentsEnum? MedicalDepartment { get; set; }
}

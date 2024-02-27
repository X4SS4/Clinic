namespace ClinicApp.Core.Models.ClinicEntities.Doctor;

public class Doctor
{
    public int Id { get; set; }
    public string? FIN { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public MedicalDepartmentsEnum? MedicalDepartment { get; set; }
}
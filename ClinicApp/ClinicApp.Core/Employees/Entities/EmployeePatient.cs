namespace ClinicApp.Core.Employees.Entities;

public class EmployeePatient
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int PatientId { get; set; }
}
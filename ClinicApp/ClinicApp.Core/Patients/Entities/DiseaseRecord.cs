using ClinicApp.Core.Employees.Entities;

namespace ClinicApp.Core.Patients.Entities;

public class DiseaseRecord
{
    public int Id { get; set; }
    public Employee? EmployeeRecordedBy { get; set; }
    public DateTime CreationDate { get; set; }
    public string? Description { get; set; }
}

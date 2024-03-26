namespace ClinicAppCore.Patient.Entities;

public class DiseaseRecord
{
    public int Id { get; set; }
    public string? EmployeeRecordedByFullName { get; set; }
    public int? PatientCardId { get; set; }
    public DateTime CreationDate { get; set; }
    public string? Description { get; set; }
}

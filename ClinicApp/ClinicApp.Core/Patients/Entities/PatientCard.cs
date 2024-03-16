namespace ClinicApp.Core.Patients.Entities;

public class PatientCard
{
    public int Id { get; set; }
    public List<DiseaseRecord>? DiseaseRecords { get; set; }
}

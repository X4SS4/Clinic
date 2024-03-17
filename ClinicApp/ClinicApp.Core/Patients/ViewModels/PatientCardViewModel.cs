using ClinicApp.Core.Patients.Entities;

namespace ClinicApp.Core.Patients.ViewModels;
public class PatientCardViewModel
{
    public Patient Patient { get; set; }
    public IEnumerable<DiseaseRecord> DiseaseRecords { get; set; }
}

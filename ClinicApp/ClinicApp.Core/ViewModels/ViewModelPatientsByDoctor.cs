namespace ClinicApp.Core.ViewModels
;
using ClinicApp.Core.Models.ClinicEntities.Doctor;
using ClinicApp.Core.Models.ClinicEntities.Patient;


public class ViewModelPatientsByDoctor
{
    public Doctor? doctor { get; set; } = new Doctor();
    public IEnumerable<Patient>? patients { get; set; } = new List<Patient>();
}

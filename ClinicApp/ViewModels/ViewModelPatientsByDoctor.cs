namespace ClinicApp.ViewModels
;
using ClinicApp.Models.ClinicEntities.Doctor;
using ClinicApp.Models.ClinicEntities.Patient;


public class ViewModelPatientsByDoctor
{
    public Doctor? doctor { get; set; }
    public IEnumerable<Patient>? patients { get; set; }
}

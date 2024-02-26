using ClinicApp.Models;

namespace ClinicApp.ViewModels;

public class ViewModelPatientsByDoctor
{
    public Doctor? doctor { get; set; }
    public IEnumerable<Patient>? patients { get; set; }
}

namespace ClinicApp.Core.ViewModels;

using ClinicApp.Core.Models.ClinicEntities.Doctor;
using ClinicApp.Core.Models.ClinicEntities.Patient;

public class ViewModelDoctorPatient
{
    public Doctor? doctor { get; set; } = new Doctor();
    public Patient? patient { get; set; } = new Patient();
}

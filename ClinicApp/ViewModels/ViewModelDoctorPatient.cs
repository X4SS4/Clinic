namespace ClinicApp.ViewModels;

using ClinicApp.Models.ClinicEntities.Doctor;
using ClinicApp.Models.ClinicEntities.Patient;

public class ViewModelDoctorPatient
{
    public Doctor doctor { get; set; } = new Doctor();
    public Patient patient { get; set; } = new Patient();
}

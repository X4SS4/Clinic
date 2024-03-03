namespace ClinicApp.ViewModels;

using ClinicApp.Models;


public class ViewModelDoctorPatient
{
    public Doctor doctor { get; set; } = new Doctor();
    public Patient patient { get; set; } = new Patient();
}

using ClinicApp.Core.Employees.Entities;
using ClinicApp.Core.Patients.Entities;

namespace ClinicApp.Core.Employees.ViewModels;

public class ViewModelDoctorPatient
{
    public Employee? Doctor { get; set; }
    public Patient? Patient { get; set; }
}

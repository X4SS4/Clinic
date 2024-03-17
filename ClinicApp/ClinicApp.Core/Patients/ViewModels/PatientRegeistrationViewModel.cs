namespace ClinicApp.Core.Patients.ViewModels;

using ClinicApp.Core.Employees.Entities;
using ClinicApp.Core.Patients.Entities;

public class PatientRegeistrationViewModel
{
    public IEnumerable<Employee>? Employees { get; set; }
    public Patient? Patient { get; set; }
}

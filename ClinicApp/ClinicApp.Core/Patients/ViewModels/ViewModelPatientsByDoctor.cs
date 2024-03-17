using ClinicApp.Core.Employees.Entities;
using ClinicApp.Core.Patients.Entities;

namespace ClinicApp.Core.Patients.ViewModels;

public class ViewModelPatientsByDoctor
{
    public Employee doctor { get; set; }
    public IEnumerable<Patient> patients { get; set; }
}

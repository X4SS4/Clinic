namespace Clinic_App.Models.Persons;
using Clinic_App.Models.BaseModels;
using Clinic_App.Models.Persons.PatientEntities;
using Clinic_App.Models.Rooms;

public class Patient : Person
{
    public Ward? Ward { get; set; }
    public required PatientCard PatientCard { get; set; }
}


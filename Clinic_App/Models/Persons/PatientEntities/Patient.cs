namespace Clinic_App.Models.Persons;
using Clinic_App.Models.BaseModels;
using Clinic_App.Models.Persons.PatientEntities;

public class Patient : Person
{
    public required PatientCard PatientCard { get; set; }
}


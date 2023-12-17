namespace Clinic_App.Models.Persons;
using Clinic_App.Models.BaseModels;
using Clinic_App.Models.Persons.StaffEntities;

public class Staff : Person
{
    public required StaffContract contract { get; set; }
}



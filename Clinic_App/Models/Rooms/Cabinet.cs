namespace Clinic_App.Models.Rooms;
using Clinic_App.Models.BaseModels;
using Clinic_App.Models.Persons;

public class Cabinet : Room
{
    public Staff? owner { get; set; }
}

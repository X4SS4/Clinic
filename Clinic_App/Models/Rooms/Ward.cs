namespace Clinic_App.Models.Rooms;

using System.ComponentModel.DataAnnotations;
using Clinic_App.Models.BaseModels;
using Clinic_App.Models.Persons;

public class Ward : Room
{
    private int? patientCapacity;
    public int? PatientCapacity
    {
        get{
            return patientCapacity;
        }
        set{
            if(patientCapacity == null) patientCapacity = value;
        }
    }
    private List<Patient>? patients;
    public List<Patient>? Patients
    {
        get{
            return patients;
        }
        set{
            if(value != null && value.Count() < PatientCapacity) patients = value;
        }
    }
}


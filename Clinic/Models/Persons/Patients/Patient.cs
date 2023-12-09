using System.ComponentModel.DataAnnotations;

namespace Clinic.Models.Persons;

public class Patient : Person
{
    public Card patientCard { get; set; }
};

public class Card 
{
    List<DiseaseHistory> diseases { get; set; }
};

public class DiseaseHistory
{
    public string? Disease { get; set; }
    public string? IsReanimation { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
};
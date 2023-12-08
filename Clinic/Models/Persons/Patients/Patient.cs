namespace Clinic.Models.Persons

public class Patient : Person
{
    public string? Disease { get; set; }
    public string? IsReanimation { get; set; }
}
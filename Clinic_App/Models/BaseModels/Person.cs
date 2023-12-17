namespace Clinic_App.Models.BaseModels;


public class Person
{
    // public UniqueId Id { get; set; }
    public int Id { get; set; }
    public required string? FIN { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? Birthday { get; set; }
}

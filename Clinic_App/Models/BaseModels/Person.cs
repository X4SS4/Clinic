namespace Clinic_App.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
public class Person
{
    [Key]
    public int Id { get; set; }
    public required string? FIN { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? Birthday { get; set; }
}

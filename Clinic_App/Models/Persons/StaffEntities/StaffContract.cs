namespace Clinic_App.Models.Persons.StaffEntities;
using System.ComponentModel.DataAnnotations;

public class StaffContract
{
    [Key]
    public int Id { get; set; }
    public required DateTime StartDate { get; set; }
    public string? Job_title { get; set; }
    public double? Salary { get; set; }
}

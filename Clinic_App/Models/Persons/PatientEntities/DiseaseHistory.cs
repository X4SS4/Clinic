namespace Clinic_App.Models.Persons.PatientEntities;
using System.ComponentModel.DataAnnotations;

public class DiseaseHistory
{
    [Key]
    public int Id { get; set; }
    public string? DiseaseName { get; set; }
    public required DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
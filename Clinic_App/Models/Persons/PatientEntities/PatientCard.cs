namespace Clinic_App.Models.Persons.PatientEntities;
using System.ComponentModel.DataAnnotations;

public class PatientCard
{
    [Key]
    public int Id { get; set; }
    public required List<DiseaseHistory> DiseaseHistories { get; set; }
}

namespace Clinic_App.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

public class Room
{
    [Key]
    public int Id { get; set; }
    public required int Number { get; set; }
    public required int Floor { get; set; }
}

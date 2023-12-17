namespace Clinic_App.Models.BaseModels;

public class Room
{
    public int Id { get; set; }
    public required int Number { get; set; }
    public required int Floor { get; set; }
}

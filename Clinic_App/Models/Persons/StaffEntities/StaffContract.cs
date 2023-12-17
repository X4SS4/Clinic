namespace Clinic_App.Models.Persons.StaffEntities;
using System;


public class StaffContract
{
    public int Id { get; set; }
    public required DateTime StartDate { get; set; }
    public string? Job_title { get; set; }
    public double? Salary { get; set; }
}

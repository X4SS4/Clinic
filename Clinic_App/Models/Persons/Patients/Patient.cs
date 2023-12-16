namespace Clinic.Models.Persons;

public class Patient : Person
{
    public required Card PatientCard { get; set; }
    //public Patient(string FIN
    //    , Card PatientCard
    //    , string? FirstName = null
    //    , string? LastName = null
    //    , int[]? Birthday = null) : base()
    //{
    //    this.FIN = FIN;
    //    this.PatientCard = PatientCard;
    //    this.FirstName = FirstName;
    //    this.LastName = LastName;
    //    this.Birthday = Birthday != null
    //        ? new DateTime(Birthday[0], Birthday[1], Birthday[2])
    //        : null;
    //}
};
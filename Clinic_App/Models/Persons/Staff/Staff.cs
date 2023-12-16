public class Staff : Person
{
	public string? Job_title { get; set; }
	public double? Salary { get; set; }
	public bool? IsManagement { get; set; }

    //public Staff( string? FIN = null
    //    , string? FirstName = null
    //    , string? LastName = null
    //    , double? Salary = null
    //    , bool? IsManagement = null 
    //    , string? Job_title = null
    //    , int[]? Birthday = null) : base()
    //{
    //    this.FIN = FIN;
    //    this.FirstName = FirstName;
    //    this.LastName = LastName;
    //    this.Salary = Salary;
    //    this.IsManagement = IsManagement;
    //    this.Job_title = Job_title;
    //    this.Birthday = Birthday != null 
    //        ? new DateTime(Birthday[0], Birthday[1], Birthday[2])
    //        : null;

    //}
}
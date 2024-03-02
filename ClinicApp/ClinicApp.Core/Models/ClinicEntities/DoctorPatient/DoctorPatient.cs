namespace ClinicApp.Core.Models.ClinicEntities.DoctorPatient;

public class DoctorPatient
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
}

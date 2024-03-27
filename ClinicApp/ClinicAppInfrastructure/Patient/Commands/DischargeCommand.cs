namespace ClinicAppInfrastructure.Patient.Commands;

using MediatR;

public class DischargeCommand : IRequest
{
    public int? patientId { get; set; }
    public int? doctorId { get; set; }
}
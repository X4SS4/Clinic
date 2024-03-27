namespace ClinicAppInfrastructure.Patient.Handlers;

using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ClinicAppCore.Patient.Repositories;
using ClinicAppInfrastructure.Patient.Commands;

public class DischargeHandler : IRequestHandler<DischargeCommand>
{
    private readonly IPatientRepository _repository;
    public DischargeHandler(IPatientRepository _repository)
    {
        this._repository = _repository;
    }
    public async Task Handle(DischargeCommand request, CancellationToken cancellationToken)
    {
        if (request.patientId == null) { throw new ArgumentNullException("Patient ID can`t be empty"); }
        if (request.doctorId == null) { throw new ArgumentNullException("Doctor ID can`t be empty"); }
        await this._repository.Discharge(patientId: request.patientId.Value, doctorId: request.doctorId.Value);
    }
}
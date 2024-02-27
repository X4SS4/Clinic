namespace ClinicApp.Infrastructure.Repositories.MedicalReceptionist.Base;

using ClinicApp.Core.Models.ClinicEntities.MedicalReceptionist;

public interface IMedicalReceptionistRepository
{
    Task<MedicalReceptionist?> LoginAsync(string? email, string? password);
}

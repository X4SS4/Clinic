namespace ClinicApp.Repositories.MedicalReceptionist.Base;

using ClinicApp.Models.ClinicEntities.MedicalReceptionist;

public interface IMedicalReceptionistRepository
{
    Task<MedicalReceptionist?> LoginAsync(string? email, string? password);
}

using ClinicApp.Core.Models.ManageTools;

namespace ClinicApp.Core.Models.ClinicEntities.MedicalEmployee;

public class MedicalEmployee
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Password { get; set; }
    public AccessRoles? Role { get; set; }
}
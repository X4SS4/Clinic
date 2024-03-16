namespace ClinicApp.Core.Employees.DTO;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public class EmployeeRegistrationDTO
{
    [EmailAddress]
    [Required(ErrorMessage = "Email cannot be empty")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Firstname cannot be empty")]
    public string? Firstname { get; set; }
    [Required(ErrorMessage = "Lastname cannot be empty")]
    public string? Lastname { get; set; }
    [PasswordPropertyText]
    [Required(ErrorMessage = "Password cannot be empty")]
    public string? Password { get; set; }
}

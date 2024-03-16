namespace ClinicApp.Core.Employees.DTO;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class EmployeeLogintDTO
{
    [EmailAddress]
    [Required(ErrorMessage = "Email cannot be empty")]
    public string? Email { get; set; }
    [PasswordPropertyText]
    [Required(ErrorMessage = "Password cannot be empty")]
    public string? Password { get; set; }
}

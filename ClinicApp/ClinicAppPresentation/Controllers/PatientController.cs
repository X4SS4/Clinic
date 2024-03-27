namespace ClinicAppPresentation.Controllers;

using ClinicAppCore.Employee.Entities;
using ClinicAppCore.Employee.Enums;
using ClinicAppInfrastructure.Patient.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class PatientController : Controller
{
    public ISender _sender;
    public UserManager<Employee> _userManager;
    public RoleManager<Employee> _roleManager;
    public PatientController(ISender sender, UserManager<Employee> userManager, RoleManager<Employee> roleManager)
    {
        this._roleManager = roleManager;
        this._userManager = userManager;
        this._sender = sender;
    }

    public async Task<IActionResult> Index()
    {
        var user = await this._userManager.GetUserAsync(User);
        var role = await this._roleManager.GetRoleIdAsync(user);
        if (role.ToLower() == AccessRoles.Doctor.ToString().ToLower()){}
        return View();
    }

    [HttpDelete]
    public async Task<IActionResult> DischargePatient(int patientId)
    {
        var doctorId = (await this._userManager.GetUserAsync(User))?.Id;
        await this._sender.Send(new DischargeCommand
        {
            patientId = patientId,
            doctorId = doctorId
        });
        return Ok();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}

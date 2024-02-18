namespace ClinicApp.Controllers;

using ClinicApp.Models;
using Microsoft.AspNetCore.Mvc;

public class StaffController : Controller
{
    public IActionResult GetDoctors(MedicalDepartmentsEnum departmentsEnum)
    {
        return View();
    }
}
namespace ClinicApp.Controllers;

using System.Text.Json;
using ClinicApp.ClinicDB;
using Microsoft.AspNetCore.Mvc;


public class DoctorController : Controller
{
    public async Task<IActionResult> ShowDoctorList(int medicalDepartment)
    {
        var DB = new BonadeaDB();
        var doctors = await DB.GetDoctorsByMedicalDepartment(medicalDepartment);
        return View(model: doctors);
    }
}

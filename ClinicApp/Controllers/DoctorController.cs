namespace ClinicApp.Controllers;


using ClinicApp.ClinicDB;
using Microsoft.AspNetCore.Mvc;


public class DoctorController : Controller
{
    [HttpGet]
    public async Task<IActionResult> ShowDoctorByMedicalDepartment(int medicalDepartment)
    {
        var DB = new BonadeaDB();
        var doctors = await DB.GetDoctorsByMedicalDepartment(medicalDepartment);
        return View(model: doctors);
    }

    [HttpGet]
    public async Task<IActionResult> ShowAllDoctors()
    {
        var DB = new BonadeaDB();
        var doctors = await DB.GetAllDoctors();
        return View(model: doctors);
    
    }
}

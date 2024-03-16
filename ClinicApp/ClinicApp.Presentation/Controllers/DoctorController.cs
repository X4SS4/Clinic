namespace ClinicApp.Presentation.Controllers;

using Microsoft.AspNetCore.Mvc;

public class DoctorController : Controller
{
    public DoctorController()
    {
    }

    [HttpGet]
    public async Task<IActionResult> ShowDoctorByMedicalDepartment(int medicalDepartment)
    {
        // var doctors = await doctorRepository.GetDoctorsByMedicalDepartment(medicalDepartment);
        // return View(model: doctors);
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> ShowAllDoctors()
    {
        // var doctors = await doctorRepository.GetAllDoctors();
        // return View(model: doctors);
        return View();
    
    }
}

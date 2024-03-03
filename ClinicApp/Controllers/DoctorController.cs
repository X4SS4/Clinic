using Repositories.Doctor.Base;
using Repositories.Patient.Base;

namespace ClinicApp.Controllers;

using Microsoft.AspNetCore.Mvc;

public class DoctorController : Controller
{
    private readonly IDoctorRepository doctorRepository;
    public DoctorController(IDoctorRepository doctorRepository)
    {
        this.doctorRepository = doctorRepository;
    }

    [HttpGet]
    public async Task<IActionResult> ShowDoctorByMedicalDepartment(int medicalDepartment)
    {
        var doctors = await doctorRepository.GetDoctorsByMedicalDepartment(medicalDepartment);
        return View(model: doctors);
    }

    [HttpGet]
    public async Task<IActionResult> ShowAllDoctors()
    {
        var doctors = await doctorRepository.GetAllDoctors();
        return View(model: doctors);
    
    }
}

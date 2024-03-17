namespace ClinicApp.Presentation.Controllers;

using ClinicApp.Core.Patients.Entities;
using ClinicApp.Core.Patients.ViewModels;
using ClinicApp.Infrastructure.Patients.Services;
using ClinicApp.Infrastructure.Patients.Services.Base;
using Microsoft.AspNetCore.Mvc;

public class DoctorController : Controller
{
    private readonly IPatientService patientService;
    public DoctorController(IPatientService patientService)
    {
        this.patientService = patientService;
    }

    [HttpGet]
    public async Task<IActionResult> ShowDoctorByMedicalDepartment(int medicalDepartment, string patientFIN)
    {
        var doctors = await doctorRepository.GetDoctorsByMedicalDepartment(medicalDepartment);
        var patient = await patientService.GetPatient(patientFIN);
        var patientRegistrationViewModel = new PatientRegeistrationViewModel
        {
            Employees = doctors,
            Patient = patient
        };
        return View(model: patientRegistrationViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> ShowAllDoctors()
    {
        // var doctors = await doctorRepository.GetAllDoctors();
        // return View(model: doctors);
        return View();

    }
}

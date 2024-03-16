namespace ClinicApp.Presentation.Controllers;

using Newtonsoft.Json;
using ClinicApp.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ClinicApp.Core.Models.ClinicEntities.Doctor;
using ClinicApp.Infrastructure.Repositories.Doctor.Base;
using ClinicApp.Infrastructure.Repositories.Patient.Base;
using ClinicApp.Core.DTO.Doctor;

public class PatientController : Controller
{
    private readonly IPatientRepository patientRepository;
    private readonly IDoctorRepository doctorRepository;
    public PatientController(IPatientRepository patientRepository, IDoctorRepository doctorRepository)
    {
        this.patientRepository = patientRepository;
        this.doctorRepository = doctorRepository;
    }

    [HttpPost]
    public IActionResult CreatePatient([FromForm(Name = "doctor")] string doctorJson)
    {
        var doctorTo = JsonConvert.DeserializeObject<Doctor>(doctorJson);
        var viewModelDoctorPatient = new ViewModelDoctorPatient()
        {
            doctor = new DoctorDTO
            {
                FIN = doctorTo.FIN,
                Firstname = doctorTo.Firstname,
                Lastname = doctorTo.Lastname,
                MedicalDepartment = doctorTo.MedicalDepartment
            }
        };
        return View(model: viewModelDoctorPatient);
    }

    [HttpGet]
    public async Task<IActionResult> ShowAllPatients()
    {
        var patients = await patientRepository.GetAllPatients();
        return View(model: patients);
    }

    [HttpGet]
    public async Task<IActionResult> ShowPatientsByDoctor([FromQuery] string doctorFIN)
    {
        var patients = await patientRepository.GetPatientsByDoctor(doctorFIN);
        var doctor = await doctorRepository.GetDoctorByFIN(doctorFIN);
        var viewModelPatientsByDoctor = new ViewModelPatientsByDoctor
        {
            doctor = doctor,
            patients = patients
        };
        return View(model: viewModelPatientsByDoctor);
    }
}

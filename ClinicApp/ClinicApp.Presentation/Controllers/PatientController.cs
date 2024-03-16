namespace ClinicApp.Presentation.Controllers;

using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using ClinicApp.Infrastructure.Patients.Repositories.Base;

public class PatientController : Controller
{
    private readonly IPatientRepository patientRepository;
    public PatientController(IPatientRepository patientRepository)
    {
        this.patientRepository = patientRepository;
    }

    [HttpPost]
    public IActionResult CreatePatient([FromForm(Name = "doctor")] string doctorJson)
    {
        // var doctorTo = JsonConvert.DeserializeObject<Doctor>(doctorJson);
        // var viewModelDoctorPatient = new ViewModelDoctorPatient()
        // {
        //     doctor = new DoctorDTO
        //     {
        //         FIN = doctorTo.FIN,
        //         Firstname = doctorTo.Firstname,
        //         Lastname = doctorTo.Lastname,
        //         MedicalDepartment = doctorTo.MedicalDepartment
        //     }
        // };
        // return View(model: viewModelDoctorPatient);
        return View();
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
        // var patients = await patientRepository.GetPatientsByDoctor(doctorFIN);
        // var doctor = await doctorRepository.GetDoctorByFIN(doctorFIN);
        // var viewModelPatientsByDoctor = new ViewModelPatientsByDoctor
        // {
        //     doctor = doctor,
        //     patients = patients
        // };
        // return View(model: viewModelPatientsByDoctor);
        return View();
    }
}

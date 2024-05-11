namespace ClinicApp.Presentation.Controllers;

using ClinicApp.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using ClinicApp.Core.ViewModels;
using ClinicApp.Core.Models.ClinicEntities.Patient;
using ClinicApp.Infrastructure.Repositories.Doctor.Base;
using ClinicApp.Infrastructure.Repositories.Patient.Base;

public class RegistrationController : Controller
{
    private readonly IPatientRepository patientRepository;
    private readonly IDoctorRepository doctorRepository;
    public RegistrationController(IPatientRepository patientRepository, IDoctorRepository doctorRepository)
    {
        this.patientRepository = patientRepository;
        this.doctorRepository = doctorRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegistrationPatient([FromForm] DoctorDTO doctor, [FromForm] PatientDTO patient)
    {
        await patientRepository.AddPatient(new Patient
        {
            FIN = patient.FIN,
            Firstname = patient.Firstname,
            Lastname = patient.Lastname,
            Email = patient.Email
        });
        var patientId = (await patientRepository.GetPatientByFIN(patient.FIN)).Id;
        var doctorId = (await doctorRepository.GetDoctorByFIN(doctor.FIN)).Id;
        await doctorRepository.AddPatientToDoctor(doctorId: doctorId, patientId: patientId);
        string url = $@"/Registration/Receipt?doctorFIN={doctor.FIN}&patientFIN={patient.FIN}";
        string script = $@"<script> window.open('{url}', '_blank'); window.location.href = '/Home/Index'; </script>";
        return Content(script, "text/html");
    }

    [HttpGet]
    public async Task<IActionResult> Receipt(string doctorFIN, string patientFIN)
    {
        var veiwModel = new ViewModelDoctorPatient();
        veiwModel.doctor = await doctorRepository.GetDoctorByFIN(doctorFIN);
        veiwModel.patient = await patientRepository.GetPatientByFIN(patientFIN);
        return View(veiwModel);
    }
}

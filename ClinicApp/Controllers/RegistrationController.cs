namespace ClinicApp.Controllers;

using ClinicApp.ClinicDB;
using ClinicApp.Models;
using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Mvc;


public class RegistrationController : Controller
{


    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegistrationPatient([FromForm] Doctor doctor, [FromForm] Patient patient)
    {
        var db = new BonadeaDB();
        await db.AddPatient(patient);
        var patientId = (await db.GetPatientByFIN(patient.FIN)).Id;
        var doctorId = (await db.GetDoctorByFIN(doctor.FIN)).Id;
        await db.AddPatientToDoctor(doctorId: doctorId, patientId: patientId);

        string url = $@"/Registration/Receipt?doctorFIN={doctor.FIN}&patientFIN={patient.FIN}";
        string script = $@"<script> window.open('{url}', '_blank'); window.location.href = '/Home/Index'; </script>";

        return Content(script, "text/html");
    }

    [HttpGet]
    public async Task<IActionResult> Receipt(string doctorFIN, string patientFIN)
    {
        var db = new BonadeaDB();
        var veiwModel = new ViewModelDoctorPatient();
        veiwModel.doctor = await db.GetDoctorByFIN(doctorFIN);
        veiwModel.patient = await db.GetPatientByFIN(patientFIN);

        return View(veiwModel);
    }
}

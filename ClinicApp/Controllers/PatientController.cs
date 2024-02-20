namespace ClinicApp.Controllers;

using ClinicApp.Models;
using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class PatientController : Controller
{
    [HttpPost]
    public IActionResult CreatePatient([FromForm(Name = "doctor")] string doctorJson)
    {
        var doctorTO = JsonConvert.DeserializeObject<Doctor>(doctorJson);
        var viewModelDoctorPatient = new ViewModelDoctorPatient() { doctor = doctorTO ?? new Doctor()};
        return View(model: viewModelDoctorPatient);
    }

    [HttpPost]
    public IActionResult RegistrationPatient([FromForm] Doctor doctor, [FromForm] Patient patient)
    {
        // var vmDeserialized = JsonConvert.DeserializeObject<ViewModelDoctorPatient>(viewModelDoctorPatientJson);
        var doctorJS = System.Text.Json.JsonSerializer.Serialize(doctor);
        var patientJS = System.Text.Json.JsonSerializer.Serialize(patient);
        System.Console.WriteLine(doctorJS);
        System.Console.WriteLine(patientJS);
        return base.Ok(doctorJS + patientJS);
    }
}

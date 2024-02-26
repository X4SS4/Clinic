namespace ClinicApp.Controllers;

using ClinicApp.ClinicDB;
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
        var viewModelDoctorPatient = new ViewModelDoctorPatient() { doctor = doctorTO ?? new Doctor() };
        return View(model: viewModelDoctorPatient);
    }

    [HttpGet]
    public async Task<IActionResult> ShowAllPatients()
    {
        var DB = new BonadeaDB();
        var patients = await DB.GetAllPatients();
        return View(model: patients);
    }

    [HttpGet]
    public async Task<IActionResult> ShowPatientsByDoctor([FromQuery] string doctorFIN)
    {
        var DB = new BonadeaDB();
        var patients = await DB.GetPatientsByDoctor(doctorFIN);
        var doctor = await DB.GetDoctorByFIN(doctorFIN);
        var viewModelPatientsByDoctor = new ViewModelPatientsByDoctor();
        viewModelPatientsByDoctor.doctor = doctor;
        viewModelPatientsByDoctor.patients = patients;

        return View(model: viewModelPatientsByDoctor);
    }
}

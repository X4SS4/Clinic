namespace ClinicApp.Presentation.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ClinicApp.Core.Employees.Entities;
using ClinicApp.Core.Patients.ViewModels;
using ClinicApp.Infrastructure.Patients.Services.Base;
using ClinicApp.Core.Patients.Entities;
using ClinicApp.Core.Employees.ViewModels;

public class PatientController : Controller
{
    private readonly IPatientService patientService;
    private readonly UserManager<Employee> userManager;
    public PatientController(IPatientService patientService, UserManager<Employee> userManager)
    {
        this.patientService = patientService;

        this.userManager = userManager;
    }

    //Show all patients
    [HttpGet]
    public async Task<IActionResult> ShowAllPatients()
    {
        var patients = await patientService.GetAllPatients();
        return View(model: patients);
    }

    //Edit patient
    [HttpGet]
    public async Task<IActionResult> EditPatientInfo(string patientFIN)
    {
        var patient = await patientService.GetPatient(patientFIN);
        return View(model: patient);
    }

    [HttpPost]
    public async Task<IActionResult> EditPatientInfo(Patient patient)
    {
        var patients = await patientService.GetAllPatients();
        return View(model: patients);
    }

    //Registration to doctor
    [HttpGet]
    public async Task<IActionResult> RegistrationPatient(string patientFIN)
    {
        return View(model: patientFIN);
    }

    [HttpPost]
    public async Task<IActionResult> RegistrationPatient(int doctorId, string patientFIN)
    {
        var doctor = await employeeService();
        var patient = await patientService.GetPatient(patientFIN);
        var doctorPatient = new EmployeePatient{
            EmployeeId = doctorId,
            PatientId = patient.Id
        };
        await patientService.AddPatientToDoctor(doctorPatient);
        string url = $@"/Registration/Receipt?doctorFIN={doctor.FIN}&patientFIN={patient.FIN}";
        string script = $@"<script> window.open('{url}', '_blank'); window.location.href = '/Home/Index'; </script>";
        return Content(script, "text/html");
    }
    
    //Create patient
    [HttpPost]
    public Task<IActionResult> CreatePatient()
    {
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





    #region PatientsByDoctor

    //Show patients by doctor
    [HttpGet]
    public async Task<IActionResult> ShowPatientsByDoctor()
    {
        var user = await userManager.GetUserAsync(User);
        var patients = await patientService.GetPatientsByDoctor(user.Id);
        var viewModelPatientsByDoctor = new ViewModelPatientsByDoctor
        {
            doctor = user,
            patients = patients
        };
        return View(model: viewModelPatientsByDoctor);
    }

    //Show Patient`s Card
    [HttpGet]
    public async Task<IActionResult> ShowPatientsCard(Patient patient)
    {
        var patientCard = await patientService.GetPatientCard(patient.Id);
        var diseaseRecords = await patientService.GetDiseaseRecords(patientCard.Id);
        var patientCardViewModel = new PatientCardViewModel
        {
            Patient = patient,
            DiseaseRecords = diseaseRecords
        };
        return View(model: patientCardViewModel);
    }

    // CreateDiseaseRecord
    [HttpGet]
    public async Task<IActionResult> CreateDiseaseRecord(PatientCard patientCard)
    {
        return View(model: patientCard);
    }

    [HttpPost]
    public async Task CreateDiseaseRecord(int patientCardID)
    {
        var doctor = await userManager.GetUserAsync(User);
        await patientService.CreateDiseaseRecord(patientCardID, doctor);
    }

    //Edit Disease Record
    [HttpGet]
    public async Task<IActionResult> EditDiseaseRecord(DiseaseRecord diseaseRecord)
    {
        return View();
    }

    [HttpPost]
    public async Task EditDiseaseRecord(DiseaseRecord diseaseRecord, string description)
    {
        await patientService.EditDiseaseRecord(diseaseRecord, description);
    }

    //Discharge Patient
    [HttpGet]
    public async Task DischargePatient(Patient patient)
    {
        var doctor = await userManager.GetUserAsync(User);
        await patientService.DischargePatient(patient, doctor);
    }
    #endregion
}

namespace ClinicApp.Presentation.Controllers;

using Microsoft.AspNetCore.Mvc;
using ClinicApp.Core.ViewModels;
using ClinicApp.Core.Models.ClinicEntities.Patient;
using ClinicApp.Infrastructure.Repositories.Doctor.Base;
using ClinicApp.Infrastructure.Repositories.Patient.Base;
using ClinicApp.Core.DTO.MedicalEmployee;
using ClinicApp.Core.Models.ClinicEntities.MedicalEmployee;
using ClinicApp.Infrastructure.Repositories.MedicalEmployee.Base;
using ClinicApp.Core.DTO.Doctor;
using ClinicApp.Core.DTO.Patient;

public class RegistrationController : Controller
{
    private readonly IPatientRepository patientRepository;
    private readonly IDoctorRepository doctorRepository;
    private readonly IMedicalEmployeeRepository medicalEmployeeRepository;
    public RegistrationController(IPatientRepository patientRepository, IDoctorRepository doctorRepository, IMedicalEmployeeRepository medicalEmployeeRepository)
    {
        this.patientRepository = patientRepository;
        this.doctorRepository = doctorRepository;
        this.medicalEmployeeRepository = medicalEmployeeRepository;
    }

    [HttpGet]
    public IActionResult RegistrationPatient()
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
    public IActionResult RegistrationEmployee()
    {
        return View(model: new MedicalEmployeeRegistrationDTO());
    }

    [HttpPost]
    public async Task<IActionResult> RegistrationEmployee([FromForm] MedicalEmployeeRegistrationDTO medicalemployeeDTO)
    {
        //await medicalEmployeeRepository.AddEmployee(new MedicalEmployee
        //{
        //    Email = medicalemployeeDTO.Email,
        //    Firstname = medicalemployeeDTO.Firstname,
        //    Lastname = medicalemployeeDTO.Lastname,
        //    Password = medicalemployeeDTO.Password,
        //    Role = Core.Models.ManageTools.AccessRoles.MedicalReceptionist
        //});
        string url = $@"/Registration/SuccessfulRegistrationMessage?medicalemployeeEmail={medicalemployeeDTO.Email}";
        string script = $@"<script> window.open('{url}', '_blank'); window.location.href = '/Home/Index'; </script>";
        return Content(script, "text/html");
    }

    [HttpGet]
    public async Task<IActionResult> SuccessfulRegistrationMessage(string medicalemployeeEmail)
    {
        var medicalemployee = await medicalEmployeeRepository.GetEmployeeByEmail(medicalemployeeEmail);
        return View(model: medicalemployee);
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

namespace ClinicApp.Presentation.Controllers;

using Microsoft.AspNetCore.Mvc;
using ClinicApp.Core.ViewModels;
using ClinicApp.Core.DTO.Doctor;
using ClinicApp.Core.DTO.Patient;
using ClinicApp.Core.DTO.MedicalEmployee;
using ClinicApp.Core.Models.ClinicEntities.Patient;
using ClinicApp.Infrastructure.Repositories.Doctor.Base;
using ClinicApp.Infrastructure.Repositories.Patient.Base;
using ClinicApp.Core.Models.ClinicEntities.MedicalEmployee;
using Microsoft.AspNetCore.Identity;

public class RegistrationController : Controller
{
    private readonly IPatientRepository patientRepository;
    private readonly IDoctorRepository doctorRepository;
    private readonly UserManager<MedicalEmployee> userManager;
    private readonly SignInManager<MedicalEmployee> signInManager;
    private readonly RoleManager<IdentityRole<int>> roleManager;
    public RegistrationController(
        IPatientRepository patientRepository, 
        IDoctorRepository doctorRepository,
        UserManager<MedicalEmployee> userManager,
        RoleManager<IdentityRole<int>> roleManager,
        SignInManager<MedicalEmployee> signInManager
    )
    {
        this.patientRepository = patientRepository;
        this.doctorRepository = doctorRepository;
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult RegistrationPatient()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegistrationPatient([FromForm] DoctorDTO doctorDTO, [FromForm] PatientDTO patientDTO)
    {
        var patient = await patientRepository.AddPatient(new Patient
        {
            FIN = patientDTO.FIN,
            Firstname = patientDTO.Firstname,
            Lastname = patientDTO.Lastname,
            Email = patientDTO.Email
        });

        var doctorId = (await doctorRepository.GetDoctorByFIN(doctorDTO.FIN)).Id;
        await doctorRepository.AddPatientToDoctor(doctorId: doctorId, patientId: patient.Id);

        string url = $@"/Registration/Receipt?doctorFIN={doctorDTO.FIN}&patientFIN={patient.FIN}";
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
        if (ModelState.IsValid)
        {
            var medicalEmployee = new MedicalEmployee
            {
                UserName = medicalemployeeDTO.Email,
                Email = medicalemployeeDTO.Email,
            };

            var result = await userManager.CreateAsync(medicalEmployee, medicalemployeeDTO.Password);

            if (result.Succeeded)
            {
                var role = new IdentityRole<int>{Name = "Admin"};
                await roleManager.CreateAsync(role);
                await userManager.AddToRoleAsync(medicalEmployee, "Admin");
                await signInManager.SignInAsync(medicalEmployee, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        string url = $@"/Registration/SuccessfulRegistrationMessage?medicalemployeeEmail={medicalemployeeDTO.Email}";
        string script = $@"<script> window.open('{url}', '_blank'); window.location.href = '/Home/Index'; </script>";
        return Content(script, "text/html");
    }

    [HttpGet]
    public async Task<IActionResult> SuccessfulRegistrationMessage(string medicalemployeeEmail)
    {
        var medicalemployee = await userManager.GetUserAsync(User);
        return View(model: medicalemployee);
    }

    [HttpGet]
    public async Task<IActionResult> Receipt(string doctorFIN, string patientFIN)
    {
        var veiwModel = new ViewModelDoctorPatient();
        var doctor = await doctorRepository.GetDoctorByFIN(doctorFIN);
        var patient = await patientRepository.GetPatientByFIN(patientFIN);

        veiwModel.doctor = new DoctorDTO{
            FIN = doctor.FIN,
            Firstname = doctor.Firstname,
            Lastname = doctor.Lastname,
            MedicalDepartment = doctor.MedicalDepartment,

        };

        veiwModel.patient = new PatientDTO{
            FIN = patient.FIN,
            Firstname = patient.Firstname,
            Lastname = patient.Lastname,
            Email = patient.Email
        };
        
        return View(veiwModel);
    }
}

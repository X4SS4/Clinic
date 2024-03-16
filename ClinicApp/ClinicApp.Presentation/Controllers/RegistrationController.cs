namespace ClinicApp.Presentation.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ClinicApp.Core.Employees.Entities;
using ClinicApp.Infrastructure.Patients.Repositories.Base;
using ClinicApp.Core.Patients.Entities;
using ClinicApp.Core.Employees.DTO;
using ClinicApp.Core.Employees.ViewModels;

public class RegistrationController : Controller
{
    private readonly IPatientRepository patientRepository;
    private readonly UserManager<Employee> userManager;
    private readonly SignInManager<Employee> signInManager;
    private readonly RoleManager<IdentityRole<int>> roleManager;
    public RegistrationController(
        IPatientRepository patientRepository, 
        UserManager<Employee> userManager,
        RoleManager<IdentityRole<int>> roleManager,
        SignInManager<Employee> signInManager
    )
    {
        this.patientRepository = patientRepository;
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
    public async Task<IActionResult> RegistrationPatient([FromForm] Employee doctor, [FromForm] Patient patient)
    {
        string url = $@"/Registration/Receipt?doctorFIN={doctor.FIN}&patientFIN={patient.FIN}";
        string script = $@"<script> window.open('{url}', '_blank'); window.location.href = '/Home/Index'; </script>";
        return Content(script, "text/html");
    }

    [HttpGet]
    public IActionResult RegistrationEmployee()
    {
        return View(model: new EmployeeRegistrationDTO());
    }

    [HttpPost]
    public async Task<IActionResult> RegistrationEmployee([FromForm] EmployeeRegistrationDTO employeeDTO)
    {
        if (ModelState.IsValid)
        {
            var employee = new Employee
            {
                UserName = employeeDTO.Email,
                Email = employeeDTO.Email,
            };

            var result = await userManager.CreateAsync(employee, employeeDTO.Password);

            if (result.Succeeded)
            {
                var role = new IdentityRole<int>{Name = "Admin"};
                await roleManager.CreateAsync(role);
                await userManager.AddToRoleAsync(employee, "Admin");
                await signInManager.SignInAsync(employee, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        string url = $@"/Registration/SuccessfulRegistrationMessage?medicalemployeeEmail={employeeDTO.Email}";
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
        // var doctor = await doctorRepository.GetDoctorByFIN(doctorFIN);
        // var patient = await patientRepository.GetPatientByFIN(patientFIN);

        // veiwModel.doctor = new DoctorDTO{
        //     FIN = doctor.FIN,
        //     Firstname = doctor.Firstname,
        //     Lastname = doctor.Lastname,
        //     MedicalDepartment = doctor.MedicalDepartment,

        // };

        // veiwModel.patient = new PatientDTO{
        //     FIN = patient.FIN,
        //     Firstname = patient.Firstname,
        //     Lastname = patient.Lastname,
        //     Email = patient.Email
        // };
        
        return View(veiwModel);
    }
}
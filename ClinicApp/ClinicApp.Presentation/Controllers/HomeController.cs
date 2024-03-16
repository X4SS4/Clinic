namespace ClinicApp.Presentation.Controllers;

using Microsoft.AspNetCore.Mvc;
using ClinicApp.Core.DTO.MedicalEmployee;
using Microsoft.AspNetCore.Identity;
using ClinicApp.Core.Models.ClinicEntities.MedicalEmployee;

public class HomeController : Controller
{
    private readonly UserManager<MedicalEmployee> userManager;
    private readonly RoleManager<IdentityRole<int>> roleManager;
    private readonly SignInManager<MedicalEmployee> signInManager;
    public HomeController(
        UserManager<MedicalEmployee> userManager,
        RoleManager<IdentityRole<int>> roleManager,
        SignInManager<MedicalEmployee> signInManager)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Login()
    {
        return View(model: new MedicalEmployeeLogintDTO());
    }

    [HttpPost]
    public async Task<IActionResult> Login(MedicalEmployeeLogintDTO medicalEmployeeLogingDTO)
    {
        if (ModelState.IsValid)
        {
            var result = await signInManager.PasswordSignInAsync(medicalEmployeeLogingDTO.Email, medicalEmployeeLogingDTO.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(medicalEmployeeLogingDTO);
            }
        }
        return View(medicalEmployeeLogingDTO);
    }
}
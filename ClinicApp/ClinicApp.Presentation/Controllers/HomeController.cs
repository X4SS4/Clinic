namespace ClinicApp.Presentation.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ClinicApp.Core.Employees.Entities;
using ClinicApp.Core.Employees.DTO;

public class HomeController : Controller
{
    private readonly UserManager<Employee> userManager;
    private readonly RoleManager<IdentityRole<int>> roleManager;
    private readonly SignInManager<Employee> signInManager;
    public HomeController(
        UserManager<Employee> userManager,
        RoleManager<IdentityRole<int>> roleManager,
        SignInManager<Employee> signInManager)
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
        return View(model: new EmployeeLogintDTO());
    }

    [HttpPost]
    public async Task<IActionResult> Login(EmployeeLogintDTO medicalEmployeeLogingDTO)
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
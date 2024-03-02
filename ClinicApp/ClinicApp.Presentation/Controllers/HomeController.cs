namespace ClinicApp.Presentation.Controllers;

using Microsoft.AspNetCore.Mvc;
using ClinicApp.Core.DTO.MedicalEmployee;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
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
        if (ModelState.IsValid == false) return View();
        var medicalEmployee = await userManager.FindByEmailAsync(medicalEmployeeLogingDTO.Email);
        if (medicalEmployee is null) { return RedirectToAction("Index", "Home"); }
        var result = await signInManager.PasswordSignInAsync(medicalEmployee, medicalEmployeeLogingDTO.Password, true, true);
        if (result.Succeeded == false) return View();
        return RedirectToAction("Index", "Home");
    }
}
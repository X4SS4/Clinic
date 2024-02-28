namespace ClinicApp.Presentation.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.DataProtection;
using ClinicApp.Infrastructure.Repositories.MedicalEmployee.Base;
using ClinicApp.Core.DTO.MedicalEmployee;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

public class HomeController : Controller
{
    private readonly IMedicalEmployeeRepository medicalEmployeeRepository;
    private readonly IDataProtector dataProtector;
    public HomeController(IMedicalEmployeeRepository medicalEmployeeRepository, IDataProtectionProvider dataProtectionProvider)
    {
        this.medicalEmployeeRepository = medicalEmployeeRepository;
        this.dataProtector = dataProtectionProvider.CreateProtector("IdentityProtection");
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Login()
    {
        return View(model: new MedicalEmployeeLogintDTO());
    }

    [HttpPost]
    public async Task<IActionResult> Login(MedicalEmployeeLogintDTO medicalEmployeeLogingDTO)
    {
        if (ModelState.IsValid == false) { return View(); }
        var result = await medicalEmployeeRepository.LoginAsync(medicalEmployeeLogingDTO.Email, medicalEmployeeLogingDTO.Password);
        if (result is null) { return RedirectToAction("Index", "Home"); }
        var claims = new List<Claim>() {
            new Claim(ClaimTypes.Role, result.Role.ToString()),
            new Claim("MedicalEmployeeId", result.Id.ToString())
        };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        return RedirectToAction("Index", "Home");
    }
}
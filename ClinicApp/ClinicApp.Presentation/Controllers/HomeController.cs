namespace ClinicApp.Presentation.Controllers;

using ClinicApp.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.DataProtection;
using ClinicApp.Infrastructure.Repositories.MedicalReceptionist.Base;

public class HomeController : Controller
{
    private readonly IMedicalReceptionistRepository medicalReceptionistRepository;
    private readonly IDataProtector dataProtector;
    public HomeController(IMedicalReceptionistRepository medicalReceptionistRepository, IDataProtectionProvider dataProtectionProvider)
    {
        this.medicalReceptionistRepository = medicalReceptionistRepository;
        this.dataProtector = dataProtectionProvider.CreateProtector("IdentityProtection");
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Logout()
    {
        if (HttpContext.Request.Cookies["MedicalReceptionId"] is not null)
        {
            HttpContext.Response.Cookies.Append("MedicalReceptionId", "", new CookieOptions
            {
                Expires = DateTimeOffset.Parse("1/1/2000")
            });

        }
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Login()
    {
        return View(model: new MedicalReceptionisLogintDTO());
    }

    [HttpPost]
    [Route("[controller]/[action]")]
    public async Task<IActionResult> Login(MedicalReceptionisLogintDTO medicalReceptionisLogingDTO)
    {
        var result = await medicalReceptionistRepository.LoginAsync(medicalReceptionisLogingDTO.Email, medicalReceptionisLogingDTO.Password);
        if (result is not null)
        {
            HttpContext.Response.Cookies.Append("MedicalReceptionId", dataProtector.Protect(result.Id.ToString()));
            return RedirectToAction("Index", "Home");
        }
        ViewData.Add("Error", "Wrong email or/and password");
        return View();
    }
}
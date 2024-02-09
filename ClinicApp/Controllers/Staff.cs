namespace ClinicApp.Controllers;

using Microsoft.AspNetCore.Mvc;


[Route("[controller]")]
public class Staff : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
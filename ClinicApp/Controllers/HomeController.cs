namespace ClinicApp.Controllers;

using Microsoft.AspNetCore.Mvc;


public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Registration()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Registration([FromForm] int dt)
    {
        return View();
    }
}
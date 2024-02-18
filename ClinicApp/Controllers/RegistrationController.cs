using System;
namespace ClinicApp.Controllers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

public class RegistrationController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

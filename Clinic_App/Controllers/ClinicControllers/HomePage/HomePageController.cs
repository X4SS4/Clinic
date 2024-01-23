namespace Clinic_App.Controllers.ClinicControllers.HomePage;

using Clinic_App.Attributes;
using Clinic_App.Controllers.BaseControllers;


public class HomePageController : BaseController
{
    [HttpGet("/")]
    public async Task<string >homepageasync()
    {
        return await File.ReadAllTextAsync("C:\\Users\\Sevinc\\Desktop\\NEWClinic\\Clinic\\Clinic_App\\Views\\HomePage.html");
    }
}

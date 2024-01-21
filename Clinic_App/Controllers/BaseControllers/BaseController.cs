namespace Clinic_App.Controllers.BaseControllers;
using Clinic_App.Clinic_db_ef;

public class BaseController
{
    protected ClinicDbContext clinicDbContext = new();

    public object HttpContext { get; internal set; }
}

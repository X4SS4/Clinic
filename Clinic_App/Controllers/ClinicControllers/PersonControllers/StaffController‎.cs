namespace Clinic_App.Controllers.ClinicControllers.PersonControllers;
using Clinic_App.Controllers.BaseControllers;
using Clinic_App.Models.Persons;
using System.Net;
using System.Text.Json;

public class StaffController : BaseController
{
    //[HttpGet("/")]
    public string Get()
    {
        var staff = clinicDbContext.Staff.ToList();
        var staffJson = JsonSerializer.Serialize(staff);
        return staffJson;
    }

    //[HttpPost("/api/create")]
    public string Create(HttpListenerContext context)
    {
        var request = context.Request;
        using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
        {
            var requestBody = reader.ReadToEnd();
            var newStaff = JsonSerializer.Deserialize<Staff>(requestBody);
            var staffEntry = clinicDbContext.Staff.Add(newStaff);
            clinicDbContext.SaveChanges();
            return requestBody;
        }
    }


    //[HttpPut("/api/update")]
    public string Update(HttpListenerContext context)
    {
        var request = context.Request;
        var staffId = request.QueryString["id"];
        var staff = clinicDbContext.Staff.Find(staffId);
        if (staff == null)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return string.Empty;
        }
        using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
        {
            var requestBody = reader.ReadToEnd();
            var newStaff = JsonSerializer.Deserialize<Staff>(requestBody);
            if (newStaff == null || newStaff.FirstName == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return string.Empty;
            }
            staff.FirstName = newStaff.FirstName;
            staff.LastName = newStaff.LastName;
            staff.FIN = newStaff.FIN;
            staff.Birthday = newStaff.Birthday;
            staff.Contract = newStaff.Contract;
            clinicDbContext.SaveChanges();
            return requestBody;
        }
    }

    //[HttpDelete("/api/delete")]
    public string Delete(HttpListenerContext context)
    {
        var request = context.Request;
        var staffId = int.Parse(request.QueryString["id"].ToString());
        var staffRemove = clinicDbContext.Staff.Find(staffId);
        if (staffRemove != null)
        {
            clinicDbContext.Staff.Remove(staffRemove);
            clinicDbContext.SaveChanges();
            return $"Deleted staff by id: {staffId}";
        }
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return string.Empty;
    }

    //public async Task GetAllStaffAsync()
    //{
    //    using var writer = new StreamWriter(base.HttpContext.Response.OutputStream);
    //    using (var context = new ClinicDbContext())
    //    {
    //        List<Patient> allPatients = context.Patients.ToList();

    //        await writer.WriteLineAsync(JsonSerializer.Serialize(allPatients));
    //        base.HttpContext.Response.ContentType = "application/json";
    //        base.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
    //    }
    //}

    // public async Task GetStaffByIdAsync()
    // {
    //     var staffIdToGetObj = base.HttpContext.Request.QueryString["id"];


    //     // using (var context = new ClinicDbContext())
    //     // {
    //     //     if (staffIdToGetObj == null || int.TryParse(staffIdToGetObj, out int staffIdToGet) == false)
    //     //     {
    //     //         base.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    //     //         return;
    //     //     }
    //     //     var staff = context.Staff.FirstOrDefault(s => s.Id == staffIdToFind);
    //     //     if (staff is null)
    //     //     {
    //     //         base.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
    //     //         return;
    //     //     }
    //     //     using var writer = new StreamWriter(base.HttpContext.Response.OutputStream);
    //     //     await writer.WriteLineAsync(JsonSerializer.Serialize(staff));
    //     //     base.HttpContext.Response.ContentType = "application/json";
    //     //     base.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
    //     // }

    // }
}

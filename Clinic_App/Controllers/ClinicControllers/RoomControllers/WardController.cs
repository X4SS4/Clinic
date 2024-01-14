namespace Clinic_App.Controllers.ClinicControllers.RoomControllers;
using Clinic_App.Controllers.BaseControllers;
using Clinic_App.Models.Persons;
using Clinic_App.Models.Rooms;
using System.Net;
using System.Text.Json;

public class WardController : BaseController
{
    //[HttpGet("/")]
    public string Get()
    {
        var wards = clinicDbContext.Wards.ToList();
        var wardsJson = JsonSerializer.Serialize(wards);
        return wardsJson;
    }

    //[HttpPost("/api/create")]
    public string Create(HttpListenerContext context)
    {
        var request = context.Request;
        using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
        {
            var requestBody = reader.ReadToEnd();
            var newWard = JsonSerializer.Deserialize<Ward>(requestBody);
            var wardEntry = clinicDbContext.Wards.Add(newWard);
            clinicDbContext.SaveChanges();
            return requestBody;
        }
    }

    //[HttpPut("/api/update")]
    public string Update(HttpListenerContext context)
    {
        var request = context.Request;
        var wardId = request.QueryString["id"];
        var ward = clinicDbContext.Wards.Find(wardId);
        if (ward == null)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return string.Empty;
        }
        using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
        {
            var requestBody = reader.ReadToEnd();
            var newWard = JsonSerializer.Deserialize<Ward>(requestBody);
            if (newWard == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return string.Empty;
            }
            ward.Number = newWard.Number;
            ward.PatientCapacity = newWard.PatientCapacity;
            ward.Floor = newWard.Floor;
            ward.Patients = newWard.Patients;
            clinicDbContext.SaveChanges();
            return requestBody;
        }
    }

    //[HttpDelete("/api/delete")]
    public string Delete(HttpListenerContext context)
    {
        var request = context.Request;
        var wardId = int.Parse(request.QueryString["id"].ToString());
        var wardRemove = clinicDbContext.Wards.Find(wardId);
        if (wardRemove != null)
        {
            clinicDbContext.Wards.Remove(wardRemove);
            clinicDbContext.SaveChanges();
            return $"Deleted staff by id: {wardId}";
        }
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return string.Empty;
    }
}

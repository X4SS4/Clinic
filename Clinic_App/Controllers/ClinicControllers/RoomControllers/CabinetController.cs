namespace Clinic_App.Controllers.ClinicControllers.RoomControllers;
using Clinic_App.Attributes;
using Clinic_App.Controllers.BaseControllers;
using Clinic_App.Models.Rooms;
using System.Net;
using System.Text.Json;

public class CabinetController : BaseController
{

    [HttpGet("/Cabinet")]
    public string Get()
    {
        var cabinets = clinicDbContext.Cabinets.ToList();
        var cabinetsJson = JsonSerializer.Serialize(cabinets);
        return cabinetsJson;
    }

    [HttpPost("/Cabinet/create")]
    public string Create(HttpListenerContext context)
    {
        var request = context.Request;
        using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
        {
            var requestBody = reader.ReadToEnd();
            var newCabinet = JsonSerializer.Deserialize<Cabinet>(requestBody);
            var cabinetEntry = clinicDbContext.Cabinets.Add(newCabinet);
            clinicDbContext.SaveChanges();
            return requestBody;
        }
    }


    [HttpPut("/Cabinet/update")]
    public string Update(HttpListenerContext context)
    {
        var request = context.Request;
        var cabinetId = request.QueryString["id"];
        var cabinet = clinicDbContext.Cabinets.Find(cabinetId);
        if (cabinet == null)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return string.Empty;
        }
        using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
        {
            var requestBody = reader.ReadToEnd();
            var newCabinet = JsonSerializer.Deserialize<Cabinet>(requestBody);
            if (newCabinet == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return string.Empty;
            }
            cabinet.Number = newCabinet.Number;
            cabinet.owner = newCabinet.owner;
            cabinet.Floor = newCabinet.Floor;
            clinicDbContext.SaveChanges();
            return requestBody;
        }
    }



    [HttpDelete("/Cabinet/delete")]
    public string Delete(HttpListenerContext context)
    {
        var request = context.Request;
        var cabinetId = int.Parse(request.QueryString["id"].ToString());
        var cabinetRemove = clinicDbContext.Cabinets.Find(cabinetId);
        if (cabinetRemove != null)
        {
            clinicDbContext.Cabinets.Remove(cabinetRemove);
            clinicDbContext.SaveChanges();
            return $"Deleted staff by id: {cabinetId}";
        }
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return string.Empty;
    }
}

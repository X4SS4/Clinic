namespace Clinic_App.Controllers.ClinicControllers.PersonControllers;
using Clinic_App.Attributes;
using Clinic_App.Controllers.BaseControllers;
using Clinic_App.Models.Persons;
using Clinic_App.Models.Persons.StaffEntities;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

public class StaffController : BaseController
{
    [HttpGet("/Staff")]
    public string Get()
    {
        var staff = clinicDbContext.Staff.Include(s => s.Contract).ToList();
        var staffJson = JsonSerializer.Serialize(staff);
        return staffJson;
    }

    [HttpPost("/Staff/create")]
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


    [HttpPut("/Staff/update")]
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
            clinicDbContext.SaveChanges();
            return requestBody;
        }
    }

    [HttpDelete("/Staff/delete")]
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

    [HttpPut("/Staff/Contract/update")]
    public string ChangeContract(HttpListenerContext context)
    {
        var request = context.Request;
        var staffId = int.Parse(request.QueryString["id"]);
        var contractId = clinicDbContext.Staff.FirstOrDefault(staff => staff.Id == staffId).Contract.Id;
        var contract = clinicDbContext.StaffContracts.FirstOrDefault(contract => contract.Id == contractId);
        using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
        {
            var requestBody = reader.ReadToEnd();
            var newContract = JsonSerializer.Deserialize<StaffContract>(requestBody);
            contract.Salary = newContract.Salary;
            contract.Job_title = newContract.Job_title;
            clinicDbContext.SaveChanges();
            return requestBody;
        }
    }
}

namespace Clinic_App.Controllers.ClinicControllers.PersonControllers;
using Clinic_App.Attributes;
using Clinic_App.Clinic_db_ef;
using Clinic_App.Controllers.BaseControllers;
using Clinic_App.Models.Persons;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

public class PatientController : BaseController
{
    [HttpGet("/Patient")]
    public string Get()
    {
        var patients = clinicDbContext.Patients
            .Include(p => p.PatientCard)
            .ThenInclude(pc => pc.DiseaseHistories).ToList();
        var patientsJson = JsonSerializer.Serialize(patients);
        return patientsJson;
    }

    [HttpPost("/Patient/create")]
    public string Create(HttpListenerContext context)
    {
        var request = context.Request;
        using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
        {
            var requestBody = reader.ReadToEnd();
            var newPatient = JsonSerializer.Deserialize<Patient>(requestBody);
            clinicDbContext.Patients.Add(newPatient);
            clinicDbContext.SaveChanges();
            return requestBody;
        }
    }

    [HttpPut("/Patient/update")]
    public string Update(HttpListenerContext context)
    {
        var request = context.Request;
        var patientId = int.Parse(request.QueryString["id"]);
        var patient = clinicDbContext.Patients.Find(patientId);
        if (patient == null)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return string.Empty;
        }
        using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
        {
            var requestBody = reader.ReadToEnd();
            var newPatient = JsonSerializer.Deserialize<Patient>(requestBody);
            if (newPatient == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return string.Empty;
            }
            patient.FirstName = newPatient.FirstName;
            patient.LastName = newPatient.LastName;
            patient.FIN = newPatient.FIN;
            patient.Birthday = newPatient.Birthday;
            clinicDbContext.SaveChanges();
            return requestBody;
        }
    }

    [HttpDelete("/Patient/delete")]
    public string Delete(HttpListenerContext context)
    {
        var request = context.Request;
        var patientId = int.Parse(request.QueryString["id"].ToString());
        var patientRemove = clinicDbContext.Patients.Find(patientId);
        if (patientRemove != null)
        {
            clinicDbContext.Patients.Remove(patientRemove);
            clinicDbContext.SaveChanges();
            return $"Deleted staff by id: {patientId}";
        }
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return string.Empty;
    }

    [HttpPut("/Patient/update/ward")]
    public string InWard(HttpListenerContext context)
    {
        var request = context.Request;
        var patientId = int.Parse(request.QueryString["id"]);
        var wardNumber = int.Parse(request.QueryString["ward"]);
        var patient = clinicDbContext.Patients.FirstOrDefault(p => p.Id == patientId);
        var ward = clinicDbContext.Wards.FirstOrDefault(w => w.Number == wardNumber);
        patient.Ward = ward;
        clinicDbContext.SaveChanges();
        return "Patient added ";
    }
}
